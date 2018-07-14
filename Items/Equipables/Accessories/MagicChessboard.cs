using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
    public class MagicChessboard : ModItem
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
            DisplayName.SetDefault("Magic Chessboard");
            Tooltip.SetDefault("'An ancient artifact of pure magic. Befitting as a game of study.'\n150% increased magic damage\nIncreases maximum mana by 200");
            DisplayName.AddTranslation(GameCulture.Chinese, "“棋盘”");
            Tooltip.AddTranslation(GameCulture.Chinese, "“纯粹的魔法。适合作为益智游戏。”\n1、增加 150% 魔法伤害\n2、增加 200 点最大魔力值");
            DisplayName.AddTranslation(GameCulture.Russian, "Магическая шахматная доска");
            Tooltip.AddTranslation(GameCulture.Russian, "'Древний артефакт истинной магии. Подходит, как игра для изучения.'\nУвеличивает магический урон на 150%\nУвеличивает максимальное количество маны на 200");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
			player.statManaMax2 += 200;
			player.magicDamage += 1.5f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GraniteBlock, 32);
			recipe.AddIngredient(ItemID.MarbleBlock, 32);
			recipe.AddIngredient(null, "GranitePawn", 8);
			recipe.AddIngredient(null, "MarblePawn", 8);
			recipe.AddIngredient(null, "GraniteKnight", 1);
			recipe.AddIngredient(null, "GraniteBishop", 1);
			recipe.AddIngredient(null, "GraniteRook", 1);
			recipe.AddIngredient(null, "GraniteQueen", 1);
			recipe.AddIngredient(null, "GraniteKing", 1);
			recipe.AddIngredient(null, "MarbleKnight", 1);
			recipe.AddIngredient(null, "MarbleBishop", 1);
			recipe.AddIngredient(null, "MarbleRook", 1);
			recipe.AddIngredient(null, "MarbleQueen", 1);
			recipe.AddIngredient(null, "MarbleKing", 1);
            recipe.SetResult(this);
            recipe.AddTile(114);
            recipe.AddRecipe();
        }
    }
}
