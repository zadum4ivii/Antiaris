using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
    public class Warbanner : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 52;
            item.rare = 2;
            item.value = Item.sellPrice(0, 0, 25, 0);
            item.accessory = true;
            item.defense = 2;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Warbanner");
            Tooltip.SetDefault("Enemies are more likely to target you\nIncreases stats of players on your team");
            DisplayName.AddTranslation(GameCulture.Chinese, "战旗");
            Tooltip.AddTranslation(GameCulture.Chinese, "1、嘲讽敌人\n2、微弱提升你所在队伍其它队员的所有类型伤害、近战攻速、移动速度");
            DisplayName.AddTranslation(GameCulture.Russian, "Боевой флаг");
            Tooltip.AddTranslation(GameCulture.Russian, "Вы становитесь более приоритетной целью для врагов\nПовышает характеристики игроков в вашей команде");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.aggro += 500;
            var player2 = Main.player[Main.myPlayer];
            if (player != player2 && player.miscCounter % 10 == 0)
            {
                if (player2.team == player.team && player.team != 0)
                {
                    var local = player.position.X - player2.position.X;
                    var distance = (float)(player.position.Y - player2.position.Y);
                    if (Math.Sqrt(local * local + (double)distance * (double)distance) < 800.0)
                    {
                        player2.AddBuff(mod.BuffType("WarbannerAura"), 20, true);
                    }
                }
            }
            player.AddBuff(mod.BuffType("Warbanner"), 20, true);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 15);
			recipe.AddIngredient(ItemID.Silk, 10);
            recipe.SetResult(this);
            recipe.AddTile(106);
            recipe.AddRecipe();
        }
    }
}