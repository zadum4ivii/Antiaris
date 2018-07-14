using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Placeables.Decorations
{
    public class TV : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 36;
            item.height = 32;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.rare = 1;
            item.value = Item.buyPrice(0, 0, 10, 0);
            item.createTile = mod.TileType("TV");
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("TV");
            DisplayName.AddTranslation(GameCulture.Chinese, "电视机");
            DisplayName.AddTranslation(GameCulture.Russian, "Телевизор");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IronBar, 12);
            recipe.anyIronBar = true;
            recipe.AddIngredient(ItemID.Glass, 10);
            recipe.AddIngredient(ItemID.Wire, 6);
            recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.AddRecipe();
        }
    }
}
