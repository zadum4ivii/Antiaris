using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Accessories
{
    public class Warbanner : ModBuff
    {
        private int MinionID = -1;

        private int MinionType = -1;

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Warbanner");
            Description.SetDefault("Protects your allies");
            DisplayName.AddTranslation(GameCulture.Russian, "Боевой флаг");
            Description.AddTranslation(GameCulture.Russian, "Защищает ваших союзников");
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.debuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (MinionType == -1)
			{
                MinionType = mod.ProjectileType("Warbanner");
			}		
            if (MinionID == -1 || Main.projectile[MinionID].type != MinionType || !Main.projectile[MinionID].active || Main.projectile[MinionID].owner != player.whoAmI)
            {
                Projectile proj = new Projectile();
                proj.SetDefaults(MinionType);
                MinionID = Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0, MinionType, proj.damage, proj.knockBack, player.whoAmI);
            }
            else
            {
                Main.projectile[MinionID].timeLeft = 5;
            }
        }
    }
}
