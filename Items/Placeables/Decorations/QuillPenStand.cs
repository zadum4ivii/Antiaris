using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Placeables.Decorations
{
    public class QuillPenStand : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 10;
            item.height = 26;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.rare = 1;
            item.value = Item.buyPrice(0, 0, 10, 0);
            item.createTile = mod.TileType("QuillPenStand");
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Quill-Pen Stand");
            DisplayName.AddTranslation(GameCulture.Chinese, "羽毛笔笔座");
            DisplayName.AddTranslation(GameCulture.Russian, "Перо на подставке");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IronBar, 2);
            recipe.anyIronBar = true;
            recipe.AddIngredient(ItemID.StoneBlock, 5);
            recipe.AddIngredient(ItemID.Feather, 1);
            recipe.SetResult(this);
            recipe.AddTile(18);
            recipe.AddRecipe();
        }
    }
}