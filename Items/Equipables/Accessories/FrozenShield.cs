using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
    public class FrozenShield : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 44;
            item.rare = 8;
            item.value = Item.sellPrice(0, 8, 0, 0);
            item.accessory = true;
            item.defense = 6;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frozen Shield");
            Tooltip.SetDefault("When above 25% life, absorbs 25% of damage done to players on your team\nWhen below 50% life, grants a protective shell that reduces damage by 25%");
            DisplayName.AddTranslation(GameCulture.Chinese, "急冻盾牌");
            Tooltip.AddTranslation(GameCulture.Chinese, "1、生命值高于总值的 25%时，吸收队友 25% 的伤害\n2、当生命值低于 50% 时，将获得减少 25% 伤害的冰坚壳");
            DisplayName.AddTranslation(GameCulture.Russian, "Ледяной щит");
            Tooltip.AddTranslation(GameCulture.Russian, "Поглощает 25% урона, нанесенного игрокам в вашей команде, если здоровье выше 25%\nПризывает защитный панцирь, снижающий полученный урон на 25%, если здоровье ниже 50%");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.noKnockback = true;
            if (player.statLife <= player.statLifeMax2 * 0.5)
            {
                player.AddBuff(62, 5, true);
            }
            if (player.statLife > player.statLifeMax2 * 0.25)
            {
                player.hasPaladinShield = true;
                if (player != Main.player[Main.myPlayer] && player.miscCounter % 10 == 0)
                {
                    if (Main.player[Main.myPlayer].team == player.team && player.team != 0)
                    {
                        var local = player.position.X - Main.player[Main.myPlayer].position.X;
                        var num = (float)(player.position.Y - Main.player[Main.myPlayer].position.Y);
                        if (Math.Sqrt(local * local + (double)num * (double)num) < 800.0)
						{
                            Main.player[Main.myPlayer].AddBuff(43, 20, true);
						}
                    }
                }
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PaladinsShield);
            recipe.AddIngredient(ItemID.FrozenTurtleShell);
            recipe.SetResult(this);
            recipe.AddTile(114);
            recipe.AddRecipe();
        }
    }
}