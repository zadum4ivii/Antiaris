using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Placeables.Decorations
{
    public class Cabinet : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.rare = 1;
            item.value = Item.buyPrice(0, 0, 0, 50);
            item.createTile = mod.TileType("Cabinet");
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cabinet");
            DisplayName.AddTranslation(GameCulture.Russian, "Шкаф");
            DisplayName.AddTranslation(GameCulture.Chinese, "柜橱");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 14);
            recipe.SetResult(this);
            recipe.AddTile(106);
            recipe.AddRecipe();
        }
    }
}