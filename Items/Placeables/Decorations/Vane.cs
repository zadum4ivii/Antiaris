using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Placeables.Decorations
{
    public class Vane : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 36;
            item.height = 48;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.rare = 1;
            item.value = Item.buyPrice(0, 0, 10, 0);
            item.createTile = mod.TileType("Vane");
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vane");
            DisplayName.AddTranslation(GameCulture.Chinese, "风向标");
            DisplayName.AddTranslation(GameCulture.Russian, "Флюгер");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IronBar, 15);
            recipe.anyIronBar = true;
            recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.AddRecipe();
        }
    }
}
