using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Potions
{
    public class ManaElixir : ModItem
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
			item.buffType = mod.BuffType("ManaElixir");
            item.buffTime = 7200;
            item.value = Item.sellPrice(0, 0, 1, 20);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mana Elixir");
            Tooltip.SetDefault("Increases maximum mana by 40");
            DisplayName.AddTranslation(GameCulture.Chinese, "魔力饮料");
            Tooltip.AddTranslation(GameCulture.Chinese, "魔力最大值提升 40");
            DisplayName.AddTranslation(GameCulture.Russian, "Эликсир маны");
            Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает максимальное количество маны на 40");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.GlowingMushroom);
            recipe.AddIngredient(ItemID.Moonglow);
            recipe.AddIngredient(ItemID.Blinkroot);
            recipe.SetResult(this);
            recipe.AddTile(13);
            recipe.AddRecipe();
        }
    }
}
