using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Placeables.Decorations
{
    public class Fridge : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 38;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.rare = 1;
            item.value = Item.buyPrice(0, 0, 10, 0);
            item.createTile = mod.TileType("Fridge");
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fridge");
            DisplayName.AddTranslation(GameCulture.Chinese, "冰箱");
            DisplayName.AddTranslation(GameCulture.Russian, "Холодильник");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IronBar, 12);
            recipe.anyIronBar = true;
            recipe.AddIngredient(ItemID.Wire, 20);
            recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.AddRecipe();
        }
    }
}