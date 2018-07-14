using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Bosses
{
    public class Energy : ModProjectile
    {
        public override void SetDefaults()
        {
			projectile.width = 8;
			projectile.height = 8;
			projectile.aiStyle = -1;
			projectile.tileCollide = false;
			projectile.timeLeft = 120;
			projectile.alpha = 255;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Energy");
            DisplayName.AddTranslation(GameCulture.Chinese, "能量");
            DisplayName.AddTranslation(GameCulture.Russian, "Энергия");
        }

        public override void AI()
        {
			Vector2 vector2 = new Vector2(projectile.ai[0], projectile.ai[1]) - projectile.Center;
			if ((double)vector2.Length() < (double)projectile.velocity.Length())
			{
				projectile.Kill();
			}
			else
			{
				vector2.Normalize();
				projectile.velocity = Vector2.Lerp(projectile.velocity, vector2 * 15f, 0.1f);
				for (int index1 = 0; index1 < 2; ++index1)
				{
					int index2 = Dust.NewDust(projectile.Center, 0, 0, (WorldGen.crimson ? 60 : 62), 0.0f, 0.0f, 100, new Color(), 1f);
					Main.dust[index2].noGravity = true;
					Main.dust[index2].position += new Vector2(4f);
					Main.dust[index2].scale += Main.rand.NextFloat() * 1f;
				}
			}
        }
    }
}
