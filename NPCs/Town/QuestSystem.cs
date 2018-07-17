using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.Utilities;

namespace Antiaris.NPCs.Town
{
	public class QuestSystem : ModPlayer
	{
	    public static List<Quest> Quests = new List<Quest>();
	    public bool CompletedToday = false;
	    public int CompletedTotal = 0;
	    public int CurrentQuest = -1;
	    public int QuestKills = 0;
	    public bool PirateQuest = true;

        public override void Initialize()
		{
            try
            {
				string Name1 = Language.GetTextValue("Mods.Antiaris.Name1");
				string Name10 = Language.GetTextValue("Mods.Antiaris.Name10");
				string Name11 = Language.GetTextValue("Mods.Antiaris.Name11");
				string Name12 = Language.GetTextValue("Mods.Antiaris.Name12");
				string Name13 = Language.GetTextValue("Mods.Antiaris.Name13");
				string Name14 = Language.GetTextValue("Mods.Antiaris.Name14");
				string Name15 = Language.GetTextValue("Mods.Antiaris.Name15");
				string Name16 = Language.GetTextValue("Mods.Antiaris.Name16");
				string Name17 = Language.GetTextValue("Mods.Antiaris.Name17");
				string Name18 = Language.GetTextValue("Mods.Antiaris.Name18");
				string Name19 = Language.GetTextValue("Mods.Antiaris.Name19");
				string Name2 = Language.GetTextValue("Mods.Antiaris.Name2");
				string Name20 = Language.GetTextValue("Mods.Antiaris.Name20");
				string Name21 = Language.GetTextValue("Mods.Antiaris.Name21");
				string Name3 = Language.GetTextValue("Mods.Antiaris.Name3");
				string Name4 = Language.GetTextValue("Mods.Antiaris.Name4");
				string Name5 = Language.GetTextValue("Mods.Antiaris.Name5");
				string Name6 = Language.GetTextValue("Mods.Antiaris.Name6");
				string Name7 = Language.GetTextValue("Mods.Antiaris.Name7");
				string Name8 = Language.GetTextValue("Mods.Antiaris.Name8");
				string Name9 = Language.GetTextValue("Mods.Antiaris.Name9");
				string Quest1 = Language.GetTextValue("Mods.Antiaris.Quest1");
				string Quest10 = Language.GetTextValue("Mods.Antiaris.Quest10");
				string Quest11 = Language.GetTextValue("Mods.Antiaris.Quest11");
				string Quest12 = Language.GetTextValue("Mods.Antiaris.Quest12");
				string Quest13 = Language.GetTextValue("Mods.Antiaris.Quest13");
				string Quest14 = Language.GetTextValue("Mods.Antiaris.Quest14");
				string Quest15 = Language.GetTextValue("Mods.Antiaris.Quest15");
				string Quest16 = Language.GetTextValue("Mods.Antiaris.Quest16");
				string Quest17 = Language.GetTextValue("Mods.Antiaris.Quest17");
				string Quest18 = Language.GetTextValue("Mods.Antiaris.Quest18");
				string Quest19 = Language.GetTextValue("Mods.Antiaris.Quest19");
				string Quest2 = Language.GetTextValue("Mods.Antiaris.Quest2");
				string Quest20 = Language.GetTextValue("Mods.Antiaris.Quest20");
				string Quest21 = Language.GetTextValue("Mods.Antiaris.Quest21");
				string Quest3 = Language.GetTextValue("Mods.Antiaris.Quest3");
				string Quest4 = Language.GetTextValue("Mods.Antiaris.Quest4");
				string Quest5 = Language.GetTextValue("Mods.Antiaris.Quest5");
				string Quest6 = Language.GetTextValue("Mods.Antiaris.Quest6");
				string Quest7 = Language.GetTextValue("Mods.Antiaris.Quest7");
				string Quest8 = Language.GetTextValue("Mods.Antiaris.Quest8");
				string Quest9 = Language.GetTextValue("Mods.Antiaris.Quest9");
                Quests.Clear();
                Quests.Add(new ItemQuest(Name1 + "\n\n" + Quest1, mod.ItemType("OldCompass")));
                Quests.Add(new ItemQuest(Name2 + "\n\n" + Quest2, mod.ItemType("GlacialCrystal")));
                Quests.Add(new ItemQuest(Name3 + "\n\n" + Quest3, ItemID.Leather, 12));
                Quests.Add(new ItemQuest(Name4 + "\n\n" + Quest4, mod.ItemType("MonsterSkull")));
                Quests.Add(new ItemQuest(Name5 + "\n\n" + Quest5, mod.ItemType("HarpyEgg")));
				
                Quest quest = new ItemQuest(Name6 + "\n\n" + Quest6, mod.ItemType("GoldenApple"), 1, 1d, "Mods.Antiaris.ThanksApple1");
                quest.Reward = "GoldenAppleMask";
                //quest.SpawnReward = npc => Item.NewItem(npc.position, npc.Size, mod.ItemType("GoldenAppleMask"), 1, false, 0, false, false);
                Quests.Add(quest);
				
                quest = new ItemQuest(Name8 + "\n\n" + Quest8, mod.ItemType("Necronomicon"));
                quest.IsAvailable = () => NPC.downedBoss3;
                Quests.Add(quest);

                int[] slimes = { 1, 16, 59, 71, 81, 138, 147, 183, 184, 204, 225, 244, 302, 333, 334, 335, 336, 535, 537 };
                Quest quest2 = new KillQuest(Name9 + "\n\n" + Quest9, slimes, 25, 1d);
                quest2.Reward = "EmeraldNet";
                //quest2.SpawnReward = npc => Item.NewItem(npc.position, npc.Size, mod.ItemType("EmeraldNet"), 1, false, 0, false, false);
                Quests.Add(quest2);

                int[] miner = { NPCID.UndeadMiner };
                Quests.Add(new KillQuest(Name10 + "\n\n" + Quest10, miner, 1, 1d));

                int[] bird = { mod.NPCType("BirdTraveller") };
                Quests.Add(new KillQuest(Name11 + "\n\n" + Quest11, bird, 5, 1d));

                Quests.Add(new ItemQuest(Name12 + "\n\n" + Quest12, mod.ItemType("SilkScarf"), 1, 1d));
                Quests.Add(new ItemQuest(Name13 + "\n\n" + Quest13, mod.ItemType("AdventurersFishingRod"), 1, 1d));
				
				var armsdealer = NPC.FindFirstNPC(NPCID.ArmsDealer);
				quest = new ItemQuest(Name14 + "\n\n" + Quest14, mod.ItemType("Bonebardier"), 1, 1d, "Mods.Antiaris.ThanksBonebardier");
				quest.IsAvailable = () => armsdealer >= 0;
                quest.Reward = "Bonebardier";
                //quest.SpawnReward = npc => Item.NewItem(npc.position, npc.Size, mod.ItemType("Bonebardier"), 1, false, 0, false, false);
                Quests.Add(quest);
				
				Quests.Add(new ItemQuest(Name15 + "\n\n" + Quest15, mod.ItemType("DemonWingPiece"), 12, 1d));
				
				quest = new ItemQuest(Name16 + "\n\n" + Quest16, mod.ItemType("AdventurerChest"), 1, 1d, "Mods.Antiaris.ThanksChest");
                quest.Reward = "SwordsmanGuide";
                //quest.SpawnReward = npc => Item.NewItem(npc.position, npc.Size, mod.ItemType("SwordsmanGuide"), 1, false, 0, false, false);
                Quests.Add(quest);
				
				Quests.Add(new ItemQuest(Name17 + "\n\n" + Quest17, mod.ItemType("Coconut"), 16, 1d));
				Quests.Add(new ItemQuest(Name18 + "\n\n" + Quest18, mod.ItemType("Charcoal"), 25, 1d));
				Quests.Add(new ItemQuest(Name19 + "\n\n" + Quest19, mod.ItemType("SpiderMass"), 12, 1d));
				
				quest = new ItemQuest(Name20 + "\n\n" + Quest20, mod.ItemType("StolenPresent"), 20, 1d);
                quest.IsAvailable = () => Main.xMas && NPC.downedPlantBoss;
                quest.Reward = "GelidRing";
				//quest.SpawnReward = npc => Item.NewItem(npc.position, npc.Size, mod.ItemType("GelidRing"), 1, false, 0, false, false);
                Quests.Add(quest);
				
				quest = new ItemQuest(Name21 + "\n\n" + Quest21, mod.ItemType("EmeraldShard"), 12, 1d, "Mods.Antiaris.ThanksShards");
                quest.Reward = "LivingEmerald";
                //quest.SpawnReward = npc => Item.NewItem(npc.position, npc.Size, mod.ItemType("LivingEmerald"), 1, false, 0, false, false);
                Quests.Add(quest);
				
				
            }
            catch (Exception exception)
            {
                Main.NewText("Oh no, an error happened! Report this to Zerokk and send him the file Terraria/ModLoader/Logs/Logs.txt");
                ErrorLogger.Log(exception);
            }
        }

