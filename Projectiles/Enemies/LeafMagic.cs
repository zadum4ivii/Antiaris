using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Enemies
{
    public class LeafMagic : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 16;
            projectile.aiStyle = 43;
            aiType = 227;
            projectile.friendly = false;
            projectile.ignoreWater = true;
            Main.projFrames[projectile.type] = 5;
            projectile.penetrate = 1;
            projectile.timeLeft = 180;
            projectile.tileCollide = false;
            projectile.hostile = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Leaf Magic");
            DisplayName.AddTranslation(GameCulture.Chinese, "魔力树叶");
            DisplayName.AddTranslation(GameCulture.Russian, "Лиственная магия");
			DisplayName.AddTranslation(GameCulture.Italian, "Foglia magica");
        }

        public override void AI()
        {
            projectile.frameCounter++;
            if (projectile.frameCounter > 8)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame > 4)
            {
                projectile.frame = 0;
            }
            Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.025f) / 255f, ((255 - projectile.alpha) * 0.25f) / 255f, ((255 - projectile.alpha) * 0.05f) / 255f);
            projectile.velocity.Y += projectile.ai[0];
        }
    }
}
