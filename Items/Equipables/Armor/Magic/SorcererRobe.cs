using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Armor.Magic 
{
    [AutoloadEquip(EquipType.Body)]
    public class SorcererRobe : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 30;
            item.rare = 2;
            item.defense = 5;
            item.value = Item.sellPrice(0, 0, 18, 0);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sorcerer's Robe");
            Tooltip.SetDefault("8% increased magic damage");
            DisplayName.AddTranslation(GameCulture.Chinese, "巫师法袍");
            Tooltip.AddTranslation(GameCulture.Chinese, "魔法伤害增加 8%");
            DisplayName.AddTranslation(GameCulture.Russian, "Роба колдуна");
            Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает магический урон на 8%");
        }

        public override void DrawArmorColor(Player drawPlayer, float shadow, ref Color color, ref int glowMask, ref Color glowMaskColor)
        {
            glowMask = AntiarisGlowMasks.SorcererRobe;
            glowMaskColor = Color.White;
        }

        public override void UpdateEquip(Player player)
        {
            player.magicDamage += 0.08f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
		    recipe.AddIngredient(null, "DiscipleRobe", 1);
            recipe.AddIngredient(null, "WrathElement", 10);
	    	recipe.AddIngredient(ItemID.ShadowScale, 15);
            recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.AddRecipe();
		
	        recipe = new ModRecipe(mod);
	    	recipe.AddIngredient(null, "DiscipleRobe", 1);
            recipe.AddIngredient(null, "WrathElement", 10);
	    	recipe.AddIngredient(ItemID.TissueSample, 15);
            recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.AddRecipe();
        }
    }
}
