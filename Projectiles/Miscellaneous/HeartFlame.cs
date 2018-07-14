using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Miscellaneous
{
    public class HeartFlame : ModProjectile
    {
        public override Color? GetAlpha(Color lightColor)
        {
            if (projectile.timeLeft < 30)
                projectile.alpha = (int)((double)byte.MaxValue - (double)byte.MaxValue * (double)((float)projectile.timeLeft / 30f));
            return new Color(255 - projectile.alpha, 255 - projectile.alpha, 255 - projectile.alpha, 128 - projectile.alpha / 2);
        }

        public override void SetDefaults()
        {
			projectile.width = 20;
			projectile.height = 30;
			projectile.tileCollide = false;
			projectile.timeLeft = 180;
            projectile.ignoreWater = true;
            projectile.alpha = 255;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Heart Flame");
            DisplayName.AddTranslation(GameCulture.Russian, "Сердечное пламя");
            DisplayName.AddTranslation(GameCulture.Chinese, "心之焰");
            Main.projFrames[projectile.type] = 4;
        }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            projectile.frameCounter++;
            if (projectile.frameCounter >= 4) { projectile.frame++; projectile.frameCounter = 0; }
            if (projectile.frame >= (int)Main.projFrames[projectile.type]) projectile.frame = 0;
            if (projectile.timeLeft > 30 && projectile.alpha > 0)
                projectile.alpha -= 12;
            if (projectile.timeLeft > 30 && projectile.alpha < 128 && Collision.SolidCollision(projectile.position, projectile.width, projectile.height))
                projectile.alpha = 128;
            if (projectile.alpha < 0)
                projectile.alpha = 0;
            Vector2 vector = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
            Vector2 vector2 = new Vector2(player.position.X + (float)player.width * 0.5f, player.position.Y + (float)player.height * 0.5f);
            float newMoveToX = vector2.X - vector.X;
            float newMoveToY = vector2.Y - vector.Y;
            float newDistance = (float)Math.Sqrt((double)newMoveToX * (double)newMoveToX + (double)newMoveToY * (double)newMoveToY);
            float speed = 5.0f;
            projectile.velocity.X = (float)(((double)projectile.velocity.X * 20.0 + (double)newMoveToX * (speed / newDistance)) / 21.0);
            projectile.velocity.Y = (float)(((double)projectile.velocity.Y * 20.0 + (double)newMoveToY * (speed / newDistance)) / 21.0);
            if (player.active && ((double)Vector2.Distance(player.Center, projectile.Center) < 25.0))
            {
                player.statLife += (int)projectile.ai[1];
                player.HealEffect((int)projectile.ai[1]);
                projectile.Kill();
            }
            float ai2 = 0.5f;
            if (projectile.timeLeft < 120)
                ai2 = 1.1f;
            if (projectile.timeLeft < 60)
                ai2 = 1.6f;
            ++projectile.ai[0];
            double ai = (double)projectile.ai[0] / 180.0;
            for (float k = 0.0f; (double)k < 3.0; k++)
                if (Main.rand.Next(3) == 0)
                {
                    Dust dust = Main.dust[Dust.NewDust(projectile.Center, 0, 0, 90, 0.0f, -2.0f, 0, new Color(), 1.0f)];
                    dust.position = projectile.Center + Vector2.UnitY.RotatedBy((double)k * 6.28318548202515 / 3.0 + (double)projectile.ai[0], new Vector2()) * 10.0f;
                    dust.noGravity = true;
                    dust.velocity = projectile.DirectionFrom(dust.position);
                    dust.scale = ai2;
                    dust.fadeIn = 0.5f;
                    dust.alpha = 200;
                }
        }
    }
}
