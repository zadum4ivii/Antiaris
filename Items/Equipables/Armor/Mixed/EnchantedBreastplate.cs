using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Armor.Mixed
{
    [AutoloadEquip(EquipType.Body)]
    public class EnchantedBreastplate : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 20;
            item.rare = 3;
            item.defense = 6;
            item.value = Item.sellPrice(0, 1, 0, 0);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Enchanted Breastplate");
            Tooltip.SetDefault("5% increased damage");
            DisplayName.AddTranslation(GameCulture.Chinese, "附魔石胸甲");
            Tooltip.AddTranslation(GameCulture.Chinese, "增加 5% 伤害");
            DisplayName.AddTranslation(GameCulture.Russian, "Зачарованный нагрудник");
            Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает урон на 5%");
        }

        public override void UpdateEquip(Player player)
        {
            player.magicDamage += 0.05f;
            player.meleeDamage += 0.05f;
			player.thrownDamage += 0.05f;
            player.minionDamage += 0.05f;
			player.rangedDamage += 0.05f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "EnchantedShard", 5);
            recipe.AddIngredient(ItemID.GoldChainmail, 1);
            recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "EnchantedShard", 5);
            recipe.AddIngredient(ItemID.PlatinumChainmail, 1);
            recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.AddRecipe();
        }
    }
}
