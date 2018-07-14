using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Quests
{
    public class GoldenApple : QuestItem
    {
        public GoldenApple()
        {
            questItem = true;
            uniqueStack = true;
            maxStack = 1;
            rare = -11;
        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 30;
			base.SetDefaults();
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Golden Apple");
            DisplayName.AddTranslation(GameCulture.Chinese, "金苹果");
            DisplayName.AddTranslation(GameCulture.Russian, "Золотое яблоко");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GoldCoin, 20);
            recipe.AddIngredient(null, "Apple", 1);
            recipe.SetResult(this);
            recipe.AddTile(TileID.Anvils);
            recipe.AddRecipe();
        }
    }
}
