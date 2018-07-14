using System;
using Antiaris.VEffects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Magic
{
    public class CopyOrderEnergy : ModProjectile
    {
        LightningBolt bolt;
        public override Color? GetAlpha(Color lightColor) { return Color.White; }

        public override void SetDefaults()
        {
            projectile.width = 34;
            projectile.height = 90;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.aiStyle = 1;
			projectile.alpha = 255;
			projectile.penetrate = 1;
			projectile.extraUpdates = 1;
            projectile.timeLeft = 240;
			projectile.ignoreWater = true;
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = -1;
			projectile.scale = 0.7f;
		}

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Energy of Order");
			DisplayName.AddTranslation(GameCulture.Chinese, "秩序之力");
            DisplayName.AddTranslation(GameCulture.Russian, "Энергия порядка");
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
			Main.projFrames[projectile.type] = 1;
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			width = 10;
			height = 10;
			return true;
		}

        public override void AI()
        {
			float moveX = projectile.Center.X;
			float moveY = projectile.Center.Y;
			float distance = 315f;
			bool target = false;
			for (int k = 0; k < 200; ++k)
			{
				NPC npc = Main.npc[k];
				if (npc.active && !npc.dontTakeDamage && !npc.friendly && npc.lifeMax > 5 && npc.type != 488 && (double)projectile.Distance(npc.Center) < (double)distance && Collision.CanHit(projectile.Center, 1, 1, npc.Center, 1, 1))
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
				float speed = 8.5f;
				projectile.velocity.X = (float)(((double)projectile.velocity.X * 20.0 + (double)newMoveToX * (speed / newDistance)) / 21.0);
				projectile.velocity.Y = (float)(((double)projectile.velocity.Y * 20.0 + (double)newMoveToY * (speed / newDistance)) / 21.0);
			}
			if ((double)projectile.ai[0] >= 10.0) projectile.velocity.Y += 0.1f;
            if ((double)projectile.ai[0] >= 20.0) projectile.velocity.Y += 0.1f;
            if ((double)projectile.ai[0] > 20.0) projectile.ai[0] = 20f;
            projectile.velocity.X *= 0.99f;
            if ((double)projectile.velocity.Y > 32.0) projectile.velocity.Y = 32f;
			try
            {
				if (this.bolt == null)
                    this.bolt = new LightningBolt(projectile.position, 0, 3f);
				this.UpdateBolt();	
				foreach (Projectile projectile_ in Main.projectile) if ((double)Vector2.Distance(projectile.Center, projectile_.Center) < 200.0 && projectile_.active && projectile_.ai[0] == projectile.ai[0] && this.bolt.Ticks <= 0 && Main.rand.NextBool(1, 2)) 
				{
					projectile_.damage = (int)(57 * (double)Main.player[projectile.owner].magicDamage);
					this.bolt = new LightningBolt(projectile_.Center, projectile.Center, Main.rand.Next(3, 5), 4f);
				}
            }
            catch (Exception exception)
            {
                Main.NewText("Oh no, an error happened! Report this to Zerokk and send him the file Terraria/ModLoader/Logs/Logs.txt");
                ErrorLogger.Log(exception);
            }
        }

        public virtual void UpdateBolt() { this.bolt.Ticks--; }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			target.AddBuff(mod.BuffType("LightRage"), 80, false);
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
			if (this.bolt != null) this.bolt.Draw(spriteBatch, Color.White);
            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            for (int k = 0; k < projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
				color.B = color.G = color.R = 150;
                spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
            }
            return true;
        }

        public override void Kill(int timeLeft)
		{ 
		    for (int k = 0; k < 13; k++)
            {
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("Order"), 0.0f, 0.0f, 100, new Color(), 1f);
                Main.dust[dust].noGravity = true;
				Main.dust[dust].noLight = true;
                Main.dust[dust].velocity = projectile.velocity.RotatedBy(15 * (k + 2));
            }
			Main.PlayTrackedSound(SoundID.DD2_BetsyFireballImpact, projectile.position); 
		}
    }
}
