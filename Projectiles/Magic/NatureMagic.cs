	using Terraria;
	using Terraria.Localization;
	using Terraria.ModLoader;

namespace Antiaris.Projectiles.Magic
{
    public class NatureMagic : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 16;
            projectile.aiStyle = 43;
            aiType = 227;
			projectile.magic = true;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            Main.projFrames[projectile.type] = 5;
            projectile.penetrate = 1;
            projectile.timeLeft = 54;
            projectile.tileCollide = false;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nature Magic");
            DisplayName.AddTranslation(GameCulture.Chinese, "自然魔法");
            DisplayName.AddTranslation(GameCulture.Russian, "Магия природы");
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
            var vector = projectile.velocity * 1.08f;
            projectile.velocity = vector;
        }
    }
}
