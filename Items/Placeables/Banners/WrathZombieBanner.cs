﻿using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Placeables.Banners
{
    public class WrathZombieBanner : ModItem
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
            item.placeStyle = 4;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wrath Zombie Banner");
			Tooltip.SetDefault("Nearby players get a bonus against: Wrath Zombie");
            DisplayName.AddTranslation(GameCulture.Chinese, "狂怒丧尸旗");
			Tooltip.AddTranslation(GameCulture.Chinese, "附近的玩家针对以下情况获得奖励：狂怒丧尸");
            DisplayName.AddTranslation(GameCulture.Russian, "Знамя яростного зомби");
			Tooltip.AddTranslation(GameCulture.Russian, "Игроки поблизости получают бонус против: Яростный зомби");
        }
    }
}
