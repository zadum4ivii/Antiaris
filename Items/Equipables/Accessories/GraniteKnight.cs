using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
    public class GraniteKnight : ModItem
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
            DisplayName.SetDefault("Granite Knight");
            Tooltip.SetDefault("'One of the pieces of pure magic. Make your stand, and prove yourself.'\nIncreases maximum mana by 40");
            DisplayName.AddTranslation(GameCulture.Chinese, "花岗岩骑士棋子");
            Tooltip.AddTranslation(GameCulture.Chinese, "“一个纯粹的魔法的碎片。让你站起来，证明你自己。”\n增加 40 点最大魔力值");
            DisplayName.AddTranslation(GameCulture.Russian, "Гранитный рыцарь");
            Tooltip.AddTranslation(GameCulture.Russian, "'Одна из трёх частей истинной магии. Стой смело и прояви себя.'\nУвеличивает максимальное количество маны на 40");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
			player.statManaMax2 += 40;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GraniteBlock, 5);
			recipe.AddIngredient(ItemID.HellstoneBar, 5);
			recipe.AddIngredient(ItemID.FallenStar, 1);
            recipe.SetResult(this);
            recipe.AddTile(114);
            recipe.AddRecipe();
        }
    }
}
