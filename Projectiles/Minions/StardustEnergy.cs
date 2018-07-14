using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Minions
{
    public class StardustEnergy : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 22;
            projectile.height = 60;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.minion = true;
            projectile.penetrate = 3;
            projectile.timeLeft = 240;
            projectile.extraUpdates = 1;
			projectile.knockBack = 2f;
            aiType = ProjectileID.Bullet;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 12;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
			projectile.tileCollide = false;;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stardust Energy");
            DisplayName.AddTranslation(GameCulture.Chinese, "星尘能量");
            DisplayName.AddTranslation(GameCulture.Russian, "Энергия звёздной пыли");
        }

        public override void AI()
		{
			Dust dust = Dust.NewDustDirect(projectile.position, projectile.height, projectile.width, 59, projectile.velocity.X * .2f, projectile.velocity.Y * .2f, 200, Scale: 1.2f);
			dust.velocity += projectile.velocity * 0.3f;
			dust.velocity *= 0.2f;
			
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
                float Speed = 40f;
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

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            for(int k = 0; k < projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
            }
            return true;
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			width = 20;
			height = 20;
			return true;
		}

        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 8; k++)
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 59, projectile.oldVelocity.X * 0.2f, projectile.oldVelocity.Y * 0.2f);
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
        }
    }
}