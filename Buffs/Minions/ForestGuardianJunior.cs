using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Minions
{
    public class ForestGuardianJunior : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Forest Guardian Junior");
            Description.SetDefault("A forest guardian junior will fight for you");
            DisplayName.AddTranslation(GameCulture.Russian, "Младший страж леса");
            Description.AddTranslation(GameCulture.Russian, "Младший страж леса сражается за вас");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            AntiarisPlayer modPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
            if (player.ownedProjectileCounts[mod.ProjectileType("ForestGuardianJunior")] > 0)
            {
                modPlayer.forestGuardianJunior = true;
            }
            if (!modPlayer.forestGuardianJunior)
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
            else
            {
                player.buffTime[buffIndex] = 18000;
            }
        }
    }
}
