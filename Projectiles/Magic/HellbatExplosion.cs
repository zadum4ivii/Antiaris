using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.Projectiles.Magic
{
    public class HellbatExplosion : ModProjectile
    {
        public override Color? GetAlpha(Color lightColor) { return Color.White; }

        public override void SetDefaults()
        {
            projectile.width = 82;
            projectile.height = 56;
            projectile.friendly = true;
            projectile.magic = true;
			projectile.penetrate = -1;
			projectile.tileCollide = false;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hellbat Explosion");
			DisplayName.AddTranslation(GameCulture.Chinese, "地狱蝙蝠爆炸");
            DisplayName.AddTranslation(GameCulture.Russian, "Взрыв адской летучей мыши");
			Main.projFrames[projectile.type] = 9;
        }

        public void OverhaulInit()
        {
            this.SetTag("incendiary");
            this.SetTag("incendiarySlow");
        }

        public override void AI()
        {
            projectile.rotation = 0.0f;
			projectile.frameCounter++;
            if (projectile.frameCounter >= 4) { projectile.frame++; projectile.frameCounter = 0; }
            if (projectile.frame >= 8) projectile.Kill();
        }

        public override void Kill(int timeLeft) { Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 74); }
    }
}
