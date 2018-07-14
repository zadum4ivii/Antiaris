using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Magic
{
    public class AcornCreature : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(379);
            aiType = 379;
			projectile.magic = true;
            projectile.width = 16;
            projectile.height = 16;
            projectile.penetrate = 3;
            projectile.timeLeft = 300;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Acorn Creature");
            DisplayName.AddTranslation(GameCulture.Chinese, "橡子生物");
            DisplayName.AddTranslation(GameCulture.Russian, "Существо из жёлудя");
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            return false;
        }

        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 8; k++)
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 1, projectile.oldVelocity.X * 0.2f, projectile.oldVelocity.Y * 0.2f);
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
        }
    }
}
