using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Materials
{
    public class EnchantedShard : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.rare = 2;
            item.maxStack = 999;
            item.value = Item.sellPrice(0, 0, 1, 0);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Enchanted Shard");
            DisplayName.AddTranslation(GameCulture.Chinese, "附魔石碎片");
            DisplayName.AddTranslation(GameCulture.Russian, "Зачарованный осколок");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.EnchantedSword, 1);
            recipe.SetResult(this, 14);
            recipe.AddTile(16);
            recipe.AddRecipe();
        }
    }
}
