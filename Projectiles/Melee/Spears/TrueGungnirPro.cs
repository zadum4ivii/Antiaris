using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Melee.Spears
{
    public class TrueGungnirPro : ModProjectile
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
            projectile.aiStyle = 27;
            projectile.scale = 1.0f;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.penetrate = 2;
            projectile.timeLeft = 146;
            projectile.tileCollide = false;
            aiType = 156;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Gungnir");
			DisplayName.AddTranslation(GameCulture.Chinese, "真·永恒之枪");
            DisplayName.AddTranslation(GameCulture.Russian, "Истинный Гунгнир");
        }

        public override void AI()
        {
            Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 1.0f) / 255f, ((255 - projectile.alpha) * 0.2f) / 255f, ((255 - projectile.alpha) * 0.4f) / 255f);
            Vector2 vector2 = projectile.velocity * 0.9995f;
            projectile.velocity = vector2;
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 34);
            for (int k = 0; k < 16; k++)
            {
                int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 73, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, new Color(), 1f);
                Main.dust[dust].noGravity = true;
            }
        }
    }
}
