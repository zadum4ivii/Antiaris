using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Armor.Magic
{
    [AutoloadEquip(EquipType.Body)]
    public class DiscipleRobe : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 26;
            item.rare = 1;
            item.defense = 3;
            item.value = Item.sellPrice(0, 0, 10, 0);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Disciple's Robe");
            Tooltip.SetDefault("5% increased magic damage");
            DisplayName.AddTranslation(GameCulture.Chinese, "门徒法袍");
            Tooltip.AddTranslation(GameCulture.Chinese, "魔法伤害增加 5%");
            DisplayName.AddTranslation(GameCulture.Russian, "Роба ученика");
            Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает магический урон на 5%");
        }

        public override void UpdateEquip(Player player)
        {
            player.magicDamage += 0.05f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "RuneStone", 5);
            recipe.AddIngredient(ItemID.Silk, 5);
            recipe.SetResult(this);
            recipe.AddTile(86);
            recipe.AddRecipe();
        }
    }
}
