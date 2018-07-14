using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Minions
{
    public class ParrotJunior : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Parrot Junior");
            Description.SetDefault("A parrot junior will fight for you");
            DisplayName.AddTranslation(GameCulture.Russian, "Маленький попугай");
            Description.AddTranslation(GameCulture.Russian, "Маленький попугай сражается за вас");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            AntiarisPlayer modPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
            if (player.ownedProjectileCounts[mod.ProjectileType("ParrotJunior")] > 0)
            {
                modPlayer.parrot = true;
            }
            if (!modPlayer.parrot)
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
