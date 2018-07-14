using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Placeables.Decorations
{
	public class Mailbox : ModItem
	{
	    public override void SetDefaults()
        {
            item.width = 24;
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
            item.createTile = mod.TileType("Mailbox");
        }

	    public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mailbox");
            DisplayName.AddTranslation(GameCulture.Chinese, "信箱");
            DisplayName.AddTranslation(GameCulture.Russian, "Почтовый ящик");
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
