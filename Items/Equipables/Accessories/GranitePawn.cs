using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
    public class GranitePawn : ModItem
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
            DisplayName.SetDefault("Granite Pawn");
            Tooltip.SetDefault("'One of the pieces of pure magic. Take the first step...'\nIncreases maximum mana by 20");
            DisplayName.AddTranslation(GameCulture.Chinese, "花岗岩小卒棋子");
            Tooltip.AddTranslation(GameCulture.Chinese, "“一个纯粹的魔法的碎片。迈出第一步...”\n增加 20 点最大魔力值");
            DisplayName.AddTranslation(GameCulture.Russian, "Гранитная пешка");
            Tooltip.AddTranslation(GameCulture.Russian, "'Одна из трёх частей истинной магии. Сделай первый шаг...'\nУвеличивает максимальное количество маны на 20");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
			player.statManaMax2 += 20;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GraniteBlock, 5);
			recipe.AddIngredient(ItemID.FallenStar, 1);
            recipe.SetResult(this);
            recipe.AddTile(114);
            recipe.AddRecipe();
        }
    }
}
