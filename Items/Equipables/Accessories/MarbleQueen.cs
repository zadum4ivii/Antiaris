using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
    public class MarbleQueen : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 32;
            item.rare = 6;
            item.value = Item.buyPrice(0, 0, 40, 0);
            item.accessory = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Marble Queen");
            Tooltip.SetDefault("'One of the pieces of pure magic. Lose yourself, and find what was once lost.'\n25% increased magic damage");
            DisplayName.AddTranslation(GameCulture.Chinese, "大理石女王棋子");
            Tooltip.AddTranslation(GameCulture.Chinese, "“一个纯粹的魔法的碎片。迷失自我，找回曾经失去的事物。”\n增加 25% 魔法伤害");
            DisplayName.AddTranslation(GameCulture.Russian, "Мраморная королева");
            Tooltip.AddTranslation(GameCulture.Russian, "'Одна из трёх частей истинной магии. Потеряй себя и узнай, что было однажды утеряно.'\nУвеличивает магический урон на 25%");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
			player.magicDamage += 0.25f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MarbleBlock, 5);
			recipe.AddIngredient(ItemID.LunarBar, 5);
			recipe.AddIngredient(ItemID.FallenStar, 1);
            recipe.SetResult(this);
            recipe.AddTile(114);
            recipe.AddRecipe();
        }
    }
}
