using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris
{
    public class AntiarisItems : GlobalItem
    {
        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }

        public override bool CloneNewInstances
        {
            get
            {
                return true;
            }
        }

        internal static readonly int[] Placeables = { 
		/*Paint*/ 1073, 1074, 1075, 1076, 1077, 1078, 1079, 1080, 1081, 1082, 1083, 1084, 1085, 1086, 1087, 1088, 1089, 1090, 1091, 1092, 1093, 1094, 1095, 1096, 1097, 1098, 1099, 1966, 1967, 1968, 
		/*Accessories*/ ItemID.Aglet, ItemID.AnkletoftheWind, ItemID.BandofRegeneration, ItemID.BandofStarpower, ItemID.CelestialMagnet, ItemID.CharmofMyths, ItemID.ManaRegenerationBand, ItemID.PhilosophersStone,
        ItemID.BlizzardinaBottle, ItemID.CloudinaBottle, ItemID.SandstorminaBottle, ItemID.FartinaJar, ItemID.CopperWatch, ItemID.TinWatch, ItemID.SilverWatch, ItemID.TungstenWatch, ItemID.GoldWatch, ItemID.PlatinumWatch,
        ItemID.LaserRuler, ItemID.TallyCounter, ItemID.FishFinder, ItemID.DepthMeter, ItemID.FishermansGuide, ItemID.LuckyCoin, ItemID.LuckyHorseshoe, ItemID.DivingGear, ItemID.LifeformAnalyzer, ItemID.Toolbox,
        ItemID.WeatherRadio, ItemID.GPS, ItemID.MagicCuffs, ItemID.CelestialCuffs, ItemID.Radar, ItemID.TrifoldMap, ItemID.PDA, ItemID.Ruler, ItemID.BlackCounterweight, ItemID.BlueCounterweight, ItemID.GreenCounterweight,
        ItemID.PurpleCounterweight, ItemID.RedCounterweight, ItemID.YellowCounterweight, ItemID.YoyoBag, ItemID.CrossNecklace, ItemID.CelestialShell, ItemID.Sextant, ItemID.FastClock, ItemID.PocketMirror,
        ItemID.ManaFlower, ItemID.REK, ItemID.Megaphone, ItemID.CobaltShield, ItemID.AnkhShield, ItemID.Bezoar, ItemID.Vitamins, ItemID.GravityGlobe, ItemID.ShinyStone, ItemID.RoyalGel, ItemID.CordageGuide, 
		ItemID.PanicNecklace, ItemID.Shackle, ItemID.PutridScent, ItemID.SweetheartNecklace, ItemID.ArmorPolish, ItemID.HandWarmer, ItemID.ObsidianHorseshoe, ItemID.HighTestFishingLine, ItemID.TsunamiInABottle, 
		ItemID.HermesBoots, ItemID.FlurryBoots, ItemID.ClothierVoodooDoll, ItemID.GuideVoodooDoll, ItemID.MagicQuiver, ItemID.ObsidianRose };

        public override void OpenVanillaBag(string context, Player player, int arg)
        {
            if (context == "bossBag" && Main.rand.Next(30) == 0)
            {
                switch (Main.rand.Next(2))
                {
                    case 0:
                        player.QuickSpawnItem(mod.ItemType("Zadum4iviiStylishHairstyle"));
                        player.QuickSpawnItem(mod.ItemType("Zadum4iviiStylishJacket"));
                        player.QuickSpawnItem(mod.ItemType("Zadum4iviiStylishPants"));
                        break;
					case 1:
                        player.QuickSpawnItem(mod.ItemType("CookieSamHood"));
                        player.QuickSpawnItem(mod.ItemType("CookieSamJacket"));
                        player.QuickSpawnItem(mod.ItemType("CookieSamSweatpants"));
                        break;
					case 2:
                        player.QuickSpawnItem(mod.ItemType("NokilosHelmet"));
                        player.QuickSpawnItem(mod.ItemType("NokilosChestplate"));
                        player.QuickSpawnItem(mod.ItemType("NokilosGreaves"));
                        break;
					case 3:
                        player.QuickSpawnItem(mod.ItemType("ZerokkHat"));
                        player.QuickSpawnItem(mod.ItemType("ZerokkChestguard"));
                        player.QuickSpawnItem(mod.ItemType("ZerokkGreaves"));
                        break;
                }
            }
			if (context == "bossBag" && arg == ItemID.GolemBossBag)
            {
                player.QuickSpawnItem(mod.ItemType("GolemPowerCore"));
            }
        }

        public override bool ConsumeItem(Item item, Player player)
        {
            if (item.thrown && (item.useTime > 1 && item.useAnimation > 1) && player.GetModPlayer<AntiarisPlayer>(mod).roguesBelt)
                return Main.rand.Next(100) >= player.GetModPlayer<AntiarisPlayer>(mod).thrownCost;
            return base.ConsumeItem(item, player);
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> list)
        {
            var player = Main.player[Main.myPlayer];
            if (item.type == ItemID.LifeCrystal)
            {
                int lifeCrystalUses = 0;
                if (player.statLifeMax < 300)
                    lifeCrystalUses = (300 - player.statLifeMax) / 20;
                else
                    lifeCrystalUses = 0;

                if (lifeCrystalUses > 0)
                {
                    TooltipLine line = new TooltipLine(mod, "LifeCrystal", (Language.GetTextValue("Mods.Antiaris.LifeCrystalCanUse", lifeCrystalUses.ToString())));
                    list.Add(line);
                }

                if (lifeCrystalUses == 0)
                {
                    TooltipLine line2 = new TooltipLine(mod, "LifeCrystal", (Language.GetTextValue("Mods.Antiaris.LifeCrystalNoUse")));
                    list.Add(line2);
                    TooltipLine line3 = new TooltipLine(mod, "LifeCrystal", (Language.GetTextValue("Mods.Antiaris.LifeCrystalNoUse2")));
                    list.Add(line3);
                }
            }

            if (item.type == mod.ItemType("BlazingHeart"))
            {
                int blazingHeartsUses = 0;
                if (player.statLifeMax < 400)
                    blazingHeartsUses = (400 - player.statLifeMax) / 10;
                else
                    blazingHeartsUses = 0;

                if (player.statLifeMax < 300)
                {
                    TooltipLine line = new TooltipLine(mod, "BlazingHeart", (Language.GetTextValue("Mods.Antiaris.BlazingHeartCantUse")));
                    list.Add(line);
                }

                if (blazingHeartsUses > 0 && player.statLifeMax >= 300)
                {
                    TooltipLine line = new TooltipLine(mod, "BlazingHeart", (Language.GetTextValue("Mods.Antiaris.BlazingHeartCanUse", blazingHeartsUses.ToString())));
                    list.Add(line);
                }

                if (blazingHeartsUses == 0)
                {
                    TooltipLine line2 = new TooltipLine(mod, "BlazingHeart", (Language.GetTextValue("Mods.Antiaris.BlazingHeartNoUse")));
                    list.Add(line2);
                    TooltipLine line3 = new TooltipLine(mod, "BlazingHeart", (Language.GetTextValue("Mods.Antiaris.BlazingHeartNoUse2")));
                    list.Add(line3);
                }
            }

            if (item.type == mod.ItemType("DazzlingHeart"))
            {
                int dazzlingHeartUses = 0;
                if (player.statLifeMax < 450)
                    dazzlingHeartUses = (450 - player.statLifeMax) / 5;
                else
                    dazzlingHeartUses = 0;

                if (player.statLifeMax < 400)
                {
                    TooltipLine line = new TooltipLine(mod, "DazzlingHeart", (Language.GetTextValue("Mods.Antiaris.DazzlingHeartCantUse")));
                    list.Add(line);
                }

                if (dazzlingHeartUses > 0 && player.statLifeMax >= 400)
                {
                    TooltipLine line = new TooltipLine(mod, "DazzlingHeart", (Language.GetTextValue("Mods.Antiaris.DazzlingHeartCanUse", dazzlingHeartUses.ToString())));
                    list.Add(line);
                }

                if (dazzlingHeartUses == 0)
                {
                    TooltipLine line2 = new TooltipLine(mod, "DazzlingHeart", (Language.GetTextValue("Mods.Antiaris.DazzlingHeartNoUse")));
                    list.Add(line2);
                    TooltipLine line3 = new TooltipLine(mod, "DazzlingHeart", (Language.GetTextValue("Mods.Antiaris.DazzlingHeartNoUse2")));
                    list.Add(line3);
                }
            }

            if (item.type == ItemID.LifeFruit)
            {
                int lifeFruitUses = 0;
                if (player.statLifeMax < 450)
                    lifeFruitUses = (500 - player.statLifeMax) / 5;
                else
                    lifeFruitUses = 0;

                if (player.statLifeMax < 450)
                {
                    TooltipLine line = new TooltipLine(mod, "LifeFruit", (Language.GetTextValue("Mods.Antiaris.LifeFruitCantUse")));
                    list.Add(line);
                }

                if (lifeFruitUses > 0 && player.statLifeMax >= 450)
                {
                    TooltipLine line = new TooltipLine(mod, "LifeFruit", (Language.GetTextValue("Mods.Antiaris.LifeFruitCanUse", lifeFruitUses.ToString())));
                    list.Add(line);
                }

                if (lifeFruitUses == 0)
                {
                    TooltipLine line2 = new TooltipLine(mod, "LifeFruit", (Language.GetTextValue("Mods.Antiaris.LifeFruitNoUse")));
                    list.Add(line2);
                }
            }	
        }

        private int heal;
        public override void SetDefaults(Item item)
        {
            if (item.healLife > 0)
            {
                heal = item.healLife;
            }

            if (Placeables.Contains(item.type))
            {
                item.useTurn = true;
                item.autoReuse = true;
                item.useAnimation = 15;
                item.useTime = 10;
                item.useStyle = 1;
                item.consumable = true;

                int style;
                int tile;
                switch (item.type)
                {
                    case 1073:
                        tile = mod.TileType("Paint");
                        style = 0;
                        break;
                    case 1074:
                        tile = mod.TileType("Paint");
                        style = 1;
                        break;
                    case 1075:
                        tile = mod.TileType("Paint");
                        style = 2;
                        break;
                    case 1076:
                        tile = mod.TileType("Paint");
                        style = 3;
                        break;
                    case 1077:
                        tile = mod.TileType("Paint");
                        style = 4;
                        break;
                    case 1078:
                        tile = mod.TileType("Paint");
                        style = 5;
                        break;
                    case 1079:
                        tile = mod.TileType("Paint");
                        style = 5;
                        break;
                    case 1080:
                        tile = mod.TileType("Paint");
                        style = 7;
                        break;
                    case 1081:
                        tile = mod.TileType("Paint");
                        style = 8;
                        break;
                    case 1082:
                        tile = mod.TileType("Paint");
                        style = 9;
                        break;
                    case 1083:
                        tile = mod.TileType("Paint");
                        style = 10;
                        break;
                    case 1084:
                        tile = mod.TileType("Paint");
                        style = 11;
                        break;
                    case 1085:
                        tile = mod.TileType("Paint");
                        style = 12;
                        break;
                    case 1086:
                        tile = mod.TileType("Paint");
                        style = 13;
                        break;
                    case 1087:
                        tile = mod.TileType("Paint");
                        style = 14;
                        break;
                    case 1088:
                        tile = mod.TileType("Paint");
                        style = 15;
                        break;
                    case 1089:
                        tile = mod.TileType("Paint");
                        style = 16;
                        break;
                    case 1090:
                        tile = mod.TileType("Paint");
                        style = 17;
                        break;
                    case 1091:
                        tile = mod.TileType("Paint");
                        style = 18;
                        break;
                    case 1092:
                        tile = mod.TileType("Paint");
                        style = 19;
                        break;
                    case 1093:
                        tile = mod.TileType("Paint");
                        style = 20;
                        break;
                    case 1094:
                        tile = mod.TileType("Paint");
                        style = 21;
                        break;
                    case 1095:
                        tile = mod.TileType("Paint");
                        style = 22;
                        break;
                    case 1096:
                        tile = mod.TileType("Paint");
                        style = 23;
                        break;
                    case 1097:
                        tile = mod.TileType("Paint");
                        style = 24;
                        break;
                    case 1099:
                        tile = mod.TileType("Paint");
                        style = 25;
                        break;
                    case 1098:
                        tile = mod.TileType("Paint");
                        style = 26;
                        break;
                    case 1966:
                        tile = mod.TileType("Paint");
                        style = 27;
                        break;
                    case 1967:
                        tile = mod.TileType("Paint");
                        style = 28;
                        break;
                    case 1968:
                        tile = mod.TileType("Paint");
                        style = 29;
                        break;
                    case ItemID.Aglet:
                        tile = mod.TileType("Accessories1");
                        style = 0;
                        break;
                    case ItemID.AnkletoftheWind:
                        tile = mod.TileType("Accessories1");
                        style = 1;
                        break;
                    case ItemID.BandofRegeneration:
                        tile = mod.TileType("Accessories1");
                        style = 2;
                        break;
                    case ItemID.BandofStarpower:
                        tile = mod.TileType("Accessories1");
                        style = 3;
                        break;
                    case ItemID.CelestialMagnet:
                        tile = mod.TileType("Accessories1");
                        style = 4;
                        break;
                    case ItemID.CharmofMyths:
                        tile = mod.TileType("Accessories1");
                        style = 5;
                        break;
                    case ItemID.ManaRegenerationBand:
                        tile = mod.TileType("Accessories1");
                        style = 6;
                        break;
                    case ItemID.PhilosophersStone:
                        tile = mod.TileType("Accessories1");
                        style = 7;
                        break;
                    case ItemID.BlizzardinaBottle:
                        tile = mod.TileType("Accessories1");
                        style = 8;
                        break;
                    case ItemID.CloudinaBottle:
                        tile = mod.TileType("Accessories1");
                        style = 9;
                        break;
                    case ItemID.SandstorminaBottle:
                        tile = mod.TileType("Accessories1");
                        style = 10;
                        break;
                    case ItemID.FartinaJar:
                        tile = mod.TileType("Accessories1");
                        style = 11;
                        break;
                    case ItemID.CopperWatch:
                        tile = mod.TileType("Accessories1");
                        style = 12;
                        break;
                    case ItemID.TinWatch:
                        tile = mod.TileType("Accessories1");
                        style = 13;
                        break;
                    case ItemID.SilverWatch:
                        tile = mod.TileType("Accessories1");
                        style = 14;
                        break;
                    case ItemID.TungstenWatch:
                        tile = mod.TileType("Accessories1");
                        style = 15;
                        break;
                    case ItemID.GoldWatch:
                        tile = mod.TileType("Accessories1");
                        style = 16;
                        break;
                    case ItemID.PlatinumWatch:
                        tile = mod.TileType("Accessories1");
                        style = 17;
                        break;
                    case ItemID.LaserRuler:
                        tile = mod.TileType("Accessories1");
                        style = 18;
                        break;
                    case ItemID.TallyCounter:
                        tile = mod.TileType("Accessories1");
                        style = 19;
                        break;
                    case ItemID.FishFinder:
                        tile = mod.TileType("Accessories1");
                        style = 20;
                        break;
                    case ItemID.DepthMeter:
                        tile = mod.TileType("Accessories1");
                        style = 21;
                        break;
                    case ItemID.FishermansGuide:
                        tile = mod.TileType("Accessories1");
                        style = 22;
                        break;
                    case ItemID.LuckyCoin:
                        tile = mod.TileType("Accessories1");
                        style = 23;
                        break;
                    case ItemID.LuckyHorseshoe:
                        tile = mod.TileType("Accessories1");
                        style = 24;
                        break;
                    case ItemID.BlackCounterweight:
                        tile = mod.TileType("Accessories1");
                        style = 25;
                        break;
                    case ItemID.BlueCounterweight:
                        tile = mod.TileType("Accessories1");
                        style = 26;
                        break;
                    case ItemID.GreenCounterweight:
                        tile = mod.TileType("Accessories1");
                        style = 27;
                        break;
                    case ItemID.PurpleCounterweight:
                        tile = mod.TileType("Accessories1");
                        style = 28;
                        break;
                    case ItemID.RedCounterweight:
                        tile = mod.TileType("Accessories1");
                        style = 29;
                        break;
                    case ItemID.YellowCounterweight:
                        tile = mod.TileType("Accessories1");
                        style = 30;
                        break;
                    case ItemID.CrossNecklace:
                        tile = mod.TileType("Accessories1");
                        style = 31;
                        break;
					case ItemID.Bezoar:
                        tile = mod.TileType("Accessories1");
                        style = 32;
                        break;
					case ItemID.Vitamins:
                        tile = mod.TileType("Accessories1");
                        style = 33;
                        break;
					case ItemID.GravityGlobe:
                        tile = mod.TileType("Accessories1");
                        style = 34;
                        break;
					case ItemID.ShinyStone:
                        tile = mod.TileType("Accessories1");
                        style = 35;
                        break;
					case ItemID.RoyalGel:
                        tile = mod.TileType("Accessories1_2");
                        style = 0;
                        break;
					case ItemID.CordageGuide:
                        tile = mod.TileType("Accessories1_2");
                        style = 1;
                        break;
					case ItemID.PanicNecklace:
                        tile = mod.TileType("Accessories1_2");
                        style = 2;
                        break;
					case ItemID.Shackle:
                        tile = mod.TileType("Accessories1_2");
                        style = 3;
                        break;
					case ItemID.PutridScent:
                        tile = mod.TileType("Accessories1_2");
                        style = 4;
                        break;
					case ItemID.SweetheartNecklace:
                        tile = mod.TileType("Accessories1_2");
                        style = 5;
                        break;
					case ItemID.ArmorPolish:
                        tile = mod.TileType("Accessories1_2");
                        style = 6;
                        break;	
					case ItemID.HandWarmer:
                        tile = mod.TileType("Accessories1_2");
                        style = 7;
                        break;	
					case ItemID.ObsidianHorseshoe:
                        tile = mod.TileType("Accessories1_2");
                        style = 8;
                        break;	
					case ItemID.HighTestFishingLine:
                        tile = mod.TileType("Accessories1_2");
                        style = 9;
                        break;	
					case ItemID.TsunamiInABottle:
                        tile = mod.TileType("Accessories1_2");
                        style = 10;	
						break;
                    case ItemID.DivingGear:
                        tile = mod.TileType("Accessories3");
                        style = 0;
                        break;
                    case ItemID.LifeformAnalyzer:
                        tile = mod.TileType("Accessories3");
                        style = 1;
                        break;
                    case ItemID.Toolbox:
                        tile = mod.TileType("Accessories3");
                        style = 2;
                        break;
                    case ItemID.WeatherRadio:
                        tile = mod.TileType("Accessories3");
                        style = 3;
                        break;
                    case ItemID.YoyoBag:
                        tile = mod.TileType("Accessories3");
                        style = 4;
                        break;
                    case ItemID.CelestialShell:
                        tile = mod.TileType("Accessories3");
                        style = 5;
                        break;
                    case ItemID.Sextant:
                        tile = mod.TileType("Accessories3");
                        style = 6;
                        break;
                    case ItemID.GPS:
                        tile = mod.TileType("Accessories3");
                        style = 7;
                        break;
					case ItemID.HermesBoots:
                        tile = mod.TileType("Accessories3");
                        style = 8;
                        break;
					case ItemID.FlurryBoots:
                        tile = mod.TileType("Accessories3");
                        style = 9;
                        break;
                    case ItemID.MagicCuffs:
                        tile = mod.TileType("Accessories2");
                        style = 0;
                        break;
                    case ItemID.CelestialCuffs:
                        tile = mod.TileType("Accessories2");
                        style = 1;
                        break;
                    case ItemID.Radar:
                        tile = mod.TileType("Radar");
                        style = 0;
                        break;
                    case ItemID.TrifoldMap:
                        tile = mod.TileType("TrifoldMap");
                        style = 0;
                        break;
                    case ItemID.PDA:
                        tile = mod.TileType("Accessories4");
                        style = 0;
                        break;
                    case ItemID.Ruler:
                        tile = mod.TileType("Accessories4");
                        style = 1;
                        break;
                    case ItemID.FastClock:
                        tile = mod.TileType("Accessories4");
                        style = 2;
                        break;
                    case ItemID.PocketMirror:
                        tile = mod.TileType("Accessories4");
                        style = 3;
                        break;
                    case ItemID.ManaFlower:
                        tile = mod.TileType("Accessories4");
                        style = 4;
                        break;
					case ItemID.ClothierVoodooDoll:
                        tile = mod.TileType("Accessories4");
                        style = 5;
                        break;
                    case ItemID.GuideVoodooDoll:
                        tile = mod.TileType("Accessories4");
                        style = 6;
                        break;
                    case ItemID.MagicQuiver:
                        tile = mod.TileType("Accessories4");
                        style = 7;
                        break;
                    case ItemID.ObsidianRose:
                        tile = mod.TileType("Accessories4");
                        style = 8;
                        break;
                    case ItemID.REK:
                        tile = mod.TileType("REK3000");
                        style = 0;
                        break;
                    case ItemID.Megaphone:
                        tile = mod.TileType("Megaphone");
                        style = 0;
                        break;
                    case ItemID.CobaltShield:
                        tile = mod.TileType("Accessories5");
                        style = 0;
                        break;
                    case ItemID.AnkhShield:
                        tile = mod.TileType("Accessories5");
                        style = 1;
                        break;						
                    default:
                        return;
                }
                item.placeStyle = style;
                item.createTile = tile;
            }
        }

        public override void PostUpdate(Item item)
        {			
            if ((item.wet || item.lavaWet) && item.type == 23)
            {
                if (item.velocity.Y > 0.86f)
                {
                    item.velocity.Y = item.velocity.Y * 0.9f;
                }
                item.velocity.Y = item.velocity.Y - 0.6f;
                if (item.velocity.Y < -2f)
                {
                    item.velocity.Y = -2f;
                }
            }
        }

        public override void UpdateInventory(Item item, Player player)
        {
            if (item.healLife > 0)
            {
                if (player.GetModPlayer<AntiarisPlayer>(mod).healingBonus)
                {
                    item.healLife = (int)(heal * 1.15f);
                }
                else
                {
                    item.healLife = heal;
                }
            }
        }
    }
}
