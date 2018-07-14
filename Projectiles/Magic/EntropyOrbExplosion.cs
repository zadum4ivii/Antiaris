using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Magic
{
    public class EntropyOrbExplosion : ModProjectile
    {
        public override Color? GetAlpha(Color lightColor) { return Color.White; }

        public override void SetDefaults()
        {
            projectile.width = 56;
            projectile.height = 56;
            projectile.friendly = true;
            projectile.magic = true;
			projectile.penetrate = -1;
			projectile.tileCollide = false;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Entropy Explosion");
			DisplayName.AddTranslation(GameCulture.Chinese, "无序爆破");
            DisplayName.AddTranslation(GameCulture.Russian, "Взрыв Энтропии");
			Main.projFrames[projectile.type] = 8;
        }

        public override void AI()
        {
			projectile.scale = projectile.ai[0];
            projectile.rotation = 0.0f;
			projectile.frameCounter++;
            if (projectile.frameCounter >= 4) { projectile.frame++; projectile.frameCounter = 0; }
            if (projectile.frame >= 7) projectile.Kill();
        }

        public override void Kill(int timeLeft) { Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 54); }
    }
}
