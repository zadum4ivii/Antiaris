using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Potions
{
    public class ConcentrationPotion : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 36;
            item.useTurn = true;
            item.maxStack = 30;
            item.rare = 1;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useStyle = 2;
            item.buffType = mod.BuffType("Concentration");
            item.buffTime = 10800;
            item.UseSound = SoundID.Item3;
            item.consumable = true;
            item.value = Item.sellPrice(0, 0, 2, 0);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Concentration Potion");
            Tooltip.SetDefault("10% reduced spell fail chance");
            DisplayName.AddTranslation(GameCulture.Chinese, "聚合药水");
            Tooltip.AddTranslation(GameCulture.Chinese, "减少 10% 咒语失效概率");
            DisplayName.AddTranslation(GameCulture.Russian, "Зелье концентрации");
            Tooltip.AddTranslation(GameCulture.Russian, "На 10% снижает шанс неудачного произнесения заклинания");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.Hemopiranha);
			recipe.AddIngredient(null, "BloodDroplet");
            recipe.AddIngredient(ItemID.Daybloom);
            recipe.SetResult(this);
            recipe.AddTile(13);
            recipe.AddRecipe();
        }
    }
}
