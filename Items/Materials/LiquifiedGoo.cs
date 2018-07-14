using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Materials
{
    public class LiquifiedGoo : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 22;
            item.rare = 2;
            item.maxStack = 999;
            item.value = Item.sellPrice(0, 0, 1, 0);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Liquified Goo");
            DisplayName.AddTranslation(GameCulture.Chinese, "液体凝胶");
            DisplayName.AddTranslation(GameCulture.Russian, "Жидкая слизь");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bottle, 3);
            recipe.AddIngredient(null, "GreenGoo");
            recipe.SetResult(this, 3);
            recipe.AddTile(17);
            recipe.AddRecipe();
        }
    }
}
