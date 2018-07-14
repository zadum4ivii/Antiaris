using Terraria;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.Projectiles.Ranged
{
    public class CrystalBullet : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 14;
            projectile.ranged = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 6;
            projectile.tileCollide = true;
        }

        public void OverhaulInit()
        {
            this.SetTag("bullet");
        }

        public override void Kill(int timeLeft)
        {
            Player player = Main.player[projectile.owner];
            Projectile.NewProjectile(projectile.Center.X + 25.0f, projectile.Center.Y, projectile.velocity.X, projectile.velocity.Y, (int)projectile.ai[0], (int)(32 * player.rangedDamage), 2.5f, projectile.owner, 0.0f, 0.0f);
            Projectile.NewProjectile(projectile.Center.X - 25.0f, projectile.Center.Y, projectile.velocity.X, projectile.velocity.Y, (int)projectile.ai[0], (int)(32 * player.rangedDamage), 2.5f, projectile.owner, 0.0f, 0.0f);
        }
    }
}