	    public Quest GetCurrentQuest()
		{
			return Quests[CurrentQuest]; 
		}

	    public bool CheckQuest()
        {
            if (CurrentQuest == -1)
                return false;

            var quest = Quests[CurrentQuest];
            return quest.CheckCompletion(Main.player[Main.myPlayer]);
        }

	    public void CompleteQuest()
        {
            //CurrentQuest = -1;
            CompletedToday = true;
            CompletedTotal++;
            QuestKills = 0;
        }

	    public void SpawnReward(NPC npc)
		{
            try
            {
                Main.PlaySound(24, -1, -1, 1);
                int number = 0;
                number = Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AdventurerLootBox"), 1, false, 0, false, false);
                if (Main.netMode == 1 && number >= 0)
                    NetMessage.SendData(21, -1, -1, (NetworkText)null, number, 1f, 0.0f, 0.0f, 0, 0, 0);
                int number2 = 0;
                number2 = Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType(GetCurrentQuest().Reward), 1, false, 0, false, false);
                if (Main.netMode == 1 && number2 >= 0)
                    NetMessage.SendData(21, -1, -1, (NetworkText)null, number2, 1f, 0.0f, 0.0f, 0, 0, 0);
                //GetCurrentQuest().SpawnReward(npc);
            }
            catch (Exception exception)
            {
                Main.NewText("Oh no, an error happened! Report this to Zerokk and send him the file Terraria/ModLoader/Logs/Logs.txt");
                ErrorLogger.Log(exception);
            }
        }

