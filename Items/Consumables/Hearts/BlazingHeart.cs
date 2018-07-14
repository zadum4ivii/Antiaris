using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Hearts
{
    public class BlazingHeart : ModItem
    {
        public override void SetDefaults()
        {
            item.maxStack = 99;
            item.width = 22;
            item.height = 22;
            item.useStyle = 4;
            item.useTime = 30;
            item.useAnimation = 30;
            item.UseSound = SoundID.Item4;
            item.consumable = true;
            item.rare = 3;
            item.value = Item.sellPrice(0, 1, 70, 0);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blazing Heart");
            Tooltip.SetDefault("Permanently increases maximum life by 10");
            DisplayName.AddTranslation(GameCulture.Russian, "Пылающее сердце");
            Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает максимальное количество жизней на 10");
            DisplayName.AddTranslation(GameCulture.Chinese, "燃烧之心");
            Tooltip.AddTranslation(GameCulture.Chinese, "增加10点最大生命值");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HellstoneBar, 8);
			recipe.AddIngredient(ItemID.LifeCrystal, 1);
            recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.AddRecipe();
        }
    }
}
