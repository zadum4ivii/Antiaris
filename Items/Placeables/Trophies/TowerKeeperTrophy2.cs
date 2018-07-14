using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Placeables.Trophies
{
    public class TowerKeeperTrophy2 : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.rare = 1;
            item.value = Item.buyPrice(0, 1, 0, 0);
            item.createTile = mod.TileType("TowerKeeperTrophy2");
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tower Keeper Trophy");
            DisplayName.AddTranslation(GameCulture.Chinese, "守塔魔像荣誉之证");
            DisplayName.AddTranslation(GameCulture.Russian, "Трофей Хранителя башни");
			
        }
    }
}
