using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.Items.Materials
{
    public class BlunderbussBase : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 70;
            item.height = 18;
            item.rare = 0;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blunderbuss Base");
            Tooltip.SetDefault("Used to make blunderbusses");
            DisplayName.AddTranslation(GameCulture.Chinese, "火铳框架");
            Tooltip.AddTranslation(GameCulture.Chinese, "用于制造火铳");
            DisplayName.AddTranslation(GameCulture.Russian, "Основа мушкетона");
            Tooltip.AddTranslation(GameCulture.Russian, "Используется для создания мушкетонов");
        }

        public void OverhaulInit()
        {
            this.SetTag("flammable");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 20);
            recipe.SetResult(this);
            recipe.AddTile(18);
            recipe.AddRecipe();
        }
    }
}
