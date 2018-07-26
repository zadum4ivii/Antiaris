using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Placeables.Bonuses
{
    public class TreeofLife : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 36;
            item.height = 42;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.rare = 7;
            item.createTile = mod.TileType("TreeofLife");
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tree of Life");
            Tooltip.SetDefault("15% increased health restored by healing potions for nearby players");
            DisplayName.AddTranslation(GameCulture.Chinese, "生命树");
            Tooltip.AddTranslation(GameCulture.Chinese, "在其附近的玩家增加 15% 生命药水的增益数值");
            DisplayName.AddTranslation(GameCulture.Russian, "Дерево жизни");
            Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает здоровье, восстанавливаемое зельями лечения, на 15% для ближайших игроков");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.RichMahogany, 10);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 3);
            recipe.AddIngredient(ItemID.ClayPot);
            recipe.AddIngredient(ItemID.LifeFruit, 3);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}