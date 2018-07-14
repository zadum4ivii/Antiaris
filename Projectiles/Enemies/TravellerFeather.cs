using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Enemies
{
    public class TravellerFeather : ModProjectile
    {
        public override void SetDefaults()
        {
			projectile.width = 14;
			projectile.height = 24;
			projectile.aiStyle = 1;
			projectile.hostile = true;
            projectile.tileCollide = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Traveller Feather");
            DisplayName.AddTranslation(GameCulture.Russian, "Перо путешестенника");
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
