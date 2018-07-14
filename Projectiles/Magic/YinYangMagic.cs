using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Magic
{
    public class YinYangMagic : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 8;
            projectile.friendly = true;
            projectile.aiStyle = 1;
            projectile.penetrate = -1;
            projectile.timeLeft = 54;
            projectile.magic = true;
            projectile.extraUpdates = 1;
            aiType = ProjectileID.Bullet;
            projectile.tileCollide = false;
        }

        public override void AI()
        {
            Vector2 vector = projectile.velocity * 1.08f;
            projectile.velocity = vector;
            Player player = Main.player[projectile.owner];
            if ((double)projectile.ai[0] == 0.0)
            {
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0.0f, 0.0f, mod.ProjectileType("YinYangBlackM"), (int)(47 * player.magicDamage), 2.3f, projectile.owner, projectile.whoAmI, 0.0f);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0.0f, 0.0f, mod.ProjectileType("YinYangWhiteM"), (int)(47 * player.magicDamage), 2.3f, projectile.owner, projectile.whoAmI, 0.0f);
                projectile.ai[0] = 1.0f;
                projectile.netUpdate = true;
            }
        }
    }
}
