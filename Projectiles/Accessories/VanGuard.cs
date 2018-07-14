using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Accessories
{
    public class VanGuard : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.netImportant = true;
            projectile.width = 50;
            projectile.height = 36;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
			Main.projFrames[projectile.type] = 6;
			projectile.netImportant = true;
        }

        public override bool? CanCutTiles()
        { 
            return false; 
        }

        public override void AI()
        {
			Player player = Main.player[projectile.owner];
			Vector2 vector;
			vector.X = player.Center.X - (float)(projectile.width / 2);
			vector.Y = player.Center.Y - 35f - (float)projectile.height + (float)(player.gfxOffY - 65.0);
			projectile.netUpdate = true;
			projectile.position = vector;
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
