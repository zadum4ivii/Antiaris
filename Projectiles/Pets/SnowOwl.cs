using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Pets
{
    public class SnowOwl : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.Parrot);
			aiType = ProjectileID.Parrot;
            projectile.width = 36;
            projectile.height = 36;
			Main.projPet[projectile.type] = true;
			Main.projFrames[projectile.type] = 5;
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
            var flag = projectile.type == mod.ProjectileType("SnowOwl");
            var modPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
            if (flag)
            {
                if (player.dead)
                {
                    modPlayer.snowOwl = false;
                }
                if (modPlayer.snowOwl)
                {
                    projectile.timeLeft = 2;
                }
            } 
		}
    }
}