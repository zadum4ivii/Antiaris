using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Ranged
{
    public class VortexExplosion : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 60;
            projectile.height = 84;
            projectile.friendly = true;
            Main.projFrames[projectile.type] = 6;
            projectile.tileCollide = false;
            projectile.penetrate = -1;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vortex Explosion");
            DisplayName.AddTranslation(GameCulture.Chinese, "星璇炸裂气流");
            DisplayName.AddTranslation(GameCulture.Russian, "Вихревой взрыв");
        }

        public override void AI()
        {
            projectile.rotation = 0f;
            projectile.frameCounter++;
            if (projectile.frameCounter > 2)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame > 6)
            {
                projectile.Kill();
            }
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
        }
    }
}
