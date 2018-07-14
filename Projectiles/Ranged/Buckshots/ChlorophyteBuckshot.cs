using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.Projectiles.Ranged.Buckshots
{
    public class ChlorophyteBuckshot : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 14;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.penetrate = 5;
            projectile.timeLeft = 600;
            projectile.extraUpdates = 1;
            projectile.alpha = 255;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 2;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            aiType = ProjectileID.Bullet;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chlorophyte Buckshot");
            DisplayName.AddTranslation(GameCulture.Chinese, "叶绿火铳弹");
            DisplayName.AddTranslation(GameCulture.Russian, "Хлорофитовая картечь");
        }

        public void OverhaulInit()
        {
            this.SetTag("bullet");
            this.SetTag("fixPenetration");
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			width = 10;
			height = 10;
			return true;
		}

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }

        public override void Kill(int timeLeft)
        {
            for (var k = 0; k < 8; k++)
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 75, projectile.oldVelocity.X * 0.2f, projectile.oldVelocity.Y * 0.2f);
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        { 
			Player owner = null;
            if (projectile.owner != -1)
            {
                owner = Main.player[projectile.owner];
            }
            else if (projectile.owner == 255)
            {
                owner = Main.LocalPlayer;
            }
            var player = owner;
            var aPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
            if (projectile.owner == Main.myPlayer && aPlayer.boilingPoint)
			{
				target.AddBuff(BuffID.OnFire, 120, false);
			}
			if (projectile.owner == Main.myPlayer && aPlayer.cherryBlossom)
			{
				target.AddBuff(BuffID.Poisoned, 120, false);
			}
			if (projectile.owner == Main.myPlayer && aPlayer.despairingFlames)
			{
				target.AddBuff(mod.BuffType("DespairingFlames"), 120, false);
			}
			if (projectile.owner == Main.myPlayer && aPlayer.thoriumBlunderbuss)
			{
				projectile.penetrate++;
			}
        }

        public override void AI()
        {
            for (var i = 0; i < 7; i++)
            {
                var x = projectile.Center.X - projectile.velocity.X / 10f * (float)i;
                var y = projectile.Center.Y - projectile.velocity.Y / 10f * (float)i;
                var dust = Dust.NewDust(new Vector2(x, y), 1, 1, 75, 0f, 0f, 0, default(Color), 2f);
                Main.dust[dust].alpha = projectile.alpha;
                Main.dust[dust].position.X = x;
                Main.dust[dust].position.Y = y;
                Main.dust[dust].velocity *= 0f;
                Main.dust[dust].noGravity = true;
            }
			float CenterX = projectile.Center.X;
            float CenterY = projectile.Center.Y;
            float Distanse = 400f;
            bool CheckDistanse = false;
            for (int MobCounts = 0; MobCounts < 200; MobCounts++)
            {
                if (Main.npc[MobCounts].CanBeChasedBy(projectile, false) && Collision.CanHit(projectile.Center, 1, 1, Main.npc[MobCounts].Center, 1, 1))
                {
                    float Position1 = Main.npc[MobCounts].position.X + (float)(Main.npc[MobCounts].width / 2);
                    float Position2 = Main.npc[MobCounts].position.Y + (float)(Main.npc[MobCounts].height / 2);
                    float Position3 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - Position1) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - Position2);
                    if (Position3 < Distanse)
                    {
                        Distanse = Position3;
                        CenterX = Position1;
                        CenterY = Position2;
                        CheckDistanse = true;
                    }
                }
            }
            if (CheckDistanse)
            {
                float Speed = 20f;
                Vector2 FinalPos = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
                float NewPosX = CenterX - FinalPos.X;
                float NewPosY = CenterY - FinalPos.Y;
                float FinPos = (float)Math.Sqrt((double)(NewPosX * NewPosX + NewPosY * NewPosY));
                FinPos = Speed / FinPos;
                NewPosX *= FinPos;
                NewPosY *= FinPos;
                projectile.velocity.X = (projectile.velocity.X * 20f + NewPosX) / 21f;
                projectile.velocity.Y = (projectile.velocity.Y * 20f + NewPosY) / 21f;
                return;
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.penetrate--;
            if (projectile.penetrate <= 0)
            {
                projectile.Kill();
            }
            else
            {
                if (projectile.velocity.X != oldVelocity.X)
                {
                    projectile.velocity.X = -oldVelocity.X;
                }
                if (projectile.velocity.Y != oldVelocity.Y)
                {
                    projectile.velocity.Y = -oldVelocity.Y;
                }
                Main.PlaySound(SoundID.Item10, projectile.position);
            }
            return false;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            for (int k = 0; k < projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
            }
            return true;
        }
    }
}
