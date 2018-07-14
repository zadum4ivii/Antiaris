using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Melee.Swords
{
    public class YinYang : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 8;
            projectile.friendly = true;
            projectile.aiStyle = 1;
            projectile.penetrate = -1;
            projectile.timeLeft = 260;
            projectile.extraUpdates = 1;
            aiType = ProjectileID.Bullet;
            projectile.tileCollide = false;
        }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            if ((double)projectile.ai[0] == 0.0)
            {
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0.0f, 0.0f, mod.ProjectileType("YinYangBlack"), (int)(34 * (double)player.meleeDamage), 4.4f, projectile.owner, projectile.whoAmI, 0.0f);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0.0f, 0.0f, mod.ProjectileType("YinYangWhite"), (int)(34 * (double)player.meleeDamage), 4.4f, projectile.owner, projectile.whoAmI, 0.0f);
                projectile.ai[0] = 1.0f;
                projectile.netUpdate = true;
            }
        }
    }
}
