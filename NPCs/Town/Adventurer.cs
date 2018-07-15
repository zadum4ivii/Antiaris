using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.NPCs.Town
{
    [AutoloadHead]
    public class Adventurer : ModNPC
    {
        //int ChangeState = 0;

        string NoQuest1 = Language.GetTextValue("Mods.Antiaris.NoQuest1");
        string NoQuest2 = Language.GetTextValue("Mods.Antiaris.NoQuest2");
        string NoQuest3 = Language.GetTextValue("Mods.Antiaris.NoQuest3");

        public override string Texture
        {
            get
            {
                return "Antiaris/NPCs/Town/Adventurer";
            }
        }

        public override string[] AltTextures
        {
            get
            {
                return new string[] { "Antiaris/NPCs/Town/Adventurer2" };
            }
        }

        public override bool Autoload(ref string name)
        {
            name = "Adventurer";
            return mod.Properties.Autoload;
        }

        public override void SetDefaults()
        {
            npc.townNPC = true;
            npc.friendly = true;
            npc.width = 24;
            npc.height = 46;
            npc.aiStyle = 7;
            npc.damage = 10;
            npc.defense = 15;
            npc.lifeMax = 250;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
            animationType = NPCID.GoblinTinkerer;
            NPCID.Sets.HatOffsetY[npc.type] = 10;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Adventurer");
            DisplayName.AddTranslation(GameCulture.Chinese, "冒险家");
            DisplayName.AddTranslation(GameCulture.Russian, "Путешественник");
            Main.npcFrameCount[npc.type] = 25;
            NPCID.Sets.ExtraFramesCount[npc.type] = 5;
            NPCID.Sets.AttackFrameCount[npc.type] = 4;
            NPCID.Sets.DangerDetectRange[npc.type] = 100;
            NPCID.Sets.AttackType[npc.type] = 0;
            NPCID.Sets.AttackTime[npc.type] = 30;
            NPCID.Sets.AttackAverageChance[npc.type] = 30;
        }

        public override string TownNPCName()
        {
            switch (WorldGen.genRand.Next(0, 11))
            {
                case 0:
                    return "Indiana";
                case 1:
                    return "Steve";
                case 2:
                    return "Marco";
                case 3:
                    return "Edmund";
                case 4:
                    return "Aron";
                case 5:
                    return "Tom";
                case 6:
                    return "Robert";
                case 7:
                    return "Ernest";
                case 8:
                    return "Charley";
                case 9:
                    return "Rolf";
                case 10:
                    return "David";
                default:
                    return "John";
            }
        }

        public override string GetChat()
        {
            string Adventurer1 = Language.GetTextValue("Mods.Antiaris.Adventurer1");
            string Adventurer2 = Language.GetTextValue("Mods.Antiaris.Adventurer2");
            string Adventurer3 = Language.GetTextValue("Mods.Antiaris.Adventurer3");
            string Adventurer4 = Language.GetTextValue("Mods.Antiaris.Adventurer4");
            string Adventurer5 = Language.GetTextValue("Mods.Antiaris.Adventurer5");
            string Adventurer6 = Language.GetTextValue("Mods.Antiaris.Adventurer6");
            string Adventurer7 = Language.GetTextValue("Mods.Antiaris.Adventurer7");
            string Adventurer8 = Language.GetTextValue("Mods.Antiaris.Adventurer8");
            var angler = NPC.FindFirstNPC(NPCID.Angler);
            if (angler >= 0 && Main.rand.Next(4) == 0)
            {
                return Adventurer7;
            }
            if (!Main.dayTime && Main.rand.Next(4) == 0)
            {
                return Adventurer8;
            }
            switch (Main.rand.Next(8))
            {
                case 0:
                    return Adventurer1;
                case 1:
                    return Adventurer2;
                case 2:
                    return Adventurer3;
                case 3:
                    return Adventurer4;
                case 4:
                    return Adventurer5;
                case 5:
                    return Adventurer6;
                case 6:
                    return Adventurer8;
                default:
                    return Adventurer4;
            }
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Language.GetTextValue("LegacyInterface.64");
            button2 = Language.GetTextValue("LegacyInterface.28");
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            Main.npcChatCornerItem = 0;
            if (firstButton)
            {
                try
                {
                    DoThing();
                }
                catch (Exception exception)
                {
                    Main.NewText("Oh no, an error happened! Report this to Zerokk and send him the file Terraria/ModLoader/Logs/Logs.txt");
                    ErrorLogger.Log(exception);
                }
            }
            else
            {
                shop = true;
            }
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            return AntiarisWorld.savedAdventurer || (!NPC.AnyNPCs(mod.NPCType("Adventurer")) && !NPC.AnyNPCs(mod.NPCType("FrozenAdventurer")));
        }

        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = mod.GetTexture("Miscellaneous/QuestIcon2");
            Texture2D texture2 = mod.GetTexture("Miscellaneous/QuestIcon3");
            Player player = Main.player[Main.myPlayer];
            var questSystem = player.GetModPlayer<QuestSystem>();
            if (questSystem.CurrentQuest == -1 && Config.QuestIconDraw && !questSystem.CompletedToday)
            {
                if (texture == null) return;
                Vector2 origin = new Vector2(texture.Width / 2, texture.Height / 2);
                float y = 50.0f;
                Vector2 position = npc.Center - Main.screenPosition - new Vector2(0.0f, y);
                spriteBatch.Draw(texture, position, null, Color.White, 0, origin, npc.scale, SpriteEffects.None, 0.0f);
            }
            if (questSystem.CurrentQuest >= 0 && questSystem.CurrentQuest != -1 && questSystem.GetCurrentQuest() is ItemQuest && player.CountItem((questSystem.GetCurrentQuest() as ItemQuest).ItemType, (questSystem.GetCurrentQuest() as ItemQuest).ItemAmount) >= (questSystem.GetCurrentQuest() as ItemQuest).ItemAmount)
            {
                int leftToRemove = (questSystem.GetCurrentQuest() as ItemQuest).ItemAmount;
                foreach (Item item in player.inventory)
                {
                    if (item.type == (questSystem.GetCurrentQuest() as ItemQuest).ItemType)
                    {
                        if (texture2 == null) return;
                        Vector2 origin = new Vector2(texture2.Width / 2, texture2.Height / 2);
                        float y = 50.0f;
                        Vector2 position = npc.Center - Main.screenPosition - new Vector2(0.0f, y);
                        spriteBatch.Draw(texture2, position, null, Color.White, 0, origin, npc.scale, SpriteEffects.None, 0.0f);
                    }
                }
            }
            if (questSystem.CurrentQuest >= 0 && questSystem.CurrentQuest != -1 && questSystem.GetCurrentQuest() is KillQuest && questSystem.QuestKills >= (questSystem.GetCurrentQuest() as KillQuest).TargetCount)
            {
                if (texture2 == null) return;
                Vector2 origin = new Vector2(texture2.Width / 2, texture2.Height / 2);
                float y = 50.0f;
                Vector2 position = npc.Center - Main.screenPosition - new Vector2(0.0f, y);
                spriteBatch.Draw(texture2, position, null, Color.White, 0, origin, npc.scale, SpriteEffects.None, 0.0f);
            }
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            var questSystem = Main.player[Main.myPlayer].GetModPlayer<QuestSystem>(mod);		
            shop.item[nextSlot].SetDefaults(mod.ItemType("AdventurerCrystal"));
            shop.item[nextSlot].shopCustomPrice = new int?(5);
            shop.item[nextSlot].shopSpecialCurrency = Antiaris.coin;
            nextSlot++;
            if (questSystem.CompletedTotal >= 7)
            {
                shop.item[nextSlot].SetDefaults(mod.ItemType("AdventurerSign"));
                shop.item[nextSlot].shopCustomPrice = new int?(15);
                shop.item[nextSlot].shopSpecialCurrency = Antiaris.coin;
                nextSlot++;
            }
            if (questSystem.CompletedTotal >= 17)
            {
                shop.item[nextSlot].SetDefaults(mod.ItemType("AdventurerStar"));
                shop.item[nextSlot].shopCustomPrice = new int?(10);
                shop.item[nextSlot].shopSpecialCurrency = Antiaris.coin;
                nextSlot++;
            }
            if (questSystem.CompletedTotal >= 27)
            {
                shop.item[nextSlot].SetDefaults(mod.ItemType("AdventurerSigil"));
                shop.item[nextSlot].shopCustomPrice = new int?(10);
                shop.item[nextSlot].shopSpecialCurrency = Antiaris.coin;
                nextSlot++;
            }
            if (questSystem.CompletedTotal >= 37)
            {
                shop.item[nextSlot].SetDefaults(mod.ItemType("AdventurerEmblem"));
                shop.item[nextSlot].shopCustomPrice = new int?(5);
                shop.item[nextSlot].shopSpecialCurrency = Antiaris.coin;
                nextSlot++;
            }
			if (questSystem.CompletedTotal >= 12 && Main.hardMode)
            {
                shop.item[nextSlot].SetDefaults(mod.ItemType("ArchaelogistManual"));
                shop.item[nextSlot].shopCustomPrice = new int?(15);
                shop.item[nextSlot].shopSpecialCurrency = Antiaris.coin;
                nextSlot++;
            }
            if (Main.hardMode)
            {
                shop.item[nextSlot].SetDefaults(mod.ItemType("CelestialManual"));
                shop.item[nextSlot].shopCustomPrice = new int?(5);
                shop.item[nextSlot].shopSpecialCurrency = Antiaris.coin;
                nextSlot++;
				shop.item[nextSlot].SetDefaults(mod.ItemType("AdventurersMachete"));
                shop.item[nextSlot].shopCustomPrice = new int?(12);
                shop.item[nextSlot].shopSpecialCurrency = Antiaris.coin;
                nextSlot++;
            }
        }

        void DoThing()
        {
            foreach (Player player in Main.player)
            {
                if (player.active && player.talkNPC == npc.whoAmI)
                {
                    var questSystem = player.GetModPlayer<QuestSystem>(mod);
                    if (questSystem.CompletedToday)
                    {
                        switch (Main.rand.Next(3))
                        {
                            case 0:
                                Main.npcChatText = NoQuest1; return;
                            case 1:
                                Main.npcChatText = NoQuest2; return;
                            default:
                                Main.npcChatText = NoQuest3; return;
                        }
                    }
                    else if (questSystem.CurrentQuest == -1)
                    {
                        int NewQuest = QuestSystem.ChooseNewQuest();
                        Main.npcChatText = QuestSystem.Quests[NewQuest].ToString();
                        if (QuestSystem.Quests[NewQuest] is ItemQuest)
                        {
                            Main.npcChatCornerItem = (QuestSystem.Quests[NewQuest] as ItemQuest).ItemType;
                            questSystem.CurrentQuest = NewQuest;
                        }
                        if (QuestSystem.Quests[NewQuest] is KillQuest)
                        {
                            Main.npcChatCornerItem = 0;
                            questSystem.CurrentQuest = NewQuest;
                        }
                        return;
                    }
                    else
                    {
                        try
                        {
                            if (questSystem.CheckQuest())
                            {
                                Main.npcChatText = questSystem.GetCurrentQuest().SayThanks();
                                Main.PlaySound(12, -1, -1, 1);
                                questSystem.SpawnReward(npc);
                                questSystem.CompleteQuest();
                                return;
                            }
                            else
                            {
                                Main.npcChatText = questSystem.GetCurrentQuest().ToString();
                                if (questSystem.GetCurrentQuest() is ItemQuest)
                                {
                                    Main.npcChatCornerItem = (questSystem.GetCurrentQuest() as ItemQuest).ItemType;
                                }
                                if (questSystem.GetCurrentQuest() is KillQuest)
                                {
                                    string QuestKilled = Language.GetTextValue("Mods.Antiaris.QuestKilled");
                                    string QuestKilled2 = Language.GetTextValue("Mods.Antiaris.QuestKilled2");
                                    Main.npcChatText += QuestKilled + questSystem.QuestKills + QuestKilled2 + (questSystem.GetCurrentQuest() as KillQuest).TargetCount;
                                }
                            }
                        }
                        catch (Exception exception)
                        {
                            Main.NewText("Oh no, an error happened! Report this to Zerokk and send him the file Terraria/ModLoader/Logs/Logs.txt");
                            ErrorLogger.Log(exception);
                        }
                    }
                }
            }
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 14;
            knockback = 4f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 5;
            randExtraCooldown = 5;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = 267;
            attackDelay = 5;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 12f;
            randomOffset = 2f;
        }

        public override void NPCLoot()
		{
			AntiarisWorld.savedAdventurer = true;
		}

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                for (int k = 0; k < 20; k++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
                }
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/AdventurerGore1"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/AdventurerGore2"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/AdventurerGore3"), 1f);
                if (Main.netMode != 1)
                {
                    int centerX = (int)(npc.position.X + (float)(npc.width / 2)) / 16;
                    int centerY = (int)(npc.position.Y + (float)(npc.height / 2)) / 16;
                    int halfLength = npc.width / 2 / 16 + 1;
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AdventurerHat"), 1, false, 0, false, false);
                }
            }
        }
    }
}

