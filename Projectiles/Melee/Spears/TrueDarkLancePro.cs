using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Melee.Spears
{
    public class TrueDarkLancePro : ModProjectile
    {
        public override Color? GetAlpha(Color lightColor)
        {
            if ((double)projectile.localAI[1] >= 15.0)
                return new Color(255, 255, 255, projectile.alpha);
            if ((double)projectile.localAI[1] < 5.0)
                return Color.Transparent;
            int color = (int)(((double)projectile.localAI[1] - 5.0) / 10.0 * 255);
            return new Color(color, color, color, color);
        }

        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.scale = 1.0f;
            projectile.aiStyle = 27;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.penetrate = 2;
            projectile.timeLeft = 178;
            projectile.tileCollide = false;
            aiType = 156;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Dark Lance");
			DisplayName.AddTranslation(GameCulture.Chinese, "真·暗黑长戟");
            DisplayName.AddTranslation(GameCulture.Russian, "Истинная Тёмная пика");
        }

        public override void AI()
        {
            Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.2f) / 255f, ((255 - projectile.alpha) * 0.9f) / 255f, ((255 - projectile.alpha) * 0.1f) / 255f);
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 34);
            for (int k = 0; k < 16; k++)
            {
                int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 107, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, new Color(), 1f);
                Main.dust[dust].noGravity = true;
            }
        }
    }
}
