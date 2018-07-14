using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Accessories
{
    public class Shield : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.netImportant = true;
            projectile.width = 50;
            projectile.height = 58;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
			Main.projFrames[projectile.type] = 1;
        }

        public override bool? CanCutTiles()
        { 
            return false; 
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White * 0.4f;
        }

        public override void AI()
        {
			Player player = Main.player[projectile.owner];
			var aPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
			Vector2 vector;
			vector.X = player.Center.X - (float)(projectile.width / 2);
			vector.Y = player.Center.Y + 30f + (float)(player.gfxOffY - 60.0);
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
            if (!player.GetModPlayer<AntiarisPlayer>(mod).mirrorShield) projectile.Kill();
            Rectangle projectileRec = new Rectangle((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height);
            foreach (var proj in Main.projectile)
            {
                Rectangle projRec = new Rectangle((int)proj.position.X, (int)proj.position.Y, proj.width, proj.height);
                if (projectileRec.Intersects(projRec) && !proj.friendly && projectile.hostile)
                {
                    projectile.velocity.X = -projectile.velocity.X;
                    projectile.velocity.Y = -projectile.velocity.Y;
                    projectile.friendly = true;
                }
            }
        }
    }
}
