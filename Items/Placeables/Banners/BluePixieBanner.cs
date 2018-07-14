using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Placeables.Banners
{
    public class BluePixieBanner : ModItem
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
            item.placeStyle = 15;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blue Pixie Banner");
			Tooltip.SetDefault("Nearby players get a bonus against: Blue Pixie");
            DisplayName.AddTranslation(GameCulture.Russian, "Знамя голубой пикси");
			Tooltip.AddTranslation(GameCulture.Russian, "Игроки поблизости получают бонус против: Голубая пикси");
			DisplayName.AddTranslation(GameCulture.Chinese, "蓝色小精灵旗");
			Tooltip.AddTranslation(GameCulture.Chinese, "附近的玩家针对以下情况获得奖励：蓝色小精灵");
        }
    }
}
