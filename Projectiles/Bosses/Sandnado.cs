using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Bosses
{
    public class Sandnado : ModProjectile
    {
        public override void SetDefaults()
        {
            Main.projFrames[projectile.type] = 4;
            projectile.width = 142;
            projectile.height = 206;
            projectile.aiStyle = -1;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.tileCollide = false;
            projectile.penetrate = -1;
            projectile.timeLeft = 640;
            projectile.extraUpdates = 1;
            projectile.alpha = 255;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sandnado");
            DisplayName.AddTranslation(GameCulture.Chinese, "沙暴");
            DisplayName.AddTranslation(GameCulture.Russian, "Песчанное торнадо");
        }

        public override void AI()
        {
            Player owner = null;
            if (projectile.owner != -1)
            {
                owner = Main.player[projectile.owner];
            }
            else if (projectile.owner == 255)
            {
                owner = Main.LocalPlayer;
            }
            var player = owner;
            projectile.alpha--;
            projectile.frameCounter++;
            projectile.rotation = 0f;
            if (projectile.frameCounter > 2)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame >= 4)
            {
                projectile.frame = 0;
            }
            if (projectile.Hitbox.Intersects(player.Hitbox))
            {
                player.velocity.Y -= 0.65f;
            }
        }

        public override void Kill(int timeLeft)
        {
            for (var k = 0; k < 25; k++)
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Sandstorm"), projectile.oldVelocity.X * 0.2f, projectile.oldVelocity.Y * 0.2f);
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
        }
    }
}
