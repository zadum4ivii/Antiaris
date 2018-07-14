using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
    public class MarbleKnight : ModItem
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
            DisplayName.SetDefault("Marble Knight");
            Tooltip.SetDefault("'One of the pieces of pure magic. Make your stand, and prove yourself.'\n10% increased magic damage");
            DisplayName.AddTranslation(GameCulture.Chinese, "大理石骑士棋子");
            Tooltip.AddTranslation(GameCulture.Chinese, "“一个纯粹的魔法的碎片。让你站起来，证明你自己。”\n增加 10% 魔力伤害");
            DisplayName.AddTranslation(GameCulture.Russian, "Мраморный рыцарь");
            Tooltip.AddTranslation(GameCulture.Russian, "'Одна из трёх частей истинной магии. Стой смело и прояви себя.'\nУвеличивает магический урон на 10%");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
			player.magicDamage += 0.1f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MarbleBlock, 5);
			recipe.AddIngredient(ItemID.HellstoneBar, 5);
			recipe.AddIngredient(ItemID.FallenStar, 1);
            recipe.SetResult(this);
            recipe.AddTile(114);
            recipe.AddRecipe();
        }
    }
}
