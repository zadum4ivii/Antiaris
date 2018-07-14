using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Magic
{
    public class RainbowShot5 : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 10;
            projectile.aiStyle = 0;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 600;
            projectile.alpha = 255;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rainbow Shot");
			DisplayName.AddTranslation(GameCulture.Russian, "Радужный выстрел");
            DisplayName.AddTranslation(GameCulture.Chinese, "虹彩弹");
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 7;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			width = 10;
			height = 10;
			return true;
		}

        public override void AI()
        {
            Vector2 vector = new Vector2(projectile.ai[0], projectile.ai[1]) - projectile.Center;
            if ((double)projectile.timeLeft < 275.0) projectile.Kill();
            if ((double)vector.Length() < (double)projectile.velocity.Length()) projectile.Kill();
            else
            {
                vector.Normalize();
                projectile.velocity = Vector2.Lerp(projectile.velocity, vector * 11.2f, 0.1f);
                for (int k = 0; k < 3; k++)
                {
                    int dust = Dust.NewDust(projectile.Center, projectile.width, projectile.height, 135, 0.0f, 0.0f, 100, new Color(), 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].position += new Vector2(4f);
                    Main.dust[dust].scale += Main.rand.NextFloat() * 1.0f;
                }
            }
            projectile.netUpdate = true;
        }

        public override void Kill(int timeLeft)
        {
			for (int k = 0; k < 30; ++k)
            {
                int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y + 2f), projectile.width + 5, projectile.height + 5, 135, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, new Color(), 1.8f);
                Main.dust[dust].noGravity = true;
            }
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
        }
    }
}
