using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Placeables.Banners
{
    public class GreenPixieBanner : ModItem
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
            item.placeStyle = 16;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Green Pixie Banner");
			Tooltip.SetDefault("Nearby players get a bonus against: Green Pixie");
            DisplayName.AddTranslation(GameCulture.Russian, "Знамя зелёной пикси");
			Tooltip.AddTranslation(GameCulture.Russian, "Игроки поблизости получают бонус против: Зелёная пикси");
			DisplayName.AddTranslation(GameCulture.Chinese, "绿色小精灵旗");
			Tooltip.AddTranslation(GameCulture.Chinese, "附近的玩家针对以下情况获得奖励：绿色小精灵");
        }
    }
}
