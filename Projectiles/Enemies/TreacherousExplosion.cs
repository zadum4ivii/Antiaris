using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Enemies
{
    public class TreacherousExplosion : ModProjectile
    {
        public override Color? GetAlpha(Color lightColor) { return Color.White; }

        public override void SetDefaults()
        {
            projectile.width = 112;
            projectile.height = 112;
            projectile.aiStyle = 0;
            projectile.alpha = 50;
            projectile.penetrate = -1;
            projectile.timeLeft = 22;
            projectile.tileCollide = false;
            projectile.hostile = true;
            projectile.netUpdate = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Treacherous Explosion");
            DisplayName.AddTranslation(GameCulture.Russian, "Коварный взрыв");
			DisplayName.AddTranslation(GameCulture.Chinese, "千瞬爆破");
            Main.projFrames[projectile.type] = 5;
        }

        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 10; k++)
            {
                int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y + 2f), projectile.width, projectile.height, DustID.GoldFlame, projectile.velocity.X * 0.2f, -6.0f, 100, new Color(), 1.0f);
                Main.dust[dust].noGravity = true;
            }
        }

        public override void AI()
        {
            projectile.frameCounter++;
            if (projectile.frameCounter >= 4) { projectile.frame++; projectile.frameCounter = 0; }
            if (projectile.frame >= 7) projectile.Kill();
        }
    }
}
