using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.Projectiles.Magic
{
    public class Hellbat : ModProjectile
    {
        public override Color? GetAlpha(Color lightColor) { return Color.White; }

        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 12;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.aiStyle = 1;
			projectile.alpha = 255;
			projectile.penetrate = 1;
            projectile.timeLeft = 1200;
			projectile.extraUpdates = 1;
			aiType = ProjectileID.Bullet;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hellbat");
			DisplayName.AddTranslation(GameCulture.Chinese, "地狱蝙蝠");
            DisplayName.AddTranslation(GameCulture.Russian, "Адская летучая мышь");
			ProjectileID.Sets.Homing[projectile.type] = true;
			Main.projFrames[projectile.type] = 4;
        }

        public void OverhaulInit()
        {
            this.SetTag("incendiary");
            this.SetTag("incendiarySlow");
        }

        public override void AI()
        {
			projectile.rotation = 0.0f;
			if (projectile.alpha > 0) projectile.alpha--;
			projectile.spriteDirection = -projectile.direction;
			projectile.frameCounter++;
            if (projectile.frameCounter >= 6) { projectile.frame++; projectile.frameCounter = 0; }
            if (projectile.frame >= (int)Main.projFrames[projectile.type]) projectile.frame = 0;			
			float moveX = projectile.Center.X;
			float moveY = projectile.Center.Y;
			float distance = 265f;
			bool target = false;
			for (int k = 0; k < 200; ++k)
			{
				NPC npc = Main.npc[k];
				if (!npc.wet && npc.active && !npc.dontTakeDamage && !npc.friendly && npc.lifeMax > 5 && npc.type != 488 && (double)projectile.Distance(npc.Center) < (double)distance && Collision.CanHit(projectile.Center, 1, 1, npc.Center, 1, 1))
				{
					float moveToX = npc.position.X + (float)(npc.width / 2);
					float moveToY = npc.position.Y + (float)(npc.height / 2);
					float distanceTo = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - moveToX) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - moveToY);
					if (distanceTo < distance)
					{
					    if ((double)npc.position.X > (double)projectile.position.X) projectile.direction = 1;
						else if ((double)npc.position.X < (double)projectile.position.X) projectile.direction = -1;
						distance = distanceTo;
						moveX = moveToX;
						moveY = moveToY;
						target = true;
					}
				}
			}	
			if (target)
			{
			    Vector2 vector = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
				float newMoveToX = moveX - vector.X;
				float newMoveToY = moveY - vector.Y;
				float newDistance = (float)Math.Sqrt((double)newMoveToX * (double)newMoveToX + (double)newMoveToY * (double)newMoveToY);
				float speed = 6.0f;
				projectile.velocity.X = (float)(((double)projectile.velocity.X * 20.0 + (double)newMoveToX * (speed / newDistance)) / 21.0);
				projectile.velocity.Y = (float)(((double)projectile.velocity.Y * 20.0 + (double)newMoveToY * (speed / newDistance)) / 21.0);
			}
			for (int k = 0; k < 2; k++)
            {
                int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Fire, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, new Color(), 0.95f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity.X += 0.6f * projectile.spriteDirection;
            }
        }

        public override void Kill(int timeLeft)
        {
			Projectile.NewProjectile(projectile.position, Vector2.Zero, mod.ProjectileType(GetType().Name + "Explosion"), projectile.damage, projectile.knockBack, projectile.owner);
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			if (!projectile.wet) target.AddBuff(BuffID.OnFire, 120, false);
        }

        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			if (projectile.wet) damage /= 2;
		}
    }
}
