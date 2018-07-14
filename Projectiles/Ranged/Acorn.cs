using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Ranged
{
    public class Acorn : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Acorn");
			DisplayName.AddTranslation(GameCulture.Chinese, "橡子"); 
            DisplayName.AddTranslation(GameCulture.Russian, "Желудь");
        }

        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 14;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 600;
            projectile.extraUpdates = 1;
        }

        public override void Kill(int timeLeft)
        {
            if (Main.netMode != 2)
            {
                Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
                Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 1);
            }
        }
    }
}
