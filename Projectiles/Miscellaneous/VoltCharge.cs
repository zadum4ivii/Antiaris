using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Miscellaneous
{
    public class VoltCharge : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.netImportant = true;
            projectile.width = 28;
            projectile.height = 58;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
			Main.projFrames[projectile.type] = 5;
			projectile.netImportant = true;
        }

        public override bool? CanCutTiles()
        { 
            return false; 
        }

        public override Color? GetAlpha(Color lightColor) { return Color.White; }

        public override void AI()
        {
			Player player = Main.player[projectile.owner];
			var aPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
			Vector2 vector;
			vector.X = player.Center.X - (float)(projectile.width / 2) - 8f;
			vector.Y = player.Center.Y + 15f - ((float)projectile.height * (player.breath < 200 ? 2 : 1)) + (float)(player.gfxOffY - 60.0);
			projectile.netUpdate = true;
			projectile.position = vector;
			projectile.position.X = (float)(int)projectile.position.X;
			projectile.position.Y = (float)(int)projectile.position.Y;
            projectile.frame = aPlayer.VoltCharge;
			if ((double)player.gravDir == -1.0)
			{
				projectile.position.Y += 120f;
				projectile.rotation = 3.14f;
			}
			else
				projectile.rotation = 0.0f;
        }
    }
}
