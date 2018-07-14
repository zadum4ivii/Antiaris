using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Armor.Mixed
{
    [AutoloadEquip(EquipType.Legs)]
    public class EnchantedGreaves : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 18;
            item.rare = 3;
            item.defense = 5;
            item.value = Item.sellPrice(0, 1, 0, 0);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Enchanted Greaves");
            Tooltip.SetDefault("5% increased movement speed");
            DisplayName.AddTranslation(GameCulture.Chinese, "附魔石护胫甲");
            Tooltip.AddTranslation(GameCulture.Chinese, "增加 5% 移动速度");
            DisplayName.AddTranslation(GameCulture.Russian, "Зачарованные поножи");
            Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает скорость передвижения");
        }

        public override void UpdateEquip(Player player)
        {
            player.accRunSpeed = 5f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "EnchantedShard", 2);
            recipe.AddIngredient(ItemID.GoldGreaves, 1);
            recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "EnchantedShard", 2);
            recipe.AddIngredient(ItemID.PlatinumGreaves, 1);
            recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.AddRecipe();
        }
    }
}