	    public static int ChooseNewQuest()
		{
			var questChoice = new WeightedRandom<int>();
			for(int i = 0; i < Quests.Count; i++)
			{
				if(Quests[i].IsAvailable())
					questChoice.Add(i, Quests[i].Weight);
			}
			return questChoice;
		}

	    public override void PostUpdate()
		{
            if (CompletedToday) CurrentQuest = -1;
            try
            {
                if (Main.dayTime)
                {
                    if (Main.time < 1 || (Main.fastForwardTime && Main.time < 61))
                    {
                        CurrentQuest = -1;
                        CompletedToday = false;
                        QuestKills = 0;
                    }
                }
            }
            catch (Exception exception)
            {
                Main.NewText("Oh no, an error happened! Report this to Zerokk and send him the file Terraria/ModLoader/Logs/Logs.txt");
                ErrorLogger.Log(exception);
            }
        }

	    public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
		{
            try
            {
                if (CurrentQuest >= 0 && CurrentQuest != -1 && GetCurrentQuest() is KillQuest)
                {
                    foreach (var i in (GetCurrentQuest() as KillQuest).TargetType)
                        if (target.life <= 0 && target.type == i)
                        QuestKills++;
                }
            }
            catch (Exception exception)
            {
                Main.NewText("Oh no, an error happened! Report this to Zerokk and send him the file Terraria/ModLoader/Logs/Logs.txt");
                ErrorLogger.Log(exception);
            }
        }

	    public override void Load(TagCompound tag)
		{
			CurrentQuest = tag.GetInt("Current");
			CompletedToday = tag.GetBool("Today");
			CompletedTotal = tag.GetInt("Total");
			PirateQuest = tag.GetBool("PirateQuest");
            QuestKills = tag.GetInt("QuestKills");
        }

