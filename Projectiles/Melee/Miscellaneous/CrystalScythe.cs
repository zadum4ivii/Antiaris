using Microsoft.Xna.Framework;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Melee.Miscellaneous
{
    public class CrystalScythe : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 50;
            projectile.height = 52;
            projectile.aiStyle = 3;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.penetrate = 4;
            projectile.timeLeft = 600;
            projectile.tileCollide = false;
            aiType = 52;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystal Scythe");
            DisplayName.AddTranslation(GameCulture.Russian, "Кристальная коса");
			DisplayName.AddTranslation(GameCulture.Chinese, "红水晶镰刀");
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
        {
            width = 10;
            height = 10;
            return true;
        }

        public override void AI()
        {
            projectile.rotation += (float)projectile.direction * 0.3f;
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
    }
}