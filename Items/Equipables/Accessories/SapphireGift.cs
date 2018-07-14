using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
    [AutoloadEquip(new EquipType[] { EquipType.Face })]
    public class SapphireGift : ModItem
    {
        public override Color? GetAlpha(Color lightColor) { return Color.White; }
        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 16;
            item.accessory = true;
            item.value = Item.sellPrice(0, 2, 25, 0);
            item.rare = 3;
            item.accessory = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sapphire Gift");
			Tooltip.SetDefault("Healing and sapphire flames appear around when not moving\nIncreases health restored by healing flames by 2");
            DisplayName.AddTranslation(GameCulture.Russian, "Сапфировый дар");
            Tooltip.AddTranslation(GameCulture.Russian, "Лечащие и сапфировые огоньки появляются вокруг, когда игрок не движется\nУвеличивает здоровье, восстанавливаемое лечащими огоньками, на 2");
            DisplayName.AddTranslation(GameCulture.Chinese, "蓝宝石的恩赐");
            Tooltip.AddTranslation(GameCulture.Chinese, "1、不移动时周围会燃起使你回复体力的蓝宝石火焰\n2、每一个蓝水晶火焰可以使你回复 2 点体力");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<AntiarisPlayer>(mod).healBonus += 2;
            player.GetModPlayer<AntiarisPlayer>(mod).sapphireG = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.NaturesGift, 1);
            recipe.AddIngredient(ItemID.Sapphire, 8);
            recipe.SetResult(this);
            recipe.AddTile(TileID.Anvils);
            recipe.AddRecipe();
        }
    }
}
