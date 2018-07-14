using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Magic
{
    public class YinYangCentral : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 60;
            projectile.height = 60;
            projectile.aiStyle = 0;
            projectile.magic = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 10;
            projectile.tileCollide = false;
        }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            if (Main.myPlayer != projectile.owner)
                return;
            Vector2 vector;
            vector.X = Main.MouseWorld.X - 30f;
            vector.Y = Main.MouseWorld.Y - 30f;
            projectile.netUpdate = true;
            projectile.position = vector;
        }

        public override void Kill(int timeLeft)
        {
            Player player = Main.player[projectile.owner];
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 75.0f, 0.0f, 0.2f, mod.ProjectileType("YinYangMagic"), (int)(47 * player.magicDamage), 2.3f, projectile.owner, 0.0f, 0.0f);
            Projectile.NewProjectile(projectile.Center.X - 75.0f, projectile.Center.Y, 0.2f, 0.0f, mod.ProjectileType("YinYangMagic"), (int)(47 * player.magicDamage), 2.3f, projectile.owner, 0.0f, 0.0f);
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y + 75.0f, 0.0f, -0.2f, mod.ProjectileType("YinYangMagic"), (int)(47 * player.magicDamage), 2.3f, projectile.owner, 0.0f, 0.0f);
            Projectile.NewProjectile(projectile.Center.X + 75.0f, projectile.Center.Y, -0.2f, 0.0f, mod.ProjectileType("YinYangMagic"), (int)(47 * player.magicDamage), 2.3f, projectile.owner, 0.0f, 0.0f);
        }
    }
}
