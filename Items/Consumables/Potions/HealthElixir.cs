using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Potions
{
    public class HealthElixir : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 28;
            item.maxStack = 30;
            item.rare = 1;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useStyle = 2;
            item.UseSound = SoundID.Item3;
            item.consumable = true;
			item.buffType = mod.BuffType("HealthElixir");
            item.buffTime = 7200;
            item.value = Item.sellPrice(0, 0, 1, 20);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Health Elixir");
            Tooltip.SetDefault("Increases maximum health by 30");
            DisplayName.AddTranslation(GameCulture.Chinese, "益寿饮料");
            Tooltip.AddTranslation(GameCulture.Chinese, "生命最大值提升 30，益寿又延年~");
            DisplayName.AddTranslation(GameCulture.Russian, "Эликсир здоровья");
            Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает максимальное здоровье на 30");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.GlowingMushroom);
            recipe.AddIngredient(ItemID.Daybloom);
            recipe.AddIngredient(ItemID.Blinkroot);
            recipe.SetResult(this);
            recipe.AddTile(13);
            recipe.AddRecipe();
        }
    }
}
