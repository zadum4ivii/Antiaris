using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Placeables.Bonuses
{
    public class DazzlingMirror : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 48;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.rare = 3;
            item.createTile = mod.TileType("DazzlingMirror");
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dazzling Mirror");
            Tooltip.SetDefault("8% increased damage for nearby players");
            DisplayName.AddTranslation(GameCulture.Chinese, "璀璨之镜");
            Tooltip.AddTranslation(GameCulture.Chinese, "在其附近的玩家增加 8% 的伤害");
            DisplayName.AddTranslation(GameCulture.Russian, "Сияющее зеркало");
            Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает урон на 8% для ближайших игроков");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PearlstoneBlock, 20);
            recipe.AddIngredient(ItemID.Glass, 6);
            recipe.AddIngredient(null, "BlazingHeart");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}