using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.Projectiles.Melee.Swords
{
    public class SolarFlameExplosion : ModProjectile
    {
        public override void SetDefaults()
        {
			projectile.width = 88;
			projectile.height = 88;
            projectile.friendly = true;
            Main.projFrames[projectile.type] = 10;
			projectile.tileCollide = false;
			projectile.penetrate = -1;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Solar Flame Explosion");
            DisplayName.AddTranslation(GameCulture.Chinese, "日曜炙焰爆炸");
            DisplayName.AddTranslation(GameCulture.Russian, "Взрыв солнечной вспышки");
        }

        public void OverhaulInit()
        {
            this.SetTag("explosive");
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        { 
            target.AddBuff(24, 300, false);
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
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
            if (projectile.frame > 11)
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