	    public override TagCompound Save()
		{
			var tag = new TagCompound();
			tag.Set("Current", CurrentQuest);
			tag.Set("Today", CompletedToday);
			tag.Set("Total", CompletedTotal);
			tag.Set("PirateQuest", PirateQuest);
            tag.Set("QuestKills", QuestKills);
            return tag;
		}
	}
	
	public class ProjKillHandler : GlobalProjectile
	{
	    public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
		{
            try
            {
                var player = Main.player[Main.myPlayer];
                var questSystem = player.GetModPlayer<QuestSystem>();
                if (questSystem.CurrentQuest >= 0 && questSystem.CurrentQuest != -1 && questSystem.GetCurrentQuest() is KillQuest)
                {
                    foreach (var i in (questSystem.GetCurrentQuest() as KillQuest).TargetType)
                        if (target.life <= 0 && target.type == i)
                        questSystem.QuestKills++;
                }
            }
            catch (Exception exception)
            {
                Main.NewText("Oh no, an error happened! Report this to Zerokk and send him the file Terraria/ModLoader/Logs/Logs.txt");
                ErrorLogger.Log(exception);
            }
        }
	}
	
	public abstract class Quest
	{
	    public Func<bool> IsAvailable;
	    public string Name;
	    public string Reward;
	    public Action<NPC> SpawnReward;
	    public string ThanksMessage;
	    public double Weight;

	    protected Quest(string name, double weight = 1d, string specialThanks = "Mods.Antiaris.Thanks")
		{
			Name = name;
			Weight = weight;
			ThanksMessage = specialThanks;
			SpawnReward = (npc) => {};
			IsAvailable = () => true;
		}

	    public abstract bool CheckCompletion(Player player);

	    public override string ToString()
		{
			return Language.GetTextValue(Name, Main.LocalPlayer.name);
		}

	    public string SayThanks()
		{
			return Language.GetTextValue(ThanksMessage, Main.LocalPlayer.name);
		}
	}
	
	public class ItemQuest : Quest
	{
	    public int ItemAmount;
	    public int ItemType;

	    public ItemQuest(string name, int itemType, int itemAmount = 1, double weight = 1d, string specialThanks = "Mods.Antiaris.Thanks") : base(name, weight, specialThanks)
		{
			ItemType = itemType;
			ItemAmount = itemAmount;
		}

	    public override bool CheckCompletion(Player player)
		{
            try
            {
                if (player.CountItem(ItemType, ItemAmount) >= ItemAmount)
                {
                    int leftToRemove = ItemAmount;
                    foreach (var item in player.inventory)
                    {
                        if (item.type == ItemType)
                        {
                            int removed = Math.Min(item.stack, leftToRemove);
                            item.stack -= removed;
                            leftToRemove -= removed;
                            if (item.stack <= 0)
                                item.SetDefaults();
                            if (leftToRemove <= 0)
                                return true;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Main.NewText("Oh no, an error happened! Report this to Zerokk and send him the file Terraria/ModLoader/Logs/Logs.txt");
                ErrorLogger.Log(exception);
            }
            return false;
		}
	}
	
	public class KillQuest : Quest
	{
	    public int TargetCount;
	    public int[] TargetType;

	    public KillQuest(string name, int[] targetType, int targetCount = 1, double weight = 1d, string specialThanks = "Mods.Antiaris.Thanks") : base(name, weight, specialThanks)
        {
            TargetType = targetType;
            TargetCount = targetCount;
        }

	    public override bool CheckCompletion(Player player)
		{
            try
            {
                if (player.GetModPlayer<QuestSystem>().QuestKills >= TargetCount)
                {
                    player.GetModPlayer<QuestSystem>().QuestKills = 0;
                    return true;
                }
            }
            catch (Exception exception)
            {
                Main.NewText("Oh no, an error happened! Report this to Zerokk and send him the file Terraria/ModLoader/Logs/Logs.txt");
                ErrorLogger.Log(exception);
            }
            return false;
		}
	}
}
