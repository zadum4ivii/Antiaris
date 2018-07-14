using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Vanity
{
    [AutoloadEquip(EquipType.Head)]
    public class TowerKeeperMask2 : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 26;
            item.rare = 1;
            item.vanity = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tower Keeper Mask");
            DisplayName.AddTranslation(GameCulture.Chinese, "守塔魔像面具");
            DisplayName.AddTranslation(GameCulture.Russian, "Маска Хранителя башни");
        }
	}
}