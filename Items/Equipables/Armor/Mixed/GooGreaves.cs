using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Armor.Mixed
{
    [AutoloadEquip(EquipType.Legs)]
    public class GooGreaves : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 18;
            item.rare = 2;
            item.defense = 4;
            item.value = Item.sellPrice(0, 0, 22, 0);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Goo Greaves");
            Tooltip.SetDefault("Increases jump height\nIncreases movement speed");
            DisplayName.AddTranslation(GameCulture.Chinese, "凝胶护径甲");
            Tooltip.AddTranslation(GameCulture.Chinese, "增加跳跃高度和移动速度");
            DisplayName.AddTranslation(GameCulture.Russian, "Поножи из слизи");
            Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает высоту прыжка\nУвеличивает скорость передвижения");
        }
		
		public override void DrawArmorColor(Player drawPlayer, float shadow, ref Color color, ref int glowMask, ref Color glowMaskColor)
        {
            glowMask = AntiarisGlowMasks.GooGreaves;
            glowMaskColor = Color.White;
        }

        public override void UpdateEquip(Player player)
        {
            player.jumpBoost = true;
			player.accRunSpeed = 10f;
        }
		
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "LiquifiedGoo", 1);
            recipe.AddRecipeGroup("Antiaris:WoodGreaves");
            recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.AddRecipe();
        }
    }
}
