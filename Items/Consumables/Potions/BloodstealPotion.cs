using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Potions
{
    public class BloodstealPotion : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 34;
            item.useTurn = true;
            item.maxStack = 30;
            item.rare = 6;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useStyle = 2;
            item.buffType = mod.BuffType("Bloodsteal");
            item.buffTime = 18000;
            item.UseSound = SoundID.Item3;
            item.consumable = true;
            item.value = Item.sellPrice(0, 0, 2, 0);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloodsteal Potion");
            Tooltip.SetDefault("Attacks have a chance to restore health");
            DisplayName.AddTranslation(GameCulture.Chinese, "嗜血药水");
            Tooltip.AddTranslation(GameCulture.Chinese, "攻击时有概率恢复体力");
            DisplayName.AddTranslation(GameCulture.Russian, "Зелье воровства крови");
            Tooltip.AddTranslation(GameCulture.Russian, "Атаки имеют шанс восстановить здоровье");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater, 1);
            recipe.AddIngredient(null, "VampiricEssence", 1);
			recipe.AddIngredient(null, "BloodDroplet", 2);
            recipe.AddIngredient(ItemID.Deathweed, 2);
            recipe.SetResult(this);
            recipe.AddTile(13);
            recipe.AddRecipe();
        }
    }
}
