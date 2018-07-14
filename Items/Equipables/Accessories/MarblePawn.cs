using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
    public class MarblePawn : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 32;
            item.rare = 6;
            item.value = Item.buyPrice(0, 0, 40, 0);
            item.accessory = true;
			item.maxStack = 8;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Marble Pawn");
            Tooltip.SetDefault("'One of the pieces of pure magic. Take the first step...'\n5% increased magic damage");
            DisplayName.AddTranslation(GameCulture.Chinese, "大理石小卒棋子");
            Tooltip.AddTranslation(GameCulture.Chinese, "“一个纯粹的魔法的碎片。迈出第一步...”\n增加 5% 魔法伤害");
            DisplayName.AddTranslation(GameCulture.Russian, "Мраморная пешка");
            Tooltip.AddTranslation(GameCulture.Russian, "'Одна из трёх частей истинной магии. Сделай первый шаг...'\nУвеличивает магический урон на 5%");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
			player.magicDamage += 0.05f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MarbleBlock, 5);
			recipe.AddIngredient(ItemID.FallenStar, 1);
            recipe.SetResult(this);
            recipe.AddTile(114);
            recipe.AddRecipe();
        }
    }
}
