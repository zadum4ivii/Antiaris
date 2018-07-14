using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Magic
{
    public class CursedRay : ModProjectile
    {
        private float timer = 0;

        public override void SetDefaults()
        {
            projectile.width = 6;
            projectile.height = 6;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.tileCollide = false;
            projectile.penetrate = -1;
            projectile.extraUpdates = 100;
            projectile.timeLeft = 100;
            projectile.alpha = 255;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cursed Ray");
            DisplayName.AddTranslation(GameCulture.Chinese, "诅咒火射线");
            DisplayName.AddTranslation(GameCulture.Russian, "Проклятый луч");
        }

        public override void AI()
        {
        	if (projectile.velocity.X != projectile.velocity.X)
			{
				projectile.position.X = projectile.position.X + projectile.velocity.X;
				projectile.velocity.X = -projectile.velocity.X;
			}
			if (projectile.velocity.Y != projectile.velocity.Y)
			{
				projectile.position.Y = projectile.position.Y + projectile.velocity.Y;
				projectile.velocity.Y = -projectile.velocity.Y;
			}
            timer += 1f;
			if (timer > 9f)
			{
				for (int k = 0; k < 1; k++)
				{
                    projectile.position -= projectile.velocity * ((float)k * 0.25f);
					var dust = Dust.NewDustDirect(projectile.position, 1, 1, mod.DustType("CursedRay"), 0f, 0f, 200, Scale: 1.55f);
                    dust.position = projectile.position;
                    dust.velocity *= 0.1f;
					dust.noGravity = true;
				}
				return;
			}
        }
    }
}