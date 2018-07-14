using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
    [AutoloadEquip(EquipType.Neck)]
    public class AdventurerStar : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 40;
            item.rare = 3;
            item.value = Item.buyPrice(0, 5, 0, 0);
            item.accessory = true;
            item.defense = 1;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Adventurer's Star");
            Tooltip.SetDefault("Pressing the 'Special Ability' key will teleport you to your cursor\n[c/C35377:Only one adventurer item can be worn]");
            DisplayName.AddTranslation(GameCulture.Chinese, "冒险家之星");
            Tooltip.AddTranslation(GameCulture.Chinese, "点击“特殊能力”键将你传送到光标位置\n[c/FFB640:【如何设置“特殊能力”键】]\n请在游戏开始界面寻找“设置-控件-快捷键绑定”\n找到Mod Controls选项\n找到“Antiaris:Special Ability”并修改按键，默认按键为“L”\n[c/C35377:“特殊能力”类型饰品只能佩戴一件]");
            DisplayName.AddTranslation(GameCulture.Russian, "Звезда путешественника");
            Tooltip.AddTranslation(GameCulture.Russian, "Нажатие на кнопку 'Специальная способность' телепортирует Вас в ваш курсор\n[c/C35377:Можно носить только один предмет путешественника]");
        }

        public override bool CanEquipAccessory(Player player, int slot)
        {
            for (var i = 0; i < player.armor.Length; i++)
            {
                var aPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
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
                    var teleportPos = new Vector2();
                    teleportPos.X = Main.mouseX + Main.screenPosition.X - player.width / 2;
                    teleportPos.Y = player.gravDir != 1 ? (Main.screenPosition.Y + Main.screenHeight - Main.mouseY) : (Main.mouseY + Main.screenPosition.Y - player.height);
                    if (teleportPos.X > 50 && teleportPos.X < (double)(Main.maxTilesX * 16 - 50) && (teleportPos.Y > 50 && teleportPos.Y < (double)(Main.maxTilesY * 16 - 55)))
                    {
                        var tileX = (int)(teleportPos.X / 16f);
                        var tileY = (int)(teleportPos.Y / 16f);
                        if (((int)Main.tile[tileX, tileY].wall != 87 || (double)tileY <= Main.worldSurface || NPC.downedPlantBoss) && !Collision.SolidCollision(teleportPos, player.width, player.height))
                        {
                            AntiarisHelper.TeleportTo(player, teleportPos);
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
                            NetMessage.SendData(65, -1, -1, null, 0, player.whoAmI, teleportPos.X, teleportPos.Y, 1, 0, 0);
                            player.AddBuff(mod.BuffType("Recharge"), 600);
                        }
                    }
                }
            }
        }
    }
}
