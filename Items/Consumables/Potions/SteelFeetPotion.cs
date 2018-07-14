using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Potions
{
    public class SteelFeetPotion : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 24;
            item.useTurn = true;
            item.maxStack = 30;
            item.rare = 1;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useStyle = 2;
            item.buffType = mod.BuffType("SteelFeetPotion");
            item.buffTime = 18000;
            item.UseSound = SoundID.Item3;
            item.consumable = true;
            item.value = Item.sellPrice(0, 0, 2, 0);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Steel Feet Potion");
            Tooltip.SetDefault("Increases height at which you take damage from falling\nReduces fall damage");
            DisplayName.AddTranslation(GameCulture.Chinese, "钢踵药水");
            Tooltip.AddTranslation(GameCulture.Chinese, "1、坠落伤害所需要的高度上升\n2、减少你承受的坠落伤害");
            DisplayName.AddTranslation(GameCulture.Russian, "Зелье стальных пят");
            Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает высоту, с которой вы получаете урон от падения\nУменьшает урон от падения");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater, 1);
            recipe.AddIngredient(ItemID.IronBar, 5);
			recipe.anyIronBar = true;
            recipe.AddIngredient(ItemID.Waterleaf, 3);
            recipe.SetResult(this);
            recipe.AddTile(13);
            recipe.AddRecipe();
        }
    }
}
