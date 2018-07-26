using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Ranged
{
    public class LeafBush : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 56;
            projectile.height = 40;
            projectile.friendly = true;
            Main.projFrames[projectile.type] = 10;
            projectile.ranged = true;
            projectile.penetrate = 8;
            projectile.aiStyle = 92;
            projectile.friendly = true;
            projectile.timeLeft = 90;
            projectile.alpha = 100;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Leaf Bush");
            DisplayName.AddTranslation(GameCulture.Chinese, "灌木丛");
            DisplayName.AddTranslation(GameCulture.Russian, "Лиственный куст");
        }

        public override void AI()
        {
            projectile.rotation = 0f;
            projectile.frameCounter++;
            if (projectile.frameCounter > 8 && projectile.frame < 10)
            {
                projectile.frame++;
                projectile.frameCounter = 1;
            }
			if(projectile.frame >= 10)
			{
				projectile.Kill();
			}
        }
    }
}
