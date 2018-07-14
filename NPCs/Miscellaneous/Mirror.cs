using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.NPCs.Miscellaneous
{
    public class Mirror : ModNPC
    {
        internal static readonly int[] StoneHammer = { ModLoader.GetMod("Antiaris").ItemType("StoneHammer1"), ModLoader.GetMod("Antiaris").ItemType("StoneHammer2") };

        public override void SetDefaults()
        {
            npc.friendly = true;
            npc.townNPC = true;
            npc.dontTakeDamage = true;
			npc.noGravity = true;
            npc.width = 48;
            npc.height = 54;
            npc.damage = 10;
            npc.defense = 15;
            npc.lifeMax = 250;
			npc.aiStyle = 0;
            npc.knockBackResist = 0f;
            npc.rarity = 1;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mirror");
            DisplayName.AddTranslation(GameCulture.Chinese, "魔镜");
            DisplayName.AddTranslation(GameCulture.Russian, "Зеркало");
            NPCID.Sets.TownCritter[npc.type] = true;
        }

        public override bool UsesPartyHat() { return false; }

        public override void AI()
        {
			npc.wet = false;
            npc.lavaWet = false;
            npc.honeyWet = false;
            npc.velocity.X = npc.velocity.Y = 0f;
            npc.dontTakeDamage = true;
            var player = Main.player[Main.myPlayer];
            if (player.active && !player.dead && (double)Vector2.Distance(npc.Center, player.Center) <= 1000.0)
			{
                player.GetModPlayer<AntiarisPlayer>(mod).mirrorZone = true;
				player.AddBuff(mod.BuffType("CursedBlocks"), 60);
			}
            if (WorldGen.crimson)
            {
                Main.npcTexture[npc.type] = ModLoader.GetTexture("Antiaris/NPCs/Miscellaneous/Mirror2");
            }
            else
            {
                Main.npcTexture[npc.type] = ModLoader.GetTexture("Antiaris/NPCs/Miscellaneous/Mirror");
            }
            npc.immune[255] = 30;
            if (Main.netMode != 1)
            {
                npc.homeless = false;
                npc.homeTileX = -1;
                npc.homeTileY = -1;
                npc.netUpdate = true;
            }
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
			string MirrorBreak = Language.GetTextValue("Mods.Antiaris.MirrorBreak");
            button = MirrorBreak;
        }

        public override string GetChat()
        {
            string Mirror1 = Language.GetTextValue("Mods.Antiaris.Mirror1");
			return Mirror1;
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
			string Mirror2 = Language.GetTextValue("Mods.Antiaris.Mirror2"); 
            if (firstButton)
            {	
				foreach (var player in Main.player)
				{
					if (player.active && player.talkNPC == npc.whoAmI)
					{
                        int amount = 1;
                        foreach (var item in player.inventory)
                        {
                            if (Mirror.StoneHammer.Contains(item.type))
                            {
                                if (player.CountItem(item.type, 1) >= 1)
                                {
                                    int removed = Math.Min(item.stack, amount);
                                    item.stack -= removed;
                                    amount -= removed;
                                    if (item.stack <= 0)
                                        item.SetDefaults();
                                    if (Main.netMode == NetmodeID.SinglePlayer)
                                        npc.Transform(mod.NPCType("BrokenMirror"));
                                    else
                                    {
                                        ModPacket packet = mod.GetPacket();
                                        packet.Write((byte)1);
                                        packet.Write(npc.whoAmI);
                                        packet.Send();
                                    }
                                    Main.PlaySound(13, (int)npc.position.X, (int)npc.position.Y, 0);
									Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/StoneHammerGore1"), 1f);					
									Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/StoneHammerGore1"), 1f);
									Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/StoneHammerGore2"), 1f);
									Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/StoneHammerGore3"), 1f);
									Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/StoneHammerGore3"), 1f);
									if (Main.netMode != 1)
										NetMessage.SendData(23, -1, -1, null, npc.whoAmI, 0.0f, 0.0f, 0.0f, 0, 0, 0);
                                    return;
                                }
                                else
                                {
                                    goto deathText;
                                    return;
                                }
                            }
                        }
                        deathText:
                        {
							Main.npcChatText = Mirror2;
							player.AddBuff(mod.BuffType("Injured"), 3600);
						}
                    }
				}
            }
        }
    }

    public enum Transform : byte
    {
        brokenMirror
    }
}

