using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Melee.Swords
{
    public class CelestialMagic : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 28;
            projectile.height = 42;
            projectile.aiStyle = 0;
            aiType = 14;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            Main.projFrames[projectile.type] = 3;
            projectile.penetrate = 3;
            projectile.timeLeft = 33;
            projectile.tileCollide = false;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Celestial Flame");
            DisplayName.AddTranslation(GameCulture.Chinese, "神圣火焰");
            DisplayName.AddTranslation(GameCulture.Russian, "Небесное пламя");
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }

        public override void AI()
        {
            projectile.frameCounter++;
            if (projectile.frameCounter > 4)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame > 2)
            {
                projectile.frame = 0;
            }
            projectile.rotation = 0f;
            var dust = Dust.NewDust(new Vector2(projectile.position.X + 3f, projectile.position.Y + 3f) - projectile.velocity * 0.5f, projectile.width - 8, projectile.height - 8, 73, 0.0f, 0.0f, 100, new Color(), 1f);
            Main.dust[dust].scale *= (float)(1.39999997615814 + (double)Main.rand.Next(10) * 0.100000001490116);
            Main.dust[dust].velocity.Y -= 2f;
            Main.dust[dust].noGravity = true;
            projectile.velocity.Y += projectile.ai[0];
            var vector = projectile.velocity * 1.08f;
            projectile.velocity = vector;
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Projectiles/Explosion"), projectile.position);
            for (var i = 0; i < 15; ++i)
                Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y + 2f), projectile.width, projectile.height, 73, projectile.velocity.X * 0.24f, projectile.velocity.Y * 0.24f, 100, new Color(), 1.4f);
        }
    }
}
