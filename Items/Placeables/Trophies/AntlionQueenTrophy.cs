using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Placeables.Trophies
{
    public class AntlionQueenTrophy : ModItem
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
            item.createTile = mod.TileType("AntlionQueenTrophy");
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Antlion Queen Trophy");
            DisplayName.AddTranslation(GameCulture.Chinese, "蚁后荣誉之证");
            DisplayName.AddTranslation(GameCulture.Russian, "Трофей Королевы муравьиных львов");
			
        }
    }
}
