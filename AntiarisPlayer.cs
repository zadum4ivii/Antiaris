using System;
using System.Collections.Generic;
using System.Linq;
using Antiaris.Items.Quests;
using Antiaris.NPCs.Town;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Antiaris.UIs;
using Terraria.ModLoader;

namespace Antiaris
{
    public class AntiarisPlayer : ModPlayer
    {
        public static bool TrapsImmune = false;
        public static bool questReady = true;

        private static double _pausedTime;
        public static int red = 125;
        public static int green = 35;
        public static int blue = 25;

        internal static readonly int[] Slimes =
        {
            1,
            16,
            59,
            71,
            81,
            138,
            121,
            122,
            141,
            147,
            183,
            184,
            204,
            225,
            244,
            302,
            333,
            335,
            334,
            336,
            537
        };

        public bool aItems = false;
        public bool amethystG;
        public bool antlionSet = false;
        public bool bigMinions = false;
        public bool bitesTheDust = false;
        public bool bizzare = false;
        public bool bloodsteal = false;
        public bool boilingPoint = false;
        public bool Bonebardier = false;
        public bool building = false;
        private int buildTimer = 0;
        public bool calmnessSpirit;

        private bool change = false;

        private bool checkGhost = true;
        public bool cherryBlossom = false;
        public bool critHeal = false;
        public bool deceleration = false;
        public bool despairingFlames = false;
        public bool despairingFlamesB = false;
        public bool diamondG;
        public bool discipleSet;
        float DistX = 0f;
        float DistXT = 0f;
        float DistY = 0f;

        float DistYT = 0f; //defining variables for use later
        public bool electrified = false;
        public bool emeraldG;
        public bool enchantedSet = false;
        public bool findTreasure2;
        public bool forestGuardianJunior = false;
        public bool foundChest = false;
        public int giftCooldown = 0;
        public int giftCooldown2;
        public bool gooFishingPole = false;
        public bool guardianHeart;
        public bool guardianHeart2;
        public int healBonus;
        public bool hitHeal = false;
        public int hitsToHeal = 0;
        public bool hRing = false;
        public bool injured = false;
        public bool livingEmerald = false;
        public int magicalHealCooldown;
        public bool manaPrism = false;
        public bool mechanicalHeart = false;
        private int MinionID = -1;

        private int MinionType = -1;
        public bool mirrorShield = false;
        public bool mirrorZone = false;
        public bool mRing = false;
        public bool necromancerSet = false;
        public bool OpenTargetUndeadMiner = false;
        public bool OpenWindow = false;
        public bool OpenWindow3 = false;
        public bool OpenWindow4 = false;
        public bool parrot = false;
        public bool RavenousSpores = false;
        public bool ringEquip = false;
        public bool roguesBelt = false;
        public bool rubyG;
        public bool RuneofBleeding = false;
        public bool RuneofTranquility = false;
        public bool RuneofWrath = false;
        public bool sapphireG;
        public bool SatBow = false;
        public bool scuba = false;
        public bool shadowflameCandle = false;
        public bool shadowflameCharm = false;
        public bool shadowflameImbue = false;
        public bool snowflake = false;
        public bool snowOwl = false;
        public bool specterG;
        public bool starStone = false;
        public double stopTime;
        public bool swarmerS = false;
        public bool SwordsmanGuide = false;

        private int targetHit = 0;
        public bool thoriumBlunderbuss = false;
        public int thrownCost;
        private int timer = 0;
        public float timeToSpawn = 0.0f;
        public bool tLuck;
        public bool topazG;
        public int VoltCharge = 0;
        public bool brokenRod = false;

        public bool healingBonus = false;

        public static double PausedTime
        {
            get
            {
                return _pausedTime;
            }
            set
            {
                _pausedTime = value;
            }
        }
		
		public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (Antiaris.hideTracker.JustPressed)
                QuestTrackerUI.visible = !QuestTrackerUI.visible;
        }

        public static bool TimePaused { get; set; }

        public override void UpdateBiomeVisuals()
        {
            var Antlion = false;
            if (Antlion)
            {
                Sky.color = new Color(0.9f, 0.5f, 0.2f);
            }
            for (var k = 0; k < 200; k++)
            {
                var Queen = Main.npc[k];
                if (Queen.type == mod.NPCType("AntlionQueen") && Queen.life < Queen.lifeMax * 0.15f)
                {
                    Antlion = true;
                }
                if (Queen.type == mod.NPCType("AntlionQueen") && !Queen.active)
                {
                    Antlion = false;
                }
            }
			var aPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
            player.ManageSpecialBiomeVisuals("Antiaris:TimeSky", AntiarisWorld.frozenTime);
            player.ManageSpecialBiomeVisuals("Antiaris:AntlionQueen", Antlion);
			player.ManageSpecialBiomeVisuals("Antiaris:Corruption", !AntiarisWorld.DownedTowerKeeper && (player.ZoneCorrupt || player.ZoneCrimson) && (!NPC.AnyNPCs(mod.NPCType("TowerKeeper")) || !NPC.AnyNPCs(mod.NPCType("TowerKeeper2")) ||!NPC.AnyNPCs(mod.NPCType("TowerKeeperNonActive"))));
        }

        public override void Initialize()
        {
            foundChest = false;
        }

        public override void ResetEffects()
        {
            guardianHeart2 = false;
            guardianHeart = false;
            calmnessSpirit = false;
            tLuck = false;
            discipleSet = false;
            findTreasure2 = false;
            magicalHealCooldown = 0;
            healBonus = 0;
            giftCooldown2 = 0;
            rubyG = false;
            emeraldG = false;
            diamondG = false;
            topazG = false;
            sapphireG = false;
            amethystG = false;
            specterG = false;
            mirrorZone = false;
            enchantedSet = false;
            forestGuardianJunior = false;
            RuneofWrath = false;
            RuneofTranquility = false;
            RuneofBleeding = false;
            parrot = false;
            TrapsImmune = false;
            SatBow = false;
            gooFishingPole = false;
            foundChest = false;
            aItems = false;
            bigMinions = false;
            swarmerS = false;
            scuba = false;
            Bonebardier = false;
            RavenousSpores = false;
            necromancerSet = false;
            SwordsmanGuide = false;
            antlionSet = false;
			snowflake = false;
			boilingPoint = false;
			cherryBlossom = false;
			thoriumBlunderbuss = false;
			despairingFlames = false;
			despairingFlamesB = false;
			injured = false;
			livingEmerald = false;
			mirrorShield = false;
			snowOwl = false;
			bloodsteal = false;
			hitHeal = false;
			critHeal = false;
			manaPrism = false;
			shadowflameCharm = false;
			shadowflameImbue = false;
			bizzare = false;
			electrified = false;
			deceleration = false;
			roguesBelt = false;
			thrownCost = 0;
			shadowflameCandle = false;
			mechanicalHeart = false;
			starStone = false;
			ringEquip = false;
			mRing = false;
			hRing = false;
			bitesTheDust = false;
			questReady = false;
            healingBonus = false;
        }

        public override void OnEnterWorld(Player player)
        {
            string Information1 = Language.GetTextValue("Mods.Antiaris.Information1");
            ModExplorer._initialize();
			Main.NewText(Information1, 255, 194, 40);
        }

        public override void UpdateBadLifeRegen()
		{
			if (despairingFlamesB)
			{
				if (player.lifeRegen > 0)
				{
					player.lifeRegen = 0;
				}
				player.lifeRegenTime = 0;
				player.lifeRegen -= 16;
			}
			if (injured)
			{
				if (player.lifeRegen > 0)
				{
					player.lifeRegen = 0;
				}
				player.lifeRegenTime = 0;
				player.lifeRegen -= 3;
			}
			if (electrified)
			{
				Lighting.AddLight((int)player.Center.X / 16, (int)player.Center.Y / 16, 0.3f, 0.8f, 1.1f);
				if (player.lifeRegen > 0) player.lifeRegen = 0;
				player.lifeRegenTime = 0;
				player.lifeRegen -= 8;
			}
		}

