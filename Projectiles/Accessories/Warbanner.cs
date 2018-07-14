using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Accessories
{
    public class Warbanner : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 26;
            projectile.height = 42;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.netImportant = true;
            Main.projFrames[projectile.type] = 6;
            projectile.timeLeft = 6;
            projectile.extraUpdates = 1;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 9;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

        public override bool? CanCutTiles()
        { 
            return false; 
        }

        public override void AI()
        {
			Player player = Main.player[projectile.owner];
            Vector2 vector;
			vector.X = player.Center.X - (float)(projectile.width - 20);
			if(player.direction == 1)
			{
				vector.X = player.Center.X - (float)(projectile.width);
			}
            vector.Y = player.MountedCenter.Y + 15f + (float)(player.gfxOffY - 65.0);
			projectile.netUpdate = true;
            projectile.position = vector;
            projectile.direction = (projectile.spriteDirection = player.direction);
			projectile.position.X = (float)(int)projectile.position.X;
			projectile.position.Y = (float)(int)projectile.position.Y;
            if ((double)player.gravDir == -1.0)
			{
				projectile.position.Y += 120f;
				projectile.rotation = 3.14f;
			}
			else
				projectile.rotation = 0.0f;
            if (player.team > 0)
            {
                projectile.frame = player.team;
            }
            if (player.team <= 0)
            {
                projectile.frame = 0;
            }
        }
    }
}