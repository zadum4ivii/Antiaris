using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Armor.Magic
{
    [AutoloadEquip(EquipType.Legs)]
    public class DisciplePants : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 18;
            item.rare = 1;
            item.defense = 2;
            item.value = Item.sellPrice(0, 0, 12, 0);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Disciple's Pants");
            Tooltip.SetDefault("Increases movement speed");
            DisplayName.AddTranslation(GameCulture.Chinese, "门徒护腿");
            Tooltip.AddTranslation(GameCulture.Chinese, "增加移动速度");
            DisplayName.AddTranslation(GameCulture.Russian, "Штаны ученика");
            Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает скорость передвижения");
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.05f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "RuneStone", 2);
            recipe.AddIngredient(ItemID.Silk, 2);
            recipe.SetResult(this);
            recipe.AddTile(86);
            recipe.AddRecipe();
        }
    }
}
