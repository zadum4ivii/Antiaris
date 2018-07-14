using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Magic
{
    public class Lightning1 : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 14;
            projectile.aiStyle = -1;
            projectile.alpha = (int)byte.MaxValue;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 60;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lightning");
			DisplayName.AddTranslation(GameCulture.Chinese, "闪电");	
            DisplayName.AddTranslation(GameCulture.Russian, "Молния");
        }

        public override void AI()
        {
            int[] count = new int[10];
            Vector2[] vector2Array = new Vector2[10];
            int index1 = 0;
            float num1 = 2000.0f;
            for (int k = 0; k < 255; k++)
            {
                Vector2 vector2;
                vector2.X = Main.MouseWorld.X;
                vector2.Y = Main.MouseWorld.Y;
                if ((double)Vector2.Distance(vector2, projectile.Center) < (double)num1)
                {
                    count[index1] = k;
                    vector2Array[index1] = vector2;
                    int num2 = k + 1;
                    index1 = num2;
                    if (num2 >= vector2Array.Length)
                        break;
                }
            }
            int num3;
            for (int index2 = 0; index2 < index1; index2 = num3 + 1)
            {
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X, projectile.velocity.Y, mod.ProjectileType("Lightning"), projectile.damage, 0.0f, projectile.owner, (vector2Array[index2] - projectile.Center).ToRotation(), (float)Main.rand.Next(100));
                num3 = index2;
                projectile.Kill();
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return false;
        }
    }
}
