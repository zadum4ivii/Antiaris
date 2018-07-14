using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Melee.Spears
{
    public class TerraSpearPro : ModProjectile
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
            projectile.penetrate = 4;
            projectile.light = 0.5f;
            projectile.timeLeft = 80;
            projectile.tileCollide = false;
            aiType = 132;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Terra Spear");
			DisplayName.AddTranslation(GameCulture.Chinese, "泰拉长枪");
            DisplayName.AddTranslation(GameCulture.Russian, "Терра Копье");
        }

        public override void AI()
        {
            ++projectile.ai[1];
            if ((double)projectile.ai[1] % 10.0 == 0.0) Projectile.NewProjectile(projectile.position, Vector2.Zero, mod.ProjectileType("TerraSpearOrb"), projectile.damage, (int)(projectile.knockBack * 0.7f), projectile.owner);
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
