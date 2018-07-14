using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Potions
{
    public class LeapingPotion : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 36;
            item.maxStack = 30;
            item.rare = 1;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useStyle = 2;
            item.UseSound = SoundID.Item3;
            item.consumable = true;
			item.buffType = mod.BuffType("LeapingPotion");
            item.buffTime = 7200;
            item.value = Item.sellPrice(0, 0, 2, 0);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Leaping Potion");
            Tooltip.SetDefault("Increases jump height\nAllows auto-jump");
            DisplayName.AddTranslation(GameCulture.Chinese, "跃进药水");
            Tooltip.AddTranslation(GameCulture.Chinese, "1、自身可以跳得更高\n2、按住空格键允许进行连续跳跃");
            DisplayName.AddTranslation(GameCulture.Russian, "Зелье прыгучести");
            Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает высоту прыжка\nПозволяет автоматически прыгать");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BottledWater, 1);
            recipe.AddIngredient(ItemID.Frog, 1);
            recipe.AddIngredient(ItemID.Waterleaf, 1);
            recipe.AddIngredient(ItemID.Moonglow, 1);
            recipe.SetResult(this);
            recipe.AddTile(13);
            recipe.AddRecipe();
        }
    }
}
