using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Placeables.Banners
{
    public class PurplePixieBanner : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 12;
            item.height = 28;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.rare = 1;
            item.value = Item.buyPrice(0, 0, 10, 0);
            item.createTile = mod.TileType("Banners");
            item.placeStyle = 17;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Purple Pixie Banner");
			Tooltip.SetDefault("Nearby players get a bonus against: Purple Pixie");
            DisplayName.AddTranslation(GameCulture.Russian, "Знамя фиолетовой пикси");
			Tooltip.AddTranslation(GameCulture.Russian, "Игроки поблизости получают бонус против: Фиолетовая пикси");
			DisplayName.AddTranslation(GameCulture.Chinese, "紫色小精灵旗");
			Tooltip.AddTranslation(GameCulture.Chinese, "附近的玩家针对以下情况获得奖励：紫色小精灵");
        }
    }
}
