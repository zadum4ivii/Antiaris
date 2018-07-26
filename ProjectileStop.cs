using Terraria;
using Terraria.ModLoader;

namespace Antiaris
{	
	class ProjectileStop : GlobalProjectile
    {
        private int ProjDamage;
        public int Tick;

        public override bool InstancePerEntity
        {
            get { return true; }
        }

        public override bool PreAI(Projectile projectile)
        {
			var player = Main.player[Main.myPlayer];
			Tick++;
			if(projectile.damage != 0)
			{
				ProjDamage = projectile.damage;
			}
            if(AntiarisWorld.frozenTime && Tick >= 4 && projectile.aiStyle != 19 && projectile.aiStyle != 20 && projectile.aiStyle != 7 && projectile.aiStyle != 99 && projectile.aiStyle != 75 && projectile.aiStyle != 13 && projectile.aiStyle != 140 && projectile.aiStyle != 142 && !projectile.minion && projectile.type != mod.ProjectileType("Warbanner") && projectile.type != mod.ProjectileType("Vanguard") && projectile.type != mod.ProjectileType("VoltCharge"))
            {
				projectile.timeLeft++;
				if(!projectile.friendly && projectile.aiStyle != 113)
				{
					projectile.damage = 0;
				}
				return false;
            }
            else
            {
				if(!projectile.friendly && projectile.damage != ProjDamage && projectile.aiStyle != 19 && projectile.aiStyle != 20 && projectile.aiStyle != 7 && projectile.aiStyle != 99 && projectile.aiStyle != 75 && projectile.aiStyle != 13 && projectile.aiStyle != 140 && projectile.aiStyle != 142 && !projectile.minion && projectile.type != mod.ProjectileType("Warbanner") && projectile.type != mod.ProjectileType("Vanguard") && projectile.type != mod.ProjectileType("VoltCharge"))
				{
					projectile.damage = ProjDamage;
				}
                return true;
            }
        }

        public override bool ShouldUpdatePosition(Projectile projectile)
        {
			var player = Main.player[Main.myPlayer];
            if(AntiarisWorld.frozenTime && projectile.aiStyle != 19 && projectile.aiStyle != 20 && projectile.aiStyle != 7 && projectile.aiStyle != 99 && projectile.aiStyle != 75 && projectile.aiStyle != 13 && projectile.aiStyle != 140 && projectile.aiStyle != 142 && !projectile.minion && projectile.type != mod.ProjectileType("Warbanner") && projectile.type != mod.ProjectileType("Vanguard") && projectile.type != mod.ProjectileType("VoltCharge"))
            {
                return false;
            }
            else
            {
                return true;
            }
            return true;
        }
    }
}