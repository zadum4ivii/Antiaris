using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Materials
{
    public class BloodyChargedCrystal : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 22;
            item.rare = 4;
            item.maxStack = 999;
			item.value = Item.sellPrice(0, 0, 10, 0);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloody Charged Crystal");
            DisplayName.AddTranslation(GameCulture.Chinese, "蓄能血晶");
            DisplayName.AddTranslation(GameCulture.Russian, "Кровавый заряжённый кристалл");
        }
    }
}
