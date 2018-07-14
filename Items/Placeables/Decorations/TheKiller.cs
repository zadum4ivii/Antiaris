using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Placeables.Decorations
{
    public class TheKiller : ModItem
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
            item.createTile = mod.TileType("TheKiller");
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Killer");
			Tooltip.SetDefault("H. Ara");
            DisplayName.AddTranslation(GameCulture.Russian, "Убийца");
			Tooltip.AddTranslation(GameCulture.Russian, "Х. Ара");
            DisplayName.AddTranslation(GameCulture.Chinese, "The Killer");
			Tooltip.AddTranslation(GameCulture.Chinese, "H. Ara");
        }
    }
}