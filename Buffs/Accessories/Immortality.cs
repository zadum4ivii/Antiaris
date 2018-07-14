using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Accessories
{
    public class Immortality : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("[c/00FF7F:Immortality]");
            Description.SetDefault("Reduces damage taken by 100%");
            DisplayName.AddTranslation(GameCulture.Russian, "[c/00FF7F:Бессмертие]");
            Description.AddTranslation(GameCulture.Russian, "Снижает получаемый урон на 100%");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.endurance += 1f;
        }
    }
}