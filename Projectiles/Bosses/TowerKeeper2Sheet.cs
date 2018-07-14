using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Bosses
{
    public class TowerKeeper2Sheet : ModProjectile
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
            DisplayName.SetDefault("Tower Keeper");
            DisplayName.AddTranslation(GameCulture.Chinese, "守塔魔像");
            DisplayName.AddTranslation(GameCulture.Russian, "Хранитель башни");
        }

        public override void AI()
        {
            if (projectile.timeLeft == 120)
            {
                for (int k = 0; k < 50; k++)
                {
                    int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 62, 0.0f, -2.0f, 0, new Color(), 2.0f);
                    Main.dust[dust].noGravity = true;
                    Dust dust1 = Main.dust[dust];
                    dust1.position.X = dust1.position.X + ((float)(Main.rand.Next(-50, 51) / 20) - 1.5f);
                    Dust dust2 = Main.dust[dust];
                    dust2.position.Y = dust2.position.Y + ((float)(Main.rand.Next(-50, 51) / 20) - 1.5f);
                    if (Main.dust[dust].position != projectile.Center) Main.dust[dust].velocity = projectile.DirectionTo(Main.dust[dust].position) * 2.0f;
                }
                Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
            }
        }

        public override void Kill(int timeLeft)
        {
            if (Main.rand.Next(2) == 0) Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - (float)Main.rand.Next(223, 265), 0.0f, 9.6f, mod.ProjectileType("GolemCrystal2"), projectile.damage, 7.0f);
            else Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y + (float)Main.rand.Next(223, 265), 0.0f, -9.6f, mod.ProjectileType("GolemCrystal2"), projectile.damage, 7.0f);
        }
    }
}
