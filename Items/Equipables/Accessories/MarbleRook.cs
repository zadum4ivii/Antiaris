using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
    public class MarbleRook : ModItem
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
            DisplayName.SetDefault("Marble Rook");
            Tooltip.SetDefault("'One of the pieces of pure magic. Guard those who act in your stead.'\n15% increased magic damage");
            DisplayName.AddTranslation(GameCulture.Chinese, "大理石战车棋子");
            Tooltip.AddTranslation(GameCulture.Chinese, "“一个纯粹的魔法的碎片。保护那些替你行事的人。”\n增加 15% 魔法伤害");
            DisplayName.AddTranslation(GameCulture.Russian, "Мраморный слон");
            Tooltip.AddTranslation(GameCulture.Russian, "'Одна из трёх частей истинной магии. Защищает тех, кто действует вместо вас.'\nУвеличивает магический урон на 15%");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
			player.magicDamage += 0.15f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MarbleBlock, 5);
			recipe.AddIngredient(ItemID.HallowedBar, 5);
			recipe.AddIngredient(ItemID.FallenStar, 1);
            recipe.SetResult(this);
            recipe.AddTile(114);
            recipe.AddRecipe();
        }
    }
}
