using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Armor.Mixed
{
    [AutoloadEquip(EquipType.Body)]
    public class GooBreastplate : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 22;
            item.rare = 2;
            item.defense = 5;
            item.value = Item.sellPrice(0, 0, 25, 0);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Goo Breastplate");
            Tooltip.SetDefault("5% increased critical strike chance");
            DisplayName.AddTranslation(GameCulture.Chinese, "凝胶胸甲");
            Tooltip.AddTranslation(GameCulture.Chinese, "增加 5% 致命一击概率");
            DisplayName.AddTranslation(GameCulture.Russian, "Нагрудник из слизи");
            Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает шанс критического удара на 5%");
        }
		
		public override void DrawArmorColor(Player drawPlayer, float shadow, ref Color color, ref int glowMask, ref Color glowMaskColor)
        {
			var player = Main.player[Main.myPlayer];
			if (Main.myPlayer == item.owner)
			{
				if (player.Male)
				{
					glowMask = AntiarisGlowMasks.GooBreastplate;
				}
				else
				{
					glowMask = AntiarisGlowMasks.GooBreastplateF;
				}
			}
            glowMaskColor = Color.White;
        }

        public override void UpdateEquip(Player player)
        {
				player.meleeCrit += 5;
				player.magicCrit += 5;
				player.rangedCrit += 5;
				player.thrownCrit += 5;   
        }
		
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "LiquifiedGoo", 1);
            recipe.AddRecipeGroup("Antiaris:WoodBreastplate");
            recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.AddRecipe();
        }
    }
}
