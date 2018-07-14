using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Quests
{
    public class AdventurersFishingRod : QuestItem
    {
        public AdventurersFishingRod()
        {
            questItem = true;
            uniqueStack = true;
            maxStack = 1;
            rare = -11;
        }

        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 34;
			base.SetDefaults();
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Adventurer's Fishing Rod");
			Tooltip.SetDefault("'Unfortunately, you are not skilled enough to use it'");
            DisplayName.AddTranslation(GameCulture.Chinese, "冒险家鱼竿");
			Tooltip.AddTranslation(GameCulture.Chinese, "“遗憾的是，你没有足够的技术来使用它”");
            DisplayName.AddTranslation(GameCulture.Russian, "Удочка Путешественника");
			Tooltip.AddTranslation(GameCulture.Russian, "'Увы, вы не достаточно опытны, чтобы использовать её'");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "AdventurersFishingRodPart1");
			recipe.AddIngredient(null, "AdventurersFishingRodPart2");
			recipe.AddIngredient(null, "AdventurersFishingRodPart3");
            recipe.AddTile(18);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