        public override void DrawEffects(PlayerDrawInfo drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
		{
			if (despairingFlamesB)
			{
			    for (var i = 0; i < 2; i++)
				if (drawInfo.shadow == 0f)
				{
					int dust = Dust.NewDust(drawInfo.position, player.width, player.height, 64, player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default(Color), 1.5f);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].velocity.Y -= 2f;
					Main.playerDrawDust.Add(dust);
				}
				fullBright = true;
			}
			if (injured)
			{
			    for (var i = 0; i < 2; i++)
				if (drawInfo.shadow == 0f && Main.rand.Next(3) == 0)
				{
					int dust = Dust.NewDust(drawInfo.position, player.width, player.height, 5, player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default(Color), 1.5f);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].velocity.Y += 2f;
					Main.playerDrawDust.Add(dust);
				}
			}
			if (electrified)
			{
				if (drawInfo.shadow == 0f && Main.rand.NextBool(1, 3))
				{
					int dust = Dust.NewDust(new Vector2(drawInfo.position.X - 2f, drawInfo.position.Y - 2f), player.width + 4, player.height + 4, 226, 0.0f, 0.0f, 100, new Color(), 0.5f);
					Main.dust[dust].velocity *= 1.6f;
					--Main.dust[dust].velocity.Y;
					Main.dust[dust].position = Vector2.Lerp(Main.dust[dust].position, player.Center, 0.5f);
					Main.playerDrawDust.Add(dust);
				}
				fullBright = true;
			}
			if (deceleration)
			{
				for (int k = 0; k < 2; k++)
				{
					if (drawInfo.shadow == 0f && Main.rand.NextBool(1, 3))
					{
						int dust = Dust.NewDust(drawInfo.position, player.width, player.height, 29, player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default(Color), 1.5f);
						Main.dust[dust].noGravity = true;
						Main.playerDrawDust.Add(dust);
					}
				}
				fullBright = true;
			}
		}

        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
		{
		    string InjuredDeath = Language.GetTextValue("Mods.Antiaris.InjuredDeath", Main.LocalPlayer.name);
            if (electrified && damage == 10.0 && hitDirection == 0 && damageSource.SourceOtherIndex == 8) damageSource = PlayerDeathReason.ByOther(10);
		    if (injured) damageSource = PlayerDeathReason.ByCustomReason(InjuredDeath);
            return true;
		}

        public override void PreUpdate()
        {
            if (player.breath < 40)
            {
                if (!scuba)
                    return;
                for (var i = 0; i < 58; i++)
                {
                    if (player.inventory[i].stack > 0 && player.inventory[i].type == mod.ItemType("FilledOxygenTank"))
                    {
                        var item = player.inventory[i];
                        var Removed = Math.Min(item.stack, 1);
                        item.stack -= Removed;
                        if (item.stack <= 0)
                            item.SetDefaults();
                        player.QuickSpawnItem(mod.ItemType("EmptyOxygenTank"));
                        player.breath = player.breathMax;
                        Main.PlaySound(item.UseSound, player.Center);
                        break;
                    }
                }
            }
            int[] QItems =
            {
                mod.ItemType("StolenPresent"),
                mod.ItemType("SpiderMass"),
                mod.ItemType("SilkScarf"),
                mod.ItemType("PlatinumApple"),
                mod.ItemType("OldCompass"),
                mod.ItemType("Necronomicon"),
                mod.ItemType("MonsterSkull"),
                mod.ItemType("MagicalAmulet"),
                mod.ItemType("HarpyEgg"),
                mod.ItemType("GoldenApple"),
                mod.ItemType("GlacialCrystal"),
                mod.ItemType("DemonWingPiece"),
                mod.ItemType("Coconut"),
                mod.ItemType("AmuletPiece3"),
                mod.ItemType("AmuletPiece2"),
                mod.ItemType("AmuletPiece1"),
                mod.ItemType("AdventurersFishingRodPart3"),
                mod.ItemType("AdventurersFishingRodPart2"),
                mod.ItemType("AdventurersFishingRodPart1"),
                mod.ItemType("AdventurersFishingRod"),
                mod.ItemType("AdventurerChest"),
                mod.ItemType("EmeraldShard")
            };
            for (var i = 0; i < 59; i++)
            {
                if (player.statLife <= 0)
                {
                    if (player.inventory[i].modItem is QuestItem && player.inventory[i].stack > 0)
                    {
                        var item = Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, player.inventory[i].type, 1, false, 0, false, false);
                        Main.item[item].netDefaults(player.inventory[i].netID);
                        Main.item[item].Prefix((int)player.inventory[i].prefix);
                        Main.item[item].stack = player.inventory[i].stack;
                        Main.item[item].velocity.Y = (float)Main.rand.Next(-20, 1) * 0.2f;
                        Main.item[item].velocity.X = (float)Main.rand.Next(-20, 21) * 0.2f;
                        Main.item[item].noGrabDelay = 100;
                        Main.item[item].newAndShiny = false;
                        player.inventory[i] = new Item();
                        foreach (var item2 in QItems)
                            if (Main.mouseItem.type == item2 && Main.mouseItem.stack > 0 && Main.myPlayer == player.whoAmI)
                                Main.mouseItem = new Item();
                    }
                }
            }
			if (Main.myPlayer == player.whoAmI)
			{
				if (player.statLife > 0)
					checkGhost = true;
				if (player.statLife <= 0 && (int)player.difficulty != 2)
				{
					if (checkGhost)
						NPC.NewNPC((int)player.Center.X, (int)player.Center.Y, mod.NPCType("Ghost"), 0, Main.myPlayer, 0f, 0f, 0f, 255);
					checkGhost = false;
				}
			}
        }

        public override void PostUpdate()
        {
            ++timer;
            if (AntiarisWorld.frozenTime && Main.player[Main.myPlayer].FindBuffIndex(mod.BuffType("FrozenTime")) == -1) AntiarisWorld.frozenTime = false;
            foreach (Dust dust in Main.dust)
            {
                if (!AntiarisWorld.frozenTime)
                {
                    stopTime = Main.time;
                }
                if (AntiarisWorld.frozenTime)
                {
                    Main.time = stopTime;
                    Main.windSpeed = 0;
                }
            }
            if (building)
            {
                //NetMessage.SendTileRange(player.whoAmI, AntiarisWorld.StartPositionX, AntiarisWorld.StartPositionY - 22, 25, 27);
                buildTimer++;
                if (buildTimer == 1)
				{
                    WorldGen.PlaceTile(AntiarisWorld.StartPositionX + 4, AntiarisWorld.StartPositionY - 10, AntiarisWorld.Wood, false, true, -1, 0);
					if (Main.netMode == 1)
						NetMessage.SendTileSquare(-1, AntiarisWorld.StartPositionX + 4, AntiarisWorld.StartPositionY - 10, 1, TileChangeType.None);
				}
                if (buildTimer == 5)
				{
                    WorldGen.PlaceTile(AntiarisWorld.StartPositionX + 4, AntiarisWorld.StartPositionY - 9, AntiarisWorld.Wood, false, true, -1, 0);
					if (Main.netMode == 1)
						NetMessage.SendTileSquare(-1, AntiarisWorld.StartPositionX + 4, AntiarisWorld.StartPositionY - 9, 1, TileChangeType.None);
				}
                if (buildTimer == 10)
				{
                    WorldGen.PlaceTile(AntiarisWorld.StartPositionX + 15, AntiarisWorld.StartPositionY - 16, AntiarisWorld.Wood, false, true, -1, 0);
					if (Main.netMode == 1)
						NetMessage.SendTileSquare(-1, AntiarisWorld.StartPositionX + 15, AntiarisWorld.StartPositionY - 16, 1, TileChangeType.None);
				}
                if (buildTimer == 15)
                {
                    WorldGen.PlaceTile(AntiarisWorld.StartPositionX + 15, AntiarisWorld.StartPositionY - 15, AntiarisWorld.Wood, false, true, -1, 0);
                    Main.tile[AntiarisWorld.StartPositionX + 15, AntiarisWorld.StartPositionY - 15].slope(4);
					if (Main.netMode == 1)
						NetMessage.SendTileSquare(-1, AntiarisWorld.StartPositionX + 15, AntiarisWorld.StartPositionY - 15, 1, TileChangeType.None);
				}
                if (buildTimer == 20)
				{
                    WorldGen.PlaceTile(AntiarisWorld.StartPositionX + 16, AntiarisWorld.StartPositionY - 15, AntiarisWorld.Wood, false, true, -1, 0);
					if (Main.netMode == 1)
						NetMessage.SendTileSquare(-1, AntiarisWorld.StartPositionX + 16, AntiarisWorld.StartPositionY - 15, 1, TileChangeType.None);
				}
                if (buildTimer == 25)
				{
                    WorldGen.PlaceTile(AntiarisWorld.StartPositionX + 16, AntiarisWorld.StartPositionY - 14, AntiarisWorld.Wood, false, true, -1, 0);
					if (Main.netMode == 1)
						NetMessage.SendTileSquare(-1, AntiarisWorld.StartPositionX + 16, AntiarisWorld.StartPositionY - 14, 1, TileChangeType.None);
				}
                if (buildTimer == 30)
				{
                    WorldGen.PlaceTile(AntiarisWorld.StartPositionX + 17, AntiarisWorld.StartPositionY - 14, AntiarisWorld.Wood, false, true, -1, 0);
					if (Main.netMode == 1)
						NetMessage.SendTileSquare(-1, AntiarisWorld.StartPositionX + 17, AntiarisWorld.StartPositionY - 14, 1, TileChangeType.None);
				}
                if (buildTimer == 35)
				{
                    WorldGen.PlaceTile(AntiarisWorld.StartPositionX + 7, AntiarisWorld.StartPositionY - 5, AntiarisWorld.Wood, false, true, -1, 0);
					if (Main.netMode == 1)
						NetMessage.SendTileSquare(-1, AntiarisWorld.StartPositionX + 7, AntiarisWorld.StartPositionY - 5, 1, TileChangeType.None);
				}
                if (buildTimer == 40)
				{
                    WorldGen.PlaceTile(AntiarisWorld.StartPositionX + 16, AntiarisWorld.StartPositionY - 5, AntiarisWorld.Wood, false, true, -1, 0);
					if (Main.netMode == 1)
						NetMessage.SendTileSquare(-1, AntiarisWorld.StartPositionX + 16, AntiarisWorld.StartPositionY - 5, 1, TileChangeType.None);
				}
                if (buildTimer == 45)
				{
                    WorldGen.PlaceTile(AntiarisWorld.StartPositionX + 17, AntiarisWorld.StartPositionY - 5, AntiarisWorld.Wood, false, true, -1, 0);
					if (Main.netMode == 1)
						NetMessage.SendTileSquare(-1, AntiarisWorld.StartPositionX + 17, AntiarisWorld.StartPositionY - 5, 1, TileChangeType.None);
				}
                if (buildTimer == 50)
				{
                    WorldGen.PlaceTile(AntiarisWorld.StartPositionX + 18, AntiarisWorld.StartPositionY - 5, AntiarisWorld.Wood, false, true, -1, 0);
					if (Main.netMode == 1)
						NetMessage.SendTileSquare(-1, AntiarisWorld.StartPositionX + 18, AntiarisWorld.StartPositionY - 5, 1, TileChangeType.None);
				}
                if (buildTimer == 55)
                {
                    WorldGen.PlaceTile(AntiarisWorld.StartPositionX + 4, AntiarisWorld.StartPositionY - 15, AntiarisWorld.Brick, false, true, -1, 0);
                    Main.tile[AntiarisWorld.StartPositionX + 4, AntiarisWorld.StartPositionY - 15].slope(2);
					if (Main.netMode == 1)
						NetMessage.SendTileSquare(-1, AntiarisWorld.StartPositionX + 4, AntiarisWorld.StartPositionY - 15, 1, TileChangeType.None);
				}
                if (buildTimer == 60)
                {
                    WorldGen.PlaceTile(AntiarisWorld.StartPositionX + 3, AntiarisWorld.StartPositionY - 14, AntiarisWorld.Brick, false, true, -1, 0);
                    Main.tile[AntiarisWorld.StartPositionX + 3, AntiarisWorld.StartPositionY - 14].slope(2);
					if (Main.netMode == 1)
						NetMessage.SendTileSquare(-1, AntiarisWorld.StartPositionX + 3, AntiarisWorld.StartPositionY - 14, 1, TileChangeType.None);
				}
                if (buildTimer == 65)
				{
                    WorldGen.PlaceTile(AntiarisWorld.StartPositionX + 4, AntiarisWorld.StartPositionY - 13, AntiarisWorld.Brick, false, true, -1, 0);
					if (Main.netMode == 1)
						NetMessage.SendTileSquare(-1, AntiarisWorld.StartPositionX + 4, AntiarisWorld.StartPositionY - 13, 1, TileChangeType.None);
				}
                if (buildTimer == 70)
                {
                    WorldGen.PlaceTile(AntiarisWorld.StartPositionX + 2, AntiarisWorld.StartPositionY - 13, AntiarisWorld.Brick, false, true, -1, 0);
                    Main.tile[AntiarisWorld.StartPositionX + 2, AntiarisWorld.StartPositionY - 13].slope(2);
					if (Main.netMode == 1)
						NetMessage.SendTileSquare(-1, AntiarisWorld.StartPositionX + 2, AntiarisWorld.StartPositionY - 13, 1, TileChangeType.None);
				}
                if (buildTimer == 75)
				{
                    WorldGen.PlaceTile(AntiarisWorld.StartPositionX + 2, AntiarisWorld.StartPositionY - 12, AntiarisWorld.Brick, false, true, -1, 0);
					if (Main.netMode == 1)
						NetMessage.SendTileSquare(-1, AntiarisWorld.StartPositionX + 2, AntiarisWorld.StartPositionY - 12, 1, TileChangeType.None);
				}
                if (buildTimer == 80)
				{
                    WorldGen.PlaceTile(AntiarisWorld.StartPositionX + 3, AntiarisWorld.StartPositionY - 12, AntiarisWorld.Brick, false, true, -1, 0);
					if (Main.netMode == 1)
						NetMessage.SendTileSquare(-1, AntiarisWorld.StartPositionX + 3, AntiarisWorld.StartPositionY - 12, 1, TileChangeType.None);
				}
                if (buildTimer == 85)
				{
                    WorldGen.PlaceTile(AntiarisWorld.StartPositionX + 3, AntiarisWorld.StartPositionY - 13, AntiarisWorld.Brick, false, true, -1, 0);
					if (Main.netMode == 1)
						NetMessage.SendTileSquare(-1, AntiarisWorld.StartPositionX + 3, AntiarisWorld.StartPositionY - 13, 1, TileChangeType.None);
				}
                if (buildTimer == 90)
				{
                    WorldGen.PlaceTile(AntiarisWorld.StartPositionX + 15, AntiarisWorld.StartPositionY - 17, AntiarisWorld.Brick, false, true, -1, 0);
					if (Main.netMode == 1)
						NetMessage.SendTileSquare(-1, AntiarisWorld.StartPositionX + 15, AntiarisWorld.StartPositionY - 17, 1, TileChangeType.None);
				}
                if (buildTimer == 95)
				{
                    WorldGen.PlaceTile(AntiarisWorld.StartPositionX + 16, AntiarisWorld.StartPositionY - 17, AntiarisWorld.Brick, false, true, -1, 0);
					if (Main.netMode == 1)
						NetMessage.SendTileSquare(-1, AntiarisWorld.StartPositionX + 16, AntiarisWorld.StartPositionY - 17, 1, TileChangeType.None);
				}
                if (buildTimer == 100)
				{
                    WorldGen.PlaceTile(AntiarisWorld.StartPositionX + 16, AntiarisWorld.StartPositionY - 16, AntiarisWorld.Brick, false, true, -1, 0);
					if (Main.netMode == 1)
						NetMessage.SendTileSquare(-1, AntiarisWorld.StartPositionX + 16, AntiarisWorld.StartPositionY - 16, 1, TileChangeType.None);
				}
                if (buildTimer == 105)
				{
                    WorldGen.PlaceTile(AntiarisWorld.StartPositionX + 17, AntiarisWorld.StartPositionY - 16, AntiarisWorld.Brick, false, true, -1, 0);
					if (Main.netMode == 1)
						NetMessage.SendTileSquare(-1, AntiarisWorld.StartPositionX + 17, AntiarisWorld.StartPositionY - 16, 1, TileChangeType.None);
				}
                if (buildTimer == 110)
				{
                    WorldGen.PlaceTile(AntiarisWorld.StartPositionX + 17, AntiarisWorld.StartPositionY - 15, AntiarisWorld.Brick, false, true, -1, 0);
					if (Main.netMode == 1)
						NetMessage.SendTileSquare(-1, AntiarisWorld.StartPositionX + 17, AntiarisWorld.StartPositionY - 15, 1, TileChangeType.None);
				}
                if (buildTimer == 115)
                {
                    WorldGen.PlaceTile(AntiarisWorld.StartPositionX + 18, AntiarisWorld.StartPositionY - 16, AntiarisWorld.Brick, false, true, -1, 0);
                    Main.tile[AntiarisWorld.StartPositionX + 18, AntiarisWorld.StartPositionY - 16].slope(1);
					if (Main.netMode == 1)
						NetMessage.SendTileSquare(-1, AntiarisWorld.StartPositionX + 18, AntiarisWorld.StartPositionY - 16, 1, TileChangeType.None);
				}
                if (buildTimer == 120)
                {
                    WorldGen.PlaceTile(AntiarisWorld.StartPositionX + 17, AntiarisWorld.StartPositionY - 17, AntiarisWorld.Brick, false, true, -1, 0);
                    Main.tile[AntiarisWorld.StartPositionX + 17, AntiarisWorld.StartPositionY - 17].slope(1);
					if (Main.netMode == 1)
						NetMessage.SendTileSquare(-1, AntiarisWorld.StartPositionX + 17, AntiarisWorld.StartPositionY - 17, 1, TileChangeType.None);
				}
                if (buildTimer == 125)
                {
                    WorldGen.PlaceTile(AntiarisWorld.StartPositionX + 16, AntiarisWorld.StartPositionY - 18, AntiarisWorld.Brick, false, true, -1, 0);
                    Main.tile[AntiarisWorld.StartPositionX + 16, AntiarisWorld.StartPositionY - 18].slope(1);
					if (Main.netMode == 1)
						NetMessage.SendTileSquare(-1, AntiarisWorld.StartPositionX + 16, AntiarisWorld.StartPositionY - 18, 1, TileChangeType.None);
				}
                if (buildTimer == 130)
				{
                    WorldGen.PlaceWall(AntiarisWorld.StartPositionX + 16, AntiarisWorld.StartPositionY - 13, 78, true);
					if (Main.netMode == 1)
						NetMessage.SendTileSquare(-1, AntiarisWorld.StartPositionX + 16, AntiarisWorld.StartPositionY - 13, 1, TileChangeType.None);
				}
                if (buildTimer == 135)
                {
                    WorldGen.PlaceWall(AntiarisWorld.StartPositionX + 16, AntiarisWorld.StartPositionY - 14, 78, true);
                    Main.tile[AntiarisWorld.StartPositionX + 16, AntiarisWorld.StartPositionY - 14].slope(4);
					if (Main.netMode == 1)
						NetMessage.SendTileSquare(-1, AntiarisWorld.StartPositionX + 16, AntiarisWorld.StartPositionY - 14, 1, TileChangeType.None);
				}
                if (buildTimer == 140)
				{
                    WorldGen.PlaceWall(AntiarisWorld.StartPositionX + 6, AntiarisWorld.StartPositionY - 7, 78, true);
					if (Main.netMode == 1)
						NetMessage.SendTileSquare(-1, AntiarisWorld.StartPositionX + 1, AntiarisWorld.StartPositionY - 7, 1, TileChangeType.None);
				}
                if (buildTimer == 145)
				{	
					WorldGen.PlaceWall(AntiarisWorld.StartPositionX + 6, AntiarisWorld.StartPositionY - 8, 78, true);
					if (Main.netMode == 1)
						NetMessage.SendTileSquare(-1, AntiarisWorld.StartPositionX + 6, AntiarisWorld.StartPositionY - 8, 1, TileChangeType.None);
				}
                if (buildTimer == 150)
				{
                    WorldGen.PlaceWall(AntiarisWorld.StartPositionX + 6, AntiarisWorld.StartPositionY - 9, 78, true);
					if (Main.netMode == 1)
						NetMessage.SendTileSquare(-1, AntiarisWorld.StartPositionX + 6, AntiarisWorld.StartPositionY - 9, 1, TileChangeType.None);
				}
                if (buildTimer == 155)
				{
                    WorldGen.PlaceWall(AntiarisWorld.StartPositionX + 12, AntiarisWorld.StartPositionY - 8, 78, true);
					if (Main.netMode == 1)
						NetMessage.SendTileSquare(-1, AntiarisWorld.StartPositionX + 12, AntiarisWorld.StartPositionY - 8, 1, TileChangeType.None);
				}
                if (buildTimer == 160)
				{
                    WorldGen.PlaceWall(AntiarisWorld.StartPositionX + 12, AntiarisWorld.StartPositionY - 7, 78, true);
					if (Main.netMode == 1)
						NetMessage.SendTileSquare(-1, AntiarisWorld.StartPositionX + 12, AntiarisWorld.StartPositionY - 7, 1, TileChangeType.None);
				}
                if (buildTimer == 165)
				{
                    WorldGen.PlaceWall(AntiarisWorld.StartPositionX + 12, AntiarisWorld.StartPositionY - 6, 78, true);
					if (Main.netMode == 1)
						NetMessage.SendTileSquare(-1, AntiarisWorld.StartPositionX + 12, AntiarisWorld.StartPositionY - 6, 1, TileChangeType.None);
				}
                if (buildTimer == 170)
				{
                    WorldGen.PlaceWall(AntiarisWorld.StartPositionX + 12, AntiarisWorld.StartPositionY - 5, 78, true);
					if (Main.netMode == 1)
						NetMessage.SendTileSquare(-1, AntiarisWorld.StartPositionX + 12, AntiarisWorld.StartPositionY - 5, 1, TileChangeType.None);
				}
                if (buildTimer == 175)
				{
                    WorldGen.PlaceWall(AntiarisWorld.StartPositionX + 17, AntiarisWorld.StartPositionY - 13, 27, true);
					if (Main.netMode == 1)
						NetMessage.SendTileSquare(-1, AntiarisWorld.StartPositionX + 17, AntiarisWorld.StartPositionY - 13, 1, TileChangeType.None);
				}
                if (buildTimer == 180)
				{
                    WorldGen.PlaceWall(AntiarisWorld.StartPositionX + 15, AntiarisWorld.StartPositionY - 15, 27, true);
					if (Main.netMode == 1)
						NetMessage.SendTileSquare(-1, AntiarisWorld.StartPositionX + 15, AntiarisWorld.StartPositionY - 15, 1, TileChangeType.None);
				}
                if (buildTimer == 185)
				{
                    WorldGen.PlaceWall(AntiarisWorld.StartPositionX + 15, AntiarisWorld.StartPositionY - 14, 27, true);
					if (Main.netMode == 1)
						NetMessage.SendTileSquare(-1, AntiarisWorld.StartPositionX + 15, AntiarisWorld.StartPositionY - 14, 1, TileChangeType.None);
				}
                if (buildTimer == 190)
				{
                    WorldGen.PlaceWall(AntiarisWorld.StartPositionX + 15, AntiarisWorld.StartPositionY - 13, 27, true);
					if (Main.netMode == 1)
						NetMessage.SendTileSquare(-1, AntiarisWorld.StartPositionX + 15, AntiarisWorld.StartPositionY - 13, 1, TileChangeType.None);
				}
                if (buildTimer == 195)
				{
                    WorldGen.PlaceWall(AntiarisWorld.StartPositionX + 15, AntiarisWorld.StartPositionY - 16, 27, true);
					if (Main.netMode == 1)
						NetMessage.SendTileSquare(-1, AntiarisWorld.StartPositionX + 15, AntiarisWorld.StartPositionY - 16, 1, TileChangeType.None);
				}
                if (buildTimer == 200)
				{
                    WorldGen.PlaceWall(AntiarisWorld.StartPositionX + 14, AntiarisWorld.StartPositionY - 16, 27, true);
					if (Main.netMode == 1)
						NetMessage.SendTileSquare(-1, AntiarisWorld.StartPositionX + 14, AntiarisWorld.StartPositionY - 16, 1, TileChangeType.None);
				}
                if (buildTimer == 205)
				{
                    WorldGen.PlaceWall(AntiarisWorld.StartPositionX + 5, AntiarisWorld.StartPositionY - 7, AntiarisWorld.WoodWall, true);
					if (Main.netMode == 1)
						NetMessage.SendTileSquare(-1, AntiarisWorld.StartPositionX + 5, AntiarisWorld.StartPositionY - 7, 1, TileChangeType.None);
				}
                if (buildTimer == 210)
				{
                    WorldGen.PlaceWall(AntiarisWorld.StartPositionX + 5, AntiarisWorld.StartPositionY - 8, AntiarisWorld.WoodWall, true);
					if (Main.netMode == 1)
						NetMessage.SendTileSquare(-1, AntiarisWorld.StartPositionX + 5, AntiarisWorld.StartPositionY - 8, 1, TileChangeType.None);
				}
                if (buildTimer == 215)
				{
                    WorldGen.PlaceWall(AntiarisWorld.StartPositionX + 5, AntiarisWorld.StartPositionY - 9, AntiarisWorld.WoodWall, true);
					if (Main.netMode == 1)
						NetMessage.SendTileSquare(-1, AntiarisWorld.StartPositionX + 5, AntiarisWorld.StartPositionY - 9, 1, TileChangeType.None);
				}
                if (buildTimer == 220)
				{
                    WorldGen.PlaceWall(AntiarisWorld.StartPositionX + 5, AntiarisWorld.StartPositionY - 10, AntiarisWorld.WoodWall, true);
					if (Main.netMode == 1)
						NetMessage.SendTileSquare(-1, AntiarisWorld.StartPositionX + 5, AntiarisWorld.StartPositionY - 10, 1, TileChangeType.None);
				}
                if (buildTimer == 225)
				{
                    WorldGen.PlaceWall(AntiarisWorld.StartPositionX + 7, AntiarisWorld.StartPositionY - 8, AntiarisWorld.WoodWall, true);
					if (Main.netMode == 1)
						NetMessage.SendTileSquare(-1, AntiarisWorld.StartPositionX + 7, AntiarisWorld.StartPositionY - 8, 1, TileChangeType.None);
				}
                if (buildTimer == 230)
				{
                    WorldGen.PlaceWall(AntiarisWorld.StartPositionX + 7, AntiarisWorld.StartPositionY - 9, AntiarisWorld.WoodWall, true);
					if (Main.netMode == 1)
						NetMessage.SendTileSquare(-1, AntiarisWorld.StartPositionX + 7, AntiarisWorld.StartPositionY - 9, 1, TileChangeType.None);
				}
                if (buildTimer == 240)
				{
                    WorldGen.PlaceWall(AntiarisWorld.StartPositionX + 11, AntiarisWorld.StartPositionY - 6, AntiarisWorld.WoodWall, true);
					if (Main.netMode == 1)
						NetMessage.SendTileSquare(-1, AntiarisWorld.StartPositionX + 11, AntiarisWorld.StartPositionY - 6, 1, TileChangeType.None);
				}
                if (buildTimer == 245)
				{
                    WorldGen.PlaceWall(AntiarisWorld.StartPositionX + 11, AntiarisWorld.StartPositionY - 7, AntiarisWorld.WoodWall, true);
					if (Main.netMode == 1)
						NetMessage.SendTileSquare(-1, AntiarisWorld.StartPositionX + 11, AntiarisWorld.StartPositionY - 7, 1, TileChangeType.None);
				}
                if (buildTimer == 250)
				{
                    WorldGen.PlaceWall(AntiarisWorld.StartPositionX + 13, AntiarisWorld.StartPositionY - 6, AntiarisWorld.WoodWall, true);
					if (Main.netMode == 1)
						NetMessage.SendTileSquare(-1, AntiarisWorld.StartPositionX + 13, AntiarisWorld.StartPositionY - 6, 1, TileChangeType.None);
				}
                if (buildTimer == 255)
				{
                    WorldGen.PlaceWall(AntiarisWorld.StartPositionX + 13, AntiarisWorld.StartPositionY - 7, AntiarisWorld.WoodWall, true);
					if (Main.netMode == 1)
						NetMessage.SendTileSquare(-1, AntiarisWorld.StartPositionX + 13, AntiarisWorld.StartPositionY - 7, 1, TileChangeType.None);
				}
                if (buildTimer == 260)
				{
                    WorldGen.PlaceWall(AntiarisWorld.StartPositionX + 13, AntiarisWorld.StartPositionY - 8, AntiarisWorld.WoodWall, true);
					if (Main.netMode == 1)
						NetMessage.SendTileSquare(-1, AntiarisWorld.StartPositionX + 13, AntiarisWorld.StartPositionY - 8, 1, TileChangeType.None);
				}
                if (buildTimer == 265)
				{
                    WorldGen.PlaceWall(AntiarisWorld.StartPositionX + 14, AntiarisWorld.StartPositionY - 6, AntiarisWorld.WoodWall, true);
					if (Main.netMode == 1)
						NetMessage.SendTileSquare(-1, AntiarisWorld.StartPositionX + 14, AntiarisWorld.StartPositionY - 6, 1, TileChangeType.None);
				}
                if (buildTimer == 270)
				{
                    WorldGen.PlaceWall(AntiarisWorld.StartPositionX + 15, AntiarisWorld.StartPositionY - 6, AntiarisWorld.WoodWall, true);
					if (Main.netMode == 1)
						NetMessage.SendTileSquare(-1, AntiarisWorld.StartPositionX + 15, AntiarisWorld.StartPositionY - 6, 1, TileChangeType.None);
				}
                if (buildTimer == 275)
				{
                    WorldGen.PlaceObject(AntiarisWorld.StartPositionX + 4, AntiarisWorld.StartPositionY - 8, 10, true, AntiarisWorld.Door);
					if (Main.netMode == 1)
						NetMessage.SendTileSquare(-1, AntiarisWorld.StartPositionX + 4, AntiarisWorld.StartPositionY - 8, 1, TileChangeType.None);
				}
                if (buildTimer == 280)
				{
                    WorldGen.PlaceObject(AntiarisWorld.StartPositionX + 13, AntiarisWorld.StartPositionY - 6, 15, true, 0, 1, AntiarisWorld.Chair);
					if (Main.netMode == 1)
						NetMessage.SendTileSquare(-1, AntiarisWorld.StartPositionX + 13, AntiarisWorld.StartPositionY - 6, 1, TileChangeType.None);
				}
                if (buildTimer >= 290)
                {
                    buildTimer = 0;
                    building = false;
                }
            }
            if (timer % 1 == 0)
            {
                if (red > 35 && !change)
                {
                    red--;
                }
                if (blue < 225 && !change)
                {
                    blue++;
                }
                if (green < 65 && !change)
                {
                    green++;
                }
                if (red == 35 && blue == 225 && green == 65)
                {
                    change = true;
                }
                if (red < 125 && change)
                {
                    red++;
                }
                if (blue > 25 && change)
                {
                    blue--;
                }
                if (green > 35 && change)
                {
                    green--;
                }
                if (red == 125 && blue == 25 && green == 35)
                {
                    change = false;
                }
            }
            if (!player.dead)
            {
                if (!swarmerS)
                    return;
                if (player.ownedProjectileCounts[mod.ProjectileType("AntlionSummon")] <= 2 && timer % 540 == 0)
                {
                    AntiarisHelper.CreateDust(player, 64, 40);
                    Projectile.NewProjectile(player.position, Vector2.Zero, mod.ProjectileType("AntlionSummon"), 0, 0, player.whoAmI);
                }
            }
            if (player.mount.Active && player.mount.Type == mod.MountType("EmeraldSlime") && player.wetSlime == 0 && player.velocity.Y > 0f)
            {
                if (player.gravDir == 1f)
                {
                    if (player.velocity.Y > player.maxFallSpeed)
                    {
                        player.velocity.Y = player.maxFallSpeed;
                    }
                    if (player.slowFall && player.velocity.Y > player.maxFallSpeed / 3f && !player.controlDown)
                    {
                        player.velocity.Y = player.maxFallSpeed / 3f;
                    }
                    if (player.slowFall && player.velocity.Y > player.maxFallSpeed / 5f && player.controlUp)
                    {
                        player.velocity.Y = player.maxFallSpeed / 10f;
                    }
                }
                else
                {
                    if (player.velocity.Y < -player.maxFallSpeed)
                    {
                        player.velocity.Y = -player.maxFallSpeed;
                    }
                    if (player.slowFall && player.velocity.Y < -player.maxFallSpeed / 3f && !player.controlDown)
                    {
                        player.velocity.Y = -player.maxFallSpeed / 3f;
                    }
                    if (player.slowFall && player.velocity.Y < -player.maxFallSpeed / 5f && player.controlUp)
                    {
                        player.velocity.Y = -player.maxFallSpeed / 10f;
                    }
                }
                //start using vanilla code
                if (player.controlJump)
                {
                    bool flag = false;
                    if (player.mount.Active && player.mount.Type == mod.MountType("EmeraldSlime") && player.wetSlime > 0)
                    {
                        flag = true;
                    }
                    bool flag2;
                    bool flag3;
                    bool flag4;
                    bool flag5;
                    bool flag6;
                    bool flag7;
                    int arg_5D4_0;
                    float arg_5E1_0;
                    int arg_63D_0;
                    float arg_64A_0;
                    int num4;
                    int j;
                    int num5;
                    Dust expr_795_cp_0;
                    Dust expr_7C5_cp_0;
                    Dust expr_7F3_cp_0;
                    Vector2 value;
                    int num6;
                    int k;
                    int num7;
                    int num8;
                    int arg_D06_0;
                    float arg_D13_0;
                    Vector2 center;
                    Vector2 value2;
                    float num9;
                    int l;
                    float num10;
                    Dust dust;
                    Vector2 vector;
                    int num11;
                    int m;
                    int num12;
                    int num13;
                    if (player.jump > 0)
                    {
                        if (player.velocity.Y == 0f)
                        {
                            player.jump = 0;
                        }
                        else
                        {
                            player.velocity.Y = -Player.jumpSpeed * player.gravDir;
                            if (player.merman && (!player.mount.Active || !player.mount.Cart))
                            {
                                if (player.swimTime <= 10)
                                {
                                    player.swimTime = 30;
                                }
                            }
                            else
                            {
                                player.jump--;
                            }
                        }
                    }
                    else if ((player.sliding || player.velocity.Y == 0f || flag || player.jumpAgainCloud || player.jumpAgainSandstorm || player.jumpAgainBlizzard || player.jumpAgainFart || player.jumpAgainSail || player.jumpAgainUnicorn || (player.wet && player.accFlipper && (!player.mount.Active || !player.mount.Cart))) && (player.releaseJump || (player.autoJump && (player.velocity.Y == 0f || player.sliding))))
                    {
                        if (player.sliding || player.velocity.Y == 0f)
                        {
                            player.justJumped = true;
                        }
                        flag2 = false;
                        if (player.wet && player.accFlipper)
                        {
                            if (player.swimTime == 0)
                            {
                                player.swimTime = 30;
                            }
                            flag2 = true;
                        }
                        flag3 = false;
                        flag4 = false;
                        flag5 = false;
                        flag6 = false;
                        flag7 = false;
                        if (!flag)
                        {
                            if (player.jumpAgainUnicorn)
                            {
                                flag7 = true;
                                player.jumpAgainUnicorn = false;
                            }
                            else if (player.jumpAgainSandstorm)
                            {
                                flag3 = true;
                                player.jumpAgainSandstorm = false;
                            }
                            else if (player.jumpAgainBlizzard)
                            {
                                flag4 = true;
                                player.jumpAgainBlizzard = false;
                            }
                            else if (player.jumpAgainFart)
                            {
                                player.jumpAgainFart = false;
                                flag5 = true;
                            }
                            else if (player.jumpAgainSail)
                            {
                                player.jumpAgainSail = false;
                                flag6 = true;
                            }
                            else
                            {
                                player.jumpAgainCloud = false;
                            }
                        }
                        player.canRocket = false;
                        player.rocketRelease = false;
                        if ((player.velocity.Y == 0f || player.sliding || (player.autoJump && player.justJumped)) && player.doubleJumpCloud)
                        {
                            player.jumpAgainCloud = true;
                        }
                        if ((player.velocity.Y == 0f || player.sliding || (player.autoJump && player.justJumped)) && player.doubleJumpSandstorm)
                        {
                            player.jumpAgainSandstorm = true;
                        }
                        if ((player.velocity.Y == 0f || player.sliding || (player.autoJump && player.justJumped)) && player.doubleJumpBlizzard)
                        {
                            player.jumpAgainBlizzard = true;
                        }
                        if ((player.velocity.Y == 0f || player.sliding || (player.autoJump && player.justJumped)) && player.doubleJumpFart)
                        {
                            player.jumpAgainFart = true;
                        }
                        if ((player.velocity.Y == 0f || player.sliding || (player.autoJump && player.justJumped)) && player.doubleJumpSail)
                        {
                            player.jumpAgainSail = true;
                        }
                        if ((player.velocity.Y == 0f || player.sliding || (player.autoJump && player.justJumped)) && player.doubleJumpUnicorn)
                        {
                            player.jumpAgainUnicorn = true;
                        }
                        if (player.velocity.Y == 0f || flag2 || player.sliding || flag)
                        {
                            player.velocity.Y = -Player.jumpSpeed * player.gravDir;
                            player.jump = Player.jumpHeight;
                            if (player.sliding)
                            {
                                player.velocity.X = (float)(3 * -(float)player.slideDir);
                            }
                        }
                        else if (flag3)
                        {
                            player.dJumpEffectSandstorm = true;
                            arg_5D4_0 = player.height;
                            arg_5E1_0 = player.gravDir;
                            Main.PlaySound(16, (int)player.position.X, (int)player.position.Y, 1);
                            player.velocity.Y = -Player.jumpSpeed * player.gravDir;
                            player.jump = Player.jumpHeight * 3;
                        }
                        else if (flag4)
                        {
                            player.dJumpEffectBlizzard = true;
                            arg_63D_0 = player.height;
                            arg_64A_0 = player.gravDir;
                            Main.PlaySound(16, (int)player.position.X, (int)player.position.Y, 1);
                            player.velocity.Y = -Player.jumpSpeed * player.gravDir;
                            player.jump = (int)((double)Player.jumpHeight * 1.5);
                        }
                        else if (flag6)
                        {
                            player.dJumpEffectSail = true;
                            num4 = player.height;
                            if (player.gravDir == -1f)
                            {
                                num4 = 0;
                            }
                            Main.PlaySound(16, (int)player.position.X, (int)player.position.Y, 1);
                            player.velocity.Y = -Player.jumpSpeed * player.gravDir;
                            player.jump = (int)((double)Player.jumpHeight * 1.25);
                            for (j = 0; j < 30; j++)
                            {
                                num5 = Dust.NewDust(new Vector2(player.position.X, player.position.Y + (float)num4), player.width, 12, 253, player.velocity.X * 0.3f, player.velocity.Y * 0.3f, 100, default(Color), 1.5f);
                                if (j % 2 == 0)
                                {
                                    expr_795_cp_0 = Main.dust[num5];
                                    expr_795_cp_0.velocity.X = expr_795_cp_0.velocity.X + (float)Main.rand.Next(30, 71) * 0.1f;
                                }
                                else
                                {
                                    expr_7C5_cp_0 = Main.dust[num5];
                                    expr_7C5_cp_0.velocity.X = expr_7C5_cp_0.velocity.X - (float)Main.rand.Next(30, 71) * 0.1f;
                                }
                                expr_7F3_cp_0 = Main.dust[num5];
                                expr_7F3_cp_0.velocity.Y = expr_7F3_cp_0.velocity.Y + (float)Main.rand.Next(-10, 31) * 0.1f;
                                Main.dust[num5].noGravity = true;
                                Main.dust[num5].scale += (float)Main.rand.Next(-10, 41) * 0.01f;
                                Main.dust[num5].velocity *= Main.dust[num5].scale * 0.7f;
                                value = new Vector2((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
                                value.Normalize();
                                value *= (float)Main.rand.Next(81) * 0.1f;
                            }
                        }
                        else if (flag5)
                        {
                            player.dJumpEffectFart = true;
                            num6 = player.height;
                            if (player.gravDir == -1f)
                            {
                                num6 = 0;
                            }
                            Main.PlaySound(2, (int)player.position.X, (int)player.position.Y, 16);
                            player.velocity.Y = -Player.jumpSpeed * player.gravDir;
                            player.jump = Player.jumpHeight * 2;
                            for (k = 0; k < 10; k++)
                            {
                                num7 = Dust.NewDust(new Vector2(player.position.X - 34f, player.position.Y + (float)num6 - 16f), 102, 32, 188, -player.velocity.X * 0.5f, player.velocity.Y * 0.5f, 100, default(Color), 1.5f);
                                Main.dust[num7].velocity.X = Main.dust[num7].velocity.X * 0.5f - player.velocity.X * 0.1f;
                                Main.dust[num7].velocity.Y = Main.dust[num7].velocity.Y * 0.5f - player.velocity.Y * 0.3f;
                            }
                            num8 = Gore.NewGore(new Vector2(player.position.X + (float)(player.width / 2) - 16f, player.position.Y + (float)num6 - 16f), new Vector2(-player.velocity.X, -player.velocity.Y), Main.rand.Next(435, 438), 1f);
                            Main.gore[num8].velocity.X = Main.gore[num8].velocity.X * 0.1f - player.velocity.X * 0.1f;
                            Main.gore[num8].velocity.Y = Main.gore[num8].velocity.Y * 0.1f - player.velocity.Y * 0.05f;
                            num8 = Gore.NewGore(new Vector2(player.position.X - 36f, player.position.Y + (float)num6 - 16f), new Vector2(-player.velocity.X, -player.velocity.Y), Main.rand.Next(435, 438), 1f);
                            Main.gore[num8].velocity.X = Main.gore[num8].velocity.X * 0.1f - player.velocity.X * 0.1f;
                            Main.gore[num8].velocity.Y = Main.gore[num8].velocity.Y * 0.1f - player.velocity.Y * 0.05f;
                            num8 = Gore.NewGore(new Vector2(player.position.X + (float)player.width + 4f, player.position.Y + (float)num6 - 16f), new Vector2(-player.velocity.X, -player.velocity.Y), Main.rand.Next(435, 438), 1f);
                            Main.gore[num8].velocity.X = Main.gore[num8].velocity.X * 0.1f - player.velocity.X * 0.1f;
                            Main.gore[num8].velocity.Y = Main.gore[num8].velocity.Y * 0.1f - player.velocity.Y * 0.05f;
                        }
                        else if (flag7)
                        {
                            player.dJumpEffectUnicorn = true;
                            arg_D06_0 = player.height;
                            arg_D13_0 = player.gravDir;
                            Main.PlaySound(16, (int)player.position.X, (int)player.position.Y, 1);
                            player.velocity.Y = -Player.jumpSpeed * player.gravDir;
                            player.jump = Player.jumpHeight * 2;
                            center = player.Center;
                            value2 = new Vector2(50f, 20f);
                            num9 = 6.28318548f * Main.rand.NextFloat();
                            for (l = 0; l < 5; l++)
                            {
                                for (num10 = 0f; num10 < 14f; num10 += 1f)
                                {
                                    dust = Main.dust[Dust.NewDust(center, 0, 0, Utils.SelectRandom<int>(Main.rand, new int[]
                                    {
                                    176,
                                    177,
                                    179
                                    }), 0f, 0f, 0, default(Color), 1f)];
                                    vector = Vector2.UnitY.RotatedBy((double)(num10 * 6.28318548f / 14f + num9), default(Vector2));
                                    vector *= 0.2f * (float)l;
                                    dust.position = center + vector * value2;
                                    dust.velocity = vector + new Vector2(0f, player.gravDir * 4f);
                                    dust.noGravity = true;
                                    dust.scale = 1f + Main.rand.NextFloat() * 0.8f;
                                    dust.fadeIn = Main.rand.NextFloat() * 2f;
                                    dust.shader = GameShaders.Armor.GetSecondaryShader(player.cMount, player);
                                }
                            }
                        }
                        else
                        {
                            player.dJumpEffectCloud = true;
                            num11 = player.height;
                            if (player.gravDir == -1f)
                            {
                                num11 = 0;
                            }
                            Main.PlaySound(16, (int)player.position.X, (int)player.position.Y, 1);
                            player.velocity.Y = -Player.jumpSpeed * player.gravDir;
                            player.jump = (int)((double)Player.jumpHeight * 0.75);
                            for (m = 0; m < 10; m++)
                            {
                                num12 = Dust.NewDust(new Vector2(player.position.X - 34f, player.position.Y + (float)num11 - 16f), 102, 32, 16, -player.velocity.X * 0.5f, player.velocity.Y * 0.5f, 100, default(Color), 1.5f);
                                Main.dust[num12].velocity.X = Main.dust[num12].velocity.X * 0.5f - player.velocity.X * 0.1f;
                                Main.dust[num12].velocity.Y = Main.dust[num12].velocity.Y * 0.5f - player.velocity.Y * 0.3f;
                            }
                            num13 = Gore.NewGore(new Vector2(player.position.X + (float)(player.width / 2) - 16f, player.position.Y + (float)num11 - 16f), new Vector2(-player.velocity.X, -player.velocity.Y), Main.rand.Next(11, 14), 1f);
                            Main.gore[num13].velocity.X = Main.gore[num13].velocity.X * 0.1f - player.velocity.X * 0.1f;
                            Main.gore[num13].velocity.Y = Main.gore[num13].velocity.Y * 0.1f - player.velocity.Y * 0.05f;
                            num13 = Gore.NewGore(new Vector2(player.position.X - 36f, player.position.Y + (float)num11 - 16f), new Vector2(-player.velocity.X, -player.velocity.Y), Main.rand.Next(11, 14), 1f);
                            Main.gore[num13].velocity.X = Main.gore[num13].velocity.X * 0.1f - player.velocity.X * 0.1f;
                            Main.gore[num13].velocity.Y = Main.gore[num13].velocity.Y * 0.1f - player.velocity.Y * 0.05f;
                            num13 = Gore.NewGore(new Vector2(player.position.X + (float)player.width + 4f, player.position.Y + (float)num11 - 16f), new Vector2(-player.velocity.X, -player.velocity.Y), Main.rand.Next(11, 14), 1f);
                            Main.gore[num13].velocity.X = Main.gore[num13].velocity.X * 0.1f - player.velocity.X * 0.1f;
                            Main.gore[num13].velocity.Y = Main.gore[num13].velocity.Y * 0.1f - player.velocity.Y * 0.05f;
                        }
                    }
                    player.releaseJump = false;
                    return;
                }
                player.jump = 0;
                player.releaseJump = true;
                player.rocketRelease = true;
                //end vanilla code              
            }
            var questSystem = Main.player[Main.myPlayer].GetModPlayer<QuestSystem>();
            if (QuestSystem.BrokenRod && questSystem.CurrentQuest == -1)
            {
                QuestSystem.BrokenRod = false;
            }
        }

        public override void SetupStartInventory(IList<Item> items)
		{
			items.Clear();
			
			Item item = new Item();
			item.SetDefaults(24);
			item.stack = 1;
			items.Add(item);
			
			Item item2 = new Item();
			item2.SetDefaults(mod.ItemType("WoodenPickaxe"));
			item2.stack = 1;
			items.Add(item2);
			
			Item item3 = new Item();
			item3.SetDefaults(mod.ItemType("WoodenAxe"));
			item3.stack = 1;
			items.Add(item3);
		}

        public override void PostUpdateEquips()
        {
            if (healBonus < 0)
                healBonus = 0;
            if (mechanicalHeart) 
			{
				foreach (Item item in Main.item) 
				{
					if (item.type == 58) 
					{
						item.SetDefaults(mod.ItemType("GoldenHeart"));
					}
				}
			}
            if (healBonus > 0 && player.statLife < player.statLifeMax2 && Math.Abs(player.velocity.X) + Math.Abs(player.velocity.Y) < 1.0f)
            {
                ++timeToSpawn;
                if ((int)timeToSpawn > 70 - magicalHealCooldown)
                {
                    Vector2 xyCenter = player.Center + new Vector2(Main.rand.Next(-250, 250), Main.rand.Next(-250, 250));
                    Projectile.NewProjectile(xyCenter, Vector2.Zero, mod.ProjectileType("HeartFlame"), 0, 0.0f, player.whoAmI, 0.0f, (float)healBonus);
                    timeToSpawn = 0.0f;
                    giftCooldown += 1 + giftCooldown2;
                }
            }
            if (giftCooldown > 2)
            {
                if (rubyG)
                {
                    Vector2 xyCenter = player.Center + new Vector2(Main.rand.Next(-300, 300), Main.rand.Next(-300, 300));
                    Projectile.NewProjectile(xyCenter, Vector2.Zero, mod.ProjectileType("RubyFlame"), 0, 0.0f, player.whoAmI, 0.0f, 0.0f);
                }
                if (emeraldG)
                {
                    Vector2 xyCenter = player.Center + new Vector2(Main.rand.Next(-300, 300), Main.rand.Next(-300, 300));
                    Projectile.NewProjectile(xyCenter, Vector2.Zero, mod.ProjectileType("EmeraldFlame"), 0, 0.0f, player.whoAmI, 0.0f, 0.0f);
                }
                if (amethystG)
                {
                    Vector2 xyCenter = player.Center + new Vector2(Main.rand.Next(-300, 300), Main.rand.Next(-300, 300));
                    Projectile.NewProjectile(xyCenter, Vector2.Zero, mod.ProjectileType("AmethystFlame"), 0, 0.0f, player.whoAmI, 0.0f, 0.0f);
                }
                if (topazG)
                {
                    Vector2 xyCenter = player.Center + new Vector2(Main.rand.Next(-300, 300), Main.rand.Next(-300, 300));
                    Projectile.NewProjectile(xyCenter, Vector2.Zero, mod.ProjectileType("TopazFlame"), 0, 0.0f, player.whoAmI, 0.0f, 0.0f);
                }
                if (diamondG)
                {
                    Vector2 xyCenter = player.Center + new Vector2(Main.rand.Next(-300, 300), Main.rand.Next(-300, 300));
                    Projectile.NewProjectile(xyCenter, Vector2.Zero, mod.ProjectileType("DiamondFlame"), 0, 0.0f, player.whoAmI, 0.0f, 0.0f);
                }
                if (sapphireG)
                {
                    Vector2 xyCenter = player.Center + new Vector2(Main.rand.Next(-300, 300), Main.rand.Next(-300, 300));
                    Projectile.NewProjectile(xyCenter, Vector2.Zero, mod.ProjectileType("SapphireFlame"), 0, 0.0f, player.whoAmI, 0.0f, 0.0f);
                }
                if (specterG)
                {
                    Vector2 xyCenter = player.Center + new Vector2(Main.rand.Next(-400, 200), Main.rand.Next(-400, 200));
                    Projectile.NewProjectile(xyCenter, Vector2.Zero, mod.ProjectileType("SpecterFlame"), 0, 0.0f, player.whoAmI, 0.0f, 0.0f);
                }
                giftCooldown = 0;
            }
            if (starStone) 
			{
				foreach (Item item in Main.item) 
				{
					if (item.type == 184) 
					{
						item.SetDefaults(mod.ItemType("PlatinumStar"));
					}
				}
			}
            if (player.inventory[player.selectedItem].useAmmo == mod.ItemType("Buckshot") && (player.inventory[player.selectedItem].type == mod.ItemType("GoldHuntingBlunderbuss") || player.inventory[player.selectedItem].type == mod.ItemType("PlatinumHuntingBlunderbuss")))
            {
                player.scope = true;
            }
            if (player.inventory[player.selectedItem].type == mod.ItemType("DwarfShark"))
            {
                player.scope = true;
            }
			if (player.inventory[player.selectedItem].type == mod.ItemType("HallowedBlunderbuss"))
            {
                player.scope = true;
            }
			if (player.inventory[player.selectedItem].type == mod.ItemType("DeadShot"))
            {
                player.scope = true;
            }
            if (player.inventory[player.selectedItem].type == mod.ItemType("ThoriumBlunderbuss"))
            {
                player.scope = true;
            }
            if (player.inventory[player.selectedItem].type == mod.ItemType("TrueHallowedBlunderbuss"))
            {
                player.scope = true;
            }
            if (player.inventory[player.selectedItem].type != mod.ItemType("Note"))
            {
                OpenWindow = false;
            }
            if (player.inventory[player.selectedItem].type != mod.ItemType("TargetList1"))
            {
                OpenTargetUndeadMiner = false;
            }
            if (player.inventory[player.selectedItem].type == mod.ItemType("PruningShears"))
            {
                player.cordage = true;
            }
            if (player.inventory[player.selectedItem].type == mod.ItemType("GooFishingPole"))
            {
                if (player.itemAnimation > 0)
                {
                    gooFishingPole = true;
                }
            }
            if (player.inventory[player.selectedItem].type == mod.ItemType("Bonebardier"))
            {
                Bonebardier = true;
            }
            if (player.inventory[player.selectedItem].type == mod.ItemType("SatBow"))
            {
                SatBow = true;
            }
            if (player.inventory[player.selectedItem].type == mod.ItemType("SteelKnife"))
            {
                if (player.itemAnimation > 0)
                {
                    player.statDefense += 4;
                }
            }
			if (player.inventory[player.selectedItem].type == mod.ItemType("BoilingPoint"))
            {
                boilingPoint = true;
            }
			if (player.inventory[player.selectedItem].type == mod.ItemType("CherryBlossom"))
            {
                cherryBlossom = true;
            }
			if (player.inventory[player.selectedItem].type == mod.ItemType("HighRoller") || player.inventory[player.selectedItem].type == mod.ItemType("TrueHighRoller"))
            {
                despairingFlames = true;
            }
			if (player.inventory[player.selectedItem].type == mod.ItemType("ThoriumBlunderbuss"))
            {
                thoriumBlunderbuss = true;
            }
            if (player.inventory[player.selectedItem].type == mod.ItemType("GigaVolt"))
            {
				if (MinionType == -1)
				{
					MinionType = mod.ProjectileType("VoltCharge");
				}		
				if (MinionID == -1 || Main.projectile[MinionID].type != MinionType || !Main.projectile[MinionID].active || Main.projectile[MinionID].owner != player.whoAmI)
				{
					Projectile proj = new Projectile();
					proj.SetDefaults(MinionType);
					MinionID = Projectile.NewProjectile(player.Center.X, player.Center.Y, 10, 0, MinionType, proj.damage, proj.knockBack, player.whoAmI);
				}
				else
				{
					Main.projectile[MinionID].timeLeft = 5;
				}
            }
            if (player.inventory[player.selectedItem].melee && !player.inventory[player.selectedItem].noUseGraphic)
            {
                if (!SwordsmanGuide)
                    return;
                if (!player.inventory[player.selectedItem].autoReuse && !player.noItems)
                {
                    player.releaseUseItem = true;
                    if (player.itemAnimation == 1 && player.inventory[player.selectedItem].stack > 0)
                    {
                        if (player.inventory[player.selectedItem].shoot > 0 && player.whoAmI != Main.myPlayer && player.controlUseItem)
                        {
                            return;
                        }
                        else
                        {
                            player.itemAnimation = 0;
                        }
                    }
                }
            }

            int crystal = player.FindItem(mod.ItemType("GlacialCrystal"));
            if (crystal != -1 && player.ZoneSnow)
            {
                player.AddBuff(BuffID.Chilled, 60);
                if (player.wet && Main.expertMode)
                {
                    player.AddBuff(BuffID.Frozen, 60);
                }
            }
        }

        public override void ModifyHitByNPC(NPC npc, ref int damage, ref bool crit)
        {
            if (RuneofWrath)
            {
                player.AddBuff(mod.BuffType("Wrath"), 300);
            }
            if (RuneofTranquility)
            {
                player.AddBuff(mod.BuffType("Tranquility"), 300);
            }
            if (RuneofBleeding && Main.netMode != 2)
            {
                for (var k = 0; k < 200; k++)
                {
                    if (Main.npc[k].lifeMax > 0 && Main.npc[k].active && !Main.npc[k].friendly && Main.npc[k].damage > 0 && !Main.npc[k].dontTakeDamage)
                    {
                        var direction = Main.npc[k].direction;
                        if (Main.npc[k].velocity.X < 0f)
                        {
                            direction = -1;
                        }
                        if (Main.npc[k].velocity.X > 0f)
                        {
                            direction = 1;
                        }
                        Main.npc[k].StrikeNPC((int)25, 1f, direction, Main.rand.Next(2) == 0 ? true : false, false, false);
                    }
                }
            }
        }

        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
		{
			if(crit && critHeal)
			{
				int newLife = Main.rand.Next(4,6);
				player.statLife += newLife;
				player.HealEffect(newLife);
				NetMessage.SendData(MessageID.SpiritHeal, -1, -1, null, player.whoAmI, newLife);
			}
			if(manaPrism && Main.rand.Next(4) == 0)
			{
				target.AddBuff(BuffID.Lovestruck, 120);
			}
			if(manaPrism && target.loveStruck)
			{
				int mana = damage / 10 + Main.rand.Next(2,4);
				player.statMana += mana;
				player.ManaEffect(mana);
				NetMessage.SendData(MessageID.ManaEffect, -1, -1, null, player.whoAmI, mana);
			}
			if(shadowflameImbue && item.melee)
			{
				target.AddBuff(BuffID.ShadowFlame, 240);
			}
			float distanceTo = Vector2.Distance(player.Center, target.Center);
            float distance = 100.0f;
			if (mRing && (double)distanceTo <= (double)distance && target.life <= 0)
            {
                int newMana = (int)(player.statManaMax2 * 0.15f);
                player.statMana += newMana;
                player.ManaEffect(newMana);
            }
			if (hRing && (double)distanceTo <= (double)distance && target.life <= 0)
            {
                int newHealth = (int)(player.statLifeMax2 * 0.05f);
                player.statLife += newHealth;
                player.HealEffect(newHealth);
            }
		}

        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
		{
            if (tLuck && crit) damage += (int)(damage * 0.2f);
			if(crit && critHeal)
			{
				int newLife = Main.rand.Next(9,13);
				player.statLife += newLife;
				player.HealEffect(newLife);
				NetMessage.SendData(MessageID.SpiritHeal, -1, -1, null, player.whoAmI, newLife);
			}
			if(manaPrism && Main.rand.Next(4) == 0)
			{
				target.AddBuff(BuffID.Lovestruck, 120);
			}
			if(manaPrism && target.loveStruck)
			{
				int mana = damage / 10 + Main.rand.Next(2,4);
				player.statMana += mana;
				player.ManaEffect(mana);
				NetMessage.SendData(MessageID.ManaEffect, -1, -1, null, player.whoAmI, mana);
			}
            if(discipleSet && proj.magic)
            {
                ++targetHit;
                if (targetHit >= 3)
                {
                    int owner = proj.owner;
                    int manaAmount = Main.rand.Next(4, 12);
                    Main.PlaySound(2, (int)proj.position.X, (int)proj.position.Y, 8);
                    Projectile.NewProjectile(proj.position.X, proj.position.Y, 0.0f, 0.0f, mod.ProjectileType("ManaEffect"), 0, 0.0f, owner, (float)manaAmount, 0.0f);
                    targetHit = 0;
                }
            }
			if(proj.minion && shadowflameCharm)
			{
				target.AddBuff(BuffID.ShadowFlame, 300);
			}
			float distanceTo = Vector2.Distance(player.Center, target.Center);
            float distance = 100.0f;
			if (mRing && (double)distanceTo <= (double)distance)
            {
                int newMana = (int)(player.statManaMax2 * 0.15f);
                player.statMana += newMana;
                player.ManaEffect(newMana);
            }
			if (hRing && (double)distanceTo <= (double)distance)
            {
                int newHealth = (int)(player.statLifeMax2 * 0.05f);
                player.statLife += newHealth;
                player.HealEffect(newHealth);
            }
		}

        public override void OnHitAnything(float x, float y, Entity victim)
        {
			if(hitHeal)
			{
				hitsToHeal += 1;
				CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), Color.Red, hitsToHeal, false, false);
				if(hitsToHeal == 5)
				{
					hitsToHeal = 0;
					int newLife = Main.rand.Next(9,13);
					player.statLife += newLife;
					player.HealEffect(newLife);
					NetMessage.SendData(MessageID.SpiritHeal, -1, -1, null, player.whoAmI, newLife);
				}			
			}
			if(bloodsteal&& Main.rand.Next(4) == 0)
			{
				int newLife = Main.rand.Next(2,6);
                player.statLife += newLife;
                player.HealEffect(newLife);
                NetMessage.SendData(MessageID.SpiritHeal, -1, -1, null, player.whoAmI, newLife);
			}
            if (enchantedSet == true && Main.rand.Next(3) == 0)
            {
                if (player.position.Y <= victim.position.Y) //the equations for mirrored positions are very slighlty different
                {
                    float Xdis = player.position.X - victim.position.X;  // Checks the position between the 2 on both axis
                    float Ydis = player.position.Y - victim.position.Y;
                    float Angle = (float)Math.Atan(Xdis / Ydis); //calculates the angle playerd on 2 above values.
                    DistXT = (float)(Math.Sin(Angle) * 300); //calculates where they should be, which is from the same direction the player is
                    DistYT = (float)(Math.Cos(Angle) * 300); //the T strands for temporary, since it is not the permanant variable, rather a placeholder
                    DistX = (player.position.X + (0 - DistXT)); //sets the real position (relative to the player)
                    DistY = (player.position.Y + (0 - DistYT));
                }
                if (player.position.Y > victim.position.Y)
                {
                    float Xdis = player.position.X - victim.position.X;
                    float Ydis = player.position.Y - victim.position.Y;
                    float Angle = (float)Math.Atan(Xdis / Ydis);
                    DistXT = (float)(Math.Sin(Angle) * 300);
                    DistYT = (float)(Math.Cos(Angle) * 300);
                    DistX = (player.position.X + DistXT);
                    DistY = (player.position.Y + DistYT);
                }
                Vector2 direction = victim.Center - player.Center; //creates a vector for the angle at which the projectile will move
                direction.Normalize(); //normalizes the vector (makes the hypotanuse 1)
                direction.X *= 20f; // multiplies it by 20 (hypotanuse is now 20)
                direction.Y *= 20f;
                float A = (float)Main.rand.Next(-100, 100) * 0.01f;
                float B = (float)Main.rand.Next(-100, 100) * 0.01f;
                Projectile.NewProjectile(DistX, DistY, direction.X + A, direction.Y + B, mod.ProjectileType("EnchantedDagger"), 15, 1, player.whoAmI, 0f, 0f);
            }
        }

        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if (antlionSet)
            {
                playSound = false;
                Main.PlaySound(SoundID.NPCHit31, player.position);
            }
            string HarpyEggBroken = Language.GetTextValue("Mods.Antiaris.HarpyEggBroken", Main.LocalPlayer.name);
            string eggDeathReason = damageSource.ToString();
            string HarpyEggDeath = Language.GetTextValue("Mods.Antiaris.HarpyEggDeath", eggDeathReason);
            int HarpyEgg = player.FindItem(mod.ItemType("HarpyEgg"));
            if (HarpyEgg != -1)
            {
                if (Main.rand.Next(4) == 0)
                {
                    player.inventory[HarpyEgg].stack = 0;
                    Main.PlaySound(3, (int)player.position.X, (int)player.position.Y, 1);
                    Main.NewText(HarpyEggBroken, 255, 255, 255);
                    Gore.NewGore(player.position, Main.rand.NextVector2Unit() * 2f, mod.GetGoreSlot("Gores/HarpyEggGore1"));
                    Gore.NewGore(player.position, Main.rand.NextVector2Unit() * 2f, mod.GetGoreSlot("Gores/HarpyEggGore2"));
                    Gore.NewGore(player.position, Main.rand.NextVector2Unit() * 2f, mod.GetGoreSlot("Gores/HarpyEggGore3"));
                    Gore.NewGore(player.position, Main.rand.NextVector2Unit() * 2f, mod.GetGoreSlot("Gores/HarpyEggGore4"));
                    Main.NewText(HarpyEggDeath, 187, 20, 20);
                }
            }
            return base.PreHurt(pvp, quiet, ref damage, ref hitDirection, ref crit, ref customDamage, ref playSound, ref genGore, ref damageSource);
        }

        public override void ModifyHitByProjectile(Projectile projectile, ref int damage, ref bool crit)
		{
			if (mirrorShield)
			{
                projectile.damage = damage * 2;
				projectile.velocity.X = -projectile.velocity.X;
				projectile.velocity.Y = -projectile.velocity.Y;
				projectile.friendly = true;
				projectile.hostile = false;	
			}
		}

        public override void CatchFish(Item fishingRod, Item bait, int power, int liquidType, int poolSize, int worldLayer, int questFish, ref int caughtType, ref bool junk)
        {
            if (junk)
                return;
            var questSystem = player.GetModPlayer<QuestSystem>(mod);
            int PlayerPosition = (int)(player.position.X) / 16;
            if ((PlayerPosition < 380 || PlayerPosition > Main.maxTilesX - 380) && questSystem.CurrentQuest == QuestItemID.OldCompass && Main.rand.Next(16) == 0)
            {
                caughtType = mod.ItemType("OldCompass");
            }
            if (gooFishingPole && Main.rand.Next(20) == 0)
            {
                caughtType = mod.ItemType("SlimyCrate");
            }
        }
    }
}
