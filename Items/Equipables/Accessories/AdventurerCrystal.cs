using System.Linq;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
    [AutoloadEquip(EquipType.Neck)]
    public class AdventurerCrystal : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 34;
            item.rare = 3;
            item.value = Item.buyPrice(0, 5, 0, 0);
            item.accessory = true;
            item.defense = 3;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Adventurer Crystal");
            Tooltip.SetDefault("Pressing the 'Special Ability' key will teleport you to a random position\n[c/C35377:Only one adventurer item can be worn]");
            DisplayName.AddTranslation(GameCulture.Chinese, "冒险家水晶");
            Tooltip.AddTranslation(GameCulture.Chinese, "点击“特殊能力”键将你传送到随机位置\n[c/FFB640:【如何设置“特殊能力”键】]\n请在游戏开始界面寻找“设置-控件-快捷键绑定”\n找到Mod Controls选项\n找到“Antiaris:Special Ability并修改按键”，默认按键为“L”\n[c/C35377:“特殊能力”类型饰品只能佩戴一件]");
            DisplayName.AddTranslation(GameCulture.Russian, "Кристалл путешественника");
            Tooltip.AddTranslation(GameCulture.Russian, "Нажатие на кнопку 'Специальная способность' телепортирует Вас в случайное место\n[c/C35377:Можно носить только один предмет путешественника]");
        }

        public override bool CanEquipAccessory(Player player, int slot)
        {
            var aPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
            for (var i = 0; i < player.armor.Length; i++)
            {
                if (aPlayer.aItems)
                {
                    return false;
                }
            }
            return true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            var aPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
            aPlayer.aItems = true;
            if (!player.buffType.Contains(mod.BuffType("Recharge")))
            {
                if (Antiaris.adventurerKey.JustPressed)
                {
                    player.TeleportationPotion();
                    AntiarisHelper.CreateDust(player, 64, 20);
					Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Items/AdventurerItem"), player.position);
                    for (var l = 3; l < 8 + player.extraAccessorySlots; l++)
                    {
                        if (player.armor[l].type == mod.ItemType("CelestialManual"))
                        {
                            var newLife = Main.rand.Next(35, 55);
                            player.statLife += newLife;
                            player.HealEffect(newLife);
                        }
                    }
                    player.AddBuff(mod.BuffType("Recharge"), 2000);
                }
            }
        }
    }
}
