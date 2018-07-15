using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Armor.Magic 
{
    [AutoloadEquip(EquipType.Legs)]
    public class SorcererPants : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 18;
            item.rare = 2;
            item.defense = 4;
            item.value = Item.sellPrice(0, 0, 21, 0);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sorcerer's Pants");
            Tooltip.SetDefault("Increases movement speed");
            DisplayName.AddTranslation(GameCulture.Chinese, "巫师护腿");
            Tooltip.AddTranslation(GameCulture.Chinese, "1、魔法伤害增加 5%\n2、魔法致命一击概率增加 3%");
            DisplayName.AddTranslation(GameCulture.Russian, "Штаны колдуна");
            Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает скорость передвижения");
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.08f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
	    	recipe.AddIngredient(null, "DisciplePants", 1);
            recipe.AddIngredient(null, "WrathElement", 5);
	        recipe.AddIngredient(ItemID.ShadowScale, 5);
            recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.AddRecipe();
		
	        recipe = new ModRecipe(mod);
	    	recipe.AddIngredient(null, "DisciplePants", 1);
            recipe.AddIngredient(null, "WrathElement", 5);
	    	recipe.AddIngredient(ItemID.TissueSample, 5);
            recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.AddRecipe();
        }
    }
}
