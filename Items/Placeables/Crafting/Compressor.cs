using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Placeables.Crafting
{
    public class Compressor : ModItem
    {
        public override void SetDefaults()
		{
			item.width = 36;
			item.height = 42;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.rare = 1;
			item.value = Item.sellPrice(0, 2, 0, 0);
			item.createTile = mod.TileType("Compressor");
		}

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Compressor");
            DisplayName.AddTranslation(GameCulture.Chinese, "压缩器");
            DisplayName.AddTranslation(GameCulture.Russian, "Компрессор");
        }
    }
}
