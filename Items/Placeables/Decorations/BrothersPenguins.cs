using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Placeables.Decorations
{
    public class BrothersPenguins : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 30;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.rare = 0;
            item.value = Item.buyPrice(0, 0, 2, 0);
            item.createTile = mod.TileType("BrothersPenguins");
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Brothers Penguins");
			Tooltip.SetDefault("M. Pet");
            DisplayName.AddTranslation(GameCulture.Russian, "Братья-пингвины");
			Tooltip.AddTranslation(GameCulture.Russian, "М. Пет");
            DisplayName.AddTranslation(GameCulture.Chinese, "企鹅兄弟");
			Tooltip.AddTranslation(GameCulture.Chinese, "M.Pet");
        }
    }
}