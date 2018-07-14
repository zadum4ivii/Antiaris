using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Thrown
{
    public class MagmaBomb : ModProjectile
    {
        public override Color? GetAlpha(Color lightColor) { return Color.White; }

        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.aiStyle = -1;
			projectile.penetrate = -1;
            projectile.timeLeft = 55;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Magma Bomb");
            DisplayName.AddTranslation(GameCulture.Russian, "Магмовая бомба");
			DisplayName.AddTranslation(GameCulture.Chinese, "熔岩炸弹");
			Main.projFrames[projectile.type] = 3;
        }


        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            if (targetHitbox.Width > 20 && targetHitbox.Height > 20) {
                targetHitbox.Inflate(-targetHitbox.Width / 20, -targetHitbox.Height / 20); }
            return projHitbox.Intersects(targetHitbox);
        }

        public override void AI()
        {
			projectile.direction = 1;
            projectile.scale += 0.005f;
            int projTargetIndex = (int)projectile.ai[0];
            projectile.Center = Main.npc[projTargetIndex].Center - projectile.velocity * 2.0f;
            if (!Main.npc[projTargetIndex].active) projectile.Kill();
            projectile.gfxOffY = Main.npc[projTargetIndex].gfxOffY;
            projectile.frameCounter++;
            if (projectile.frameCounter >= 8) { projectile.frame++; projectile.frameCounter = 0; }
            if (projectile.frame >= (int)Main.projFrames[projectile.type]) projectile.frame = 0;
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
            for (int l = 0; l < 40; l++)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, 0.0f, -2.0f, 0, new Color(), 3.2f);
                Main.dust[dust].noGravity = true;
                Dust dust1 = Main.dust[dust];
                dust1.position.X = dust1.position.X + ((float)(Main.rand.Next(-50, 51) / 20) - 1.5f);
                Dust dust2 = Main.dust[dust];
                dust2.position.Y = dust2.position.Y + ((float)(Main.rand.Next(-50, 51) / 20) - 1.5f);
                if (Main.dust[dust].position != projectile.Center) Main.dust[dust].velocity = projectile.DirectionTo(Main.dust[dust].position) * 2.0f;
            }
        }
    }
}
