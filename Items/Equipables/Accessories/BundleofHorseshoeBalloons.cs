using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
    [AutoloadEquip(new EquipType[] { EquipType.Balloon })]
    public class BundleofHorseshoeBalloons : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 38;
            item.rare = 8;
            item.accessory = true;
            item.value = Item.sellPrice(0, 6, 25, 0);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bundle of Horseshoe Balloons");
            Tooltip.SetDefault("Allows the holder to quadruple jump\nIncreases jump height and negates fall damage");
			DisplayName.AddTranslation(GameCulture.Chinese, "马蹄铁气球束");
            Tooltip.AddTranslation(GameCulture.Chinese, "1、允许持有者四连跳\n2、增加跳跃高度\n3、免疫坠落伤害");
            DisplayName.AddTranslation(GameCulture.Russian, "Связка подкованных шаров");
            Tooltip.AddTranslation(GameCulture.Russian, "Дает четырехкратный прыжок\nУвеличивает высоту прыжка и игнорирует урон от падения");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.doubleJumpCloud = true;
            player.doubleJumpSandstorm = true;
            player.doubleJumpBlizzard = true;
            player.jumpBoost = true;
            player.noFallDmg = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BundleofBalloons);
            recipe.AddIngredient(ItemID.LuckyHorseshoe);
            recipe.SetResult(this);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.AddRecipe();
        }
    }
}
