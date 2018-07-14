using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
    [AutoloadEquip(new EquipType[] { EquipType.Face })]
    public class SpecterGift : ModItem
    {
        public override Color? GetAlpha(Color lightColor) { return Color.White; }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 16;
            item.accessory = true;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = 4;
            item.accessory = true;
        }

        public override void SetStaticDefaults()
        {		
			DisplayName.SetDefault("Specter Gift");
			Tooltip.SetDefault("Rainbow flames appear around when not moving\nIncreases health restored by healing flames by 6\n66% decreased flames appearance cooldown");
            DisplayName.AddTranslation(GameCulture.Russian, "Спектральный дар");
            Tooltip.AddTranslation(GameCulture.Russian, "Радужные огоньки появляются вокруг, когда игрок не движется\nУвеличивает здоровье, восстанавливаемое лечащими огоньками, на 6\nНа 66% снижает кулдаун появление огоньков");
            DisplayName.AddTranslation(GameCulture.Chinese, "虹彩的恩赐");
            Tooltip.AddTranslation(GameCulture.Chinese, "1、不移动时周围会燃起使你回复体力的虹彩火焰\n2、每一个虹彩火焰可以使你回复 6 点体力\n3、减少 66% 火焰生成冷却时间");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<AntiarisPlayer>(mod).specterG = true;
            player.GetModPlayer<AntiarisPlayer>(mod).healBonus += 6;
            player.GetModPlayer<AntiarisPlayer>(mod).giftCooldown2 += 2;
        }

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            base.ModifyTooltips(list);
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                    tooltipLine.overrideColor = new Color?(new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB));
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "AmethystGift", 1);
            recipe.AddIngredient(null, "DiamondGift", 1);
            recipe.AddIngredient(null, "EmeraldGift", 1);
            recipe.AddIngredient(null, "RubyGift", 1);
            recipe.AddIngredient(null, "SapphireGift", 1);
            recipe.AddIngredient(null, "TopazGift", 1);
            recipe.SetResult(this);
            recipe.AddTile(TileID.Anvils);
            recipe.AddRecipe();
        }
    }
}
