using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Placeables
{
    public class SunkenChest : ModItem
    {
        public override void SetDefaults()
		{
			item.width = 32;
			item.height = 28;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 500;
			item.createTile = mod.TileType("SunkenChest");
		}

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sunken Chest");
            DisplayName.AddTranslation(GameCulture.Chinese, "沉没的箱子");
            DisplayName.AddTranslation(GameCulture.Russian, "Затонувший сундук");
        }
    }
}
