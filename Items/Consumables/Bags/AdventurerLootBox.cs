using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Bags
{
    public class AdventurerLootBox : ModItem
    {
        public override void SetDefaults()
        {
            item.maxStack = 999;
            item.consumable = true;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.width = 38;
            item.height = 48;
            item.rare = -11;
			item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
			item.createTile = mod.TileType("AdventurerLootBox");
        }
		
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Adventurer's Loot Box");
            Tooltip.SetDefault("<right> to open");
            DisplayName.AddTranslation(GameCulture.Chinese, "冒险家的战利品箱子");
            Tooltip.AddTranslation(GameCulture.Chinese, "<right>来打开");
            DisplayName.AddTranslation(GameCulture.Russian, "Коробка с добычей Путешественника");
            Tooltip.AddTranslation(GameCulture.Russian, "<right>, чтобы открыть");
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            player.QuickSpawnItem(ItemID.CopperCoin, Main.rand.Next(45, 90));
            player.QuickSpawnItem(ItemID.SilverCoin, Main.rand.Next(45, 50));
            player.QuickSpawnItem(ItemID.GoldCoin, Main.rand.Next(2, 5));
            player.QuickSpawnItem(mod.ItemType("IronCoin"), Main.rand.Next(1, 3));
            if (Main.rand.Next(3) == 0)
            {
                player.GetDyeTraderReward();
            }
            if (Main.rand.Next(3) == 0)
            {
                var rand = Main.rand.Next(0, 7);
                if (rand == 0)
                {
                    player.QuickSpawnItem(703, Main.rand.Next(16, 24));
                }
                else if (rand == 1)
                {
                    player.QuickSpawnItem(20, Main.rand.Next(16, 24));
                }
                else if (rand == 2)
                {
                    player.QuickSpawnItem(22, Main.rand.Next(16, 24));
                }
                else if (rand == 3)
                {
                    player.QuickSpawnItem(704, Main.rand.Next(16, 24));
                }
                else if (rand == 4)
                {
                    player.QuickSpawnItem(21, Main.rand.Next(16, 24));
                }
                else if (rand == 5)
                {
                    player.QuickSpawnItem(705, Main.rand.Next(16, 24));
                }
                else if (rand == 6)
                {
                    player.QuickSpawnItem(19, Main.rand.Next(16, 24));
                }
                else if (rand == 7)
                {
                    player.QuickSpawnItem(706, Main.rand.Next(16, 24));
                }
                if (Main.hardMode)
                {
                    var rand2 = Main.rand.Next(0, 5);
                    if (rand2 == 0)
                    {
                        player.QuickSpawnItem(381, Main.rand.Next(16, 24));
                    }
                    else if (rand2 == 1)
                    {
                        player.QuickSpawnItem(1184, Main.rand.Next(16, 24));
                    }
                    else if (rand2 == 2)
                    {
                        player.QuickSpawnItem(382, Main.rand.Next(16, 24));
                    }
                    else if (rand2 == 3)
                    {
                        player.QuickSpawnItem(1191, Main.rand.Next(16, 24));
                    }
                    else if (rand2 == 4)
                    {
                        player.QuickSpawnItem(1198, Main.rand.Next(16, 24));
                    }
                    else if (rand2 == 5)
                    {
                        player.QuickSpawnItem(391, Main.rand.Next(16, 24));
                    }
                }
            }
            if (Main.rand.Next(3) == 0)
            {
                if (NPC.downedMechBossAny)
                {
                    player.QuickSpawnItem(1225, Main.rand.Next(16, 24));
                }
            }
            if (Main.rand.Next(3) == 0)
            {
                if (NPC.downedPlantBoss)
                {
                    player.QuickSpawnItem(1006, Main.rand.Next(16, 24));
                }
            }
            if (Main.rand.Next(25) == 0)
            {
                player.QuickSpawnItem(mod.ItemType("CalmnessRing"));
            }
            if (Main.rand.Next(20) == 0)
            {
                player.QuickSpawnItem(mod.ItemType("InkMonsterMask"));
            }
			if (Main.rand.Next(20) == 0)
            {
                player.QuickSpawnItem(mod.ItemType("BearMask"));
            }
			if (Main.rand.Next(20) == 0)
            {
                player.QuickSpawnItem(mod.ItemType("MinerMask"));
            }
			if (Main.rand.Next(20) == 0)
            {
                player.QuickSpawnItem(mod.ItemType("CookMask"));
            }
            if (Main.rand.Next(20) == 0)
            {
                player.QuickSpawnItem(mod.ItemType("PlatinumAppleMask"));
            }
            if (Main.rand.Next(20) == 0)
            {
                player.QuickSpawnItem(mod.ItemType("PowerMask"));
            }
			if (Main.rand.Next(20) == 0)
            {
                player.QuickSpawnItem(mod.ItemType("BizzareCap"));
            }
			if (Main.rand.Next(20) == 0)
            {
                player.QuickSpawnItem(mod.ItemType("BlackBizzareCap"));
            }
            if (Main.rand.Next(10) == 0)
            {
                if (NPC.downedPlantBoss)
                {
                    player.QuickSpawnItem(1552, Main.rand.Next(16, 24));
                }
            }
            if (Main.rand.Next(10) == 0)
            {
                if (NPC.downedPlantBoss)
                {
                    player.QuickSpawnItem(3261, Main.rand.Next(16, 24));
                }
            }
            if (Main.rand.Next(3) == 0)
            {
                if (NPC.downedMoonlord)
                {
                    player.QuickSpawnItem(3467, Main.rand.Next(16, 24));
                }
            }
            if (Main.rand.Next(3) == 0)
            {
                player.QuickSpawnItem(17);
            }
            if (Main.rand.Next(7) == 0)
            {
                player.QuickSpawnItem(118);
            }
            if (Main.rand.Next(15) == 0)
            {
                player.QuickSpawnItem(111);
            }
            if (Main.rand.Next(15) == 0)
            {
                player.QuickSpawnItem(49);
            }
            if (Main.rand.Next(30) == 0)
            {
                player.QuickSpawnItem(128);
            }
            if (Main.rand.Next(20) == 0)
            {
                player.QuickSpawnItem(158);
            }
            if (Main.rand.Next(20) == 0)
            {
                player.QuickSpawnItem(159);
            }
            if (Main.rand.Next(3) == 0)
            {
                player.QuickSpawnItem(183, Main.rand.Next(5, 15));
            }
            if (Main.rand.Next(3) == 0)
            {
                player.QuickSpawnItem(ItemID.Rope, Main.rand.Next(120, 160));
            }
            if (Main.rand.Next(3) == 0)
            {
                var rand3 = Main.rand.Next(0, 5);
                if (rand3 == 0)
                {
                    player.QuickSpawnItem(ItemID.Sapphire, Main.rand.Next(3, 7));
                }
                else if (rand3 == 1)
                {
                    player.QuickSpawnItem(ItemID.Ruby, Main.rand.Next(2, 4));
                }
                else if (rand3 == 2)
                {
                    player.QuickSpawnItem(ItemID.Amethyst, Main.rand.Next(4, 8));
                }
                else if (rand3 == 3)
                {
                    player.QuickSpawnItem(ItemID.Emerald, Main.rand.Next(3, 7));
                }
                else if (rand3 == 4)
                {
                    player.QuickSpawnItem(ItemID.Topaz, Main.rand.Next(3, 7));
                }
                else if (rand3 == 5)
                {
                    player.QuickSpawnItem(ItemID.Diamond, Main.rand.Next(2, 4));
                }
            }
            if (Main.rand.Next(5) == 0)
            {
                player.QuickSpawnItem(1774, Main.rand.Next(1, 2));
            }
            if (Main.rand.Next(5) == 0)
            {
                if (NPC.downedPlantBoss)
                {
                    player.QuickSpawnItem(1291, Main.rand.Next(1, 5));
                }
            }
            if (Main.rand.Next(5) == 0)
            {
                if (NPC.downedPlantBoss)
                {
                    player.QuickSpawnItem(1293, Main.rand.Next(1, 2));
                }
            }
            if (Main.rand.Next(20) == 0)
            {
                if (Main.hardMode)
                {
                    player.QuickSpawnItem(1321, Main.rand.Next(1, 2));
                }
            }
            if (Main.rand.Next(5) == 0)
            {
                if (NPC.downedPlantBoss)
                {
                    player.QuickSpawnItem(1508, Main.rand.Next(1, 5));
                }
            }
            if (Main.rand.Next(15) == 0)
            {
                if (Main.hardMode)
                {
                    var rand4 = Main.rand.Next(0, 4);
                    if (rand4 == 0)
                    {
                        player.QuickSpawnItem(1516 + 1);
                    }
                    else if (rand4 == 1)
                    {
                        player.QuickSpawnItem(1516 + 2);
                    }
                    else if (rand4 == 2)
                    {
                        player.QuickSpawnItem(1516 + 3);
                    }
                    else if (rand4 == 3)
                    {
                        player.QuickSpawnItem(1516 + 4);
                    }
                    else if (rand4 == 4)
                    {
                        player.QuickSpawnItem(1516 + 5);
                    }
                }
            }
            if (Main.rand.Next(25) == 0)
            {
                if (Main.hardMode)
                {
                    player.QuickSpawnItem(1570);
                }
            }
            if (Main.rand.Next(30) == 0)
            {
                if (Main.hardMode)
                {
                    player.QuickSpawnItem(3103);
                }
            }
            if (Main.rand.Next(30) == 0)
            {
                if (Main.hardMode)
                {
                    player.QuickSpawnItem(3104);
                }
            }
            if (Main.rand.Next(30) == 0)
            {
                if (Main.hardMode)
                {
                    player.QuickSpawnItem(mod.ItemType("EndlessDartPack"));
                }
            }
            if (Main.rand.Next(30) == 0)
            {
                if (Main.hardMode)
                {
                    player.QuickSpawnItem(mod.ItemType("EndlessRocketSilo"));
                }
            }
            if (Main.rand.Next(30) == 0)
            {
                player.QuickSpawnItem(3183);
            }
            if (Main.rand.Next(20) == 0)
            {
                player.QuickSpawnItem(1579);
            }
            if (Main.rand.Next(20) == 0)
            {
                player.QuickSpawnItem(1320);
            }
            if (Main.rand.Next(30) == 0)
            {
                player.QuickSpawnItem(1303);
            }
            if (Main.rand.Next(2) == 0)
            {
                player.QuickSpawnItem(ItemID.ThrowingKnife, Main.rand.Next(95, 135));
            }
            if (Main.rand.Next(5) == 0)
            {
                player.QuickSpawnItem(ItemID.LifeCrystal, Main.rand.Next(1, 2));
            }
            if (Main.rand.Next(5) == 0)
            {
                player.QuickSpawnItem(ItemID.ManaCrystal, Main.rand.Next(1, 2));
            }
            if (Main.rand.Next(3) == 0)
            {
                player.QuickSpawnItem(ItemID.Gel, Main.rand.Next(45, 70));
            }
            if (Main.rand.Next(25) == 0)
            {
                player.QuickSpawnItem(ItemID.MiningHelmet);
            }
            if (Main.rand.Next(6) == 0 && WorldGen.crimson && NPC.downedBoss2)
            {
                player.QuickSpawnItem(ItemID.CrimtaneBar, Main.rand.Next(16, 24));
            }
            if (Main.rand.Next(6) == 0 && !WorldGen.crimson && NPC.downedBoss2)
            {
                player.QuickSpawnItem(ItemID.DemoniteBar, Main.rand.Next(16, 24));
            }
            if (Main.rand.Next(30) == 0)
            {
                player.QuickSpawnItem(ItemID.MetalDetector);
            }
            if (Main.rand.Next(7) == 0)
            {
                player.QuickSpawnItem(ItemID.LesserHealingPotion, Main.rand.Next(10, 18));
            }
            else if (Main.rand.Next(6) == 0 && NPC.downedBoss3)
            {
                player.QuickSpawnItem(ItemID.HealingPotion, Main.rand.Next(8, 14));
            }
            if (Main.rand.Next(7) == 0)
            {
                player.QuickSpawnItem(ItemID.LesserManaPotion, Main.rand.Next(10, 18));
            }
            else if (Main.rand.Next(6) == 0)
            {
                player.QuickSpawnItem(ItemID.ManaPotion, Main.rand.Next(8, 14));
            }
            if (Main.rand.Next(30) == 0)
            {
                player.QuickSpawnItem(ItemID.GreaterHealingPotion, Main.rand.Next(4, 12));
            }
            else if (Main.rand.Next(30) == 0)
            {
                player.QuickSpawnItem(ItemID.GreaterManaPotion, Main.rand.Next(4, 12));
            }
            if (Main.rand.Next(6) == 0 && NPC.downedMechBossAny)
            {
                player.QuickSpawnItem(ItemID.GreaterHealingPotion, Main.rand.Next(10, 16));
            }
            if (Main.rand.Next(6) == 0 && NPC.downedMechBossAny)
            {
                player.QuickSpawnItem(ItemID.GreaterManaPotion, Main.rand.Next(10, 16));
            }
            if (Main.rand.Next(33) == 0 && NPC.downedBoss1)
            {
                player.QuickSpawnItem(mod.ItemType("SpearofDespair"));
            }
            if (Main.rand.Next(40) == 0 && Main.hardMode)
            {
                player.QuickSpawnItem(mod.ItemType("CursedHand"));
            }
            if (Main.rand.Next(10) == 0)
            {
                player.QuickSpawnItem(ItemID.Bone, Main.rand.Next(14, 24));
            }
            if (Main.rand.Next(7) == 0)
            {
                player.QuickSpawnItem(mod.ItemType("HealthElixir"), Main.rand.Next(2, 5));
            }
            if (Main.rand.Next(7) == 0)
            {
                player.QuickSpawnItem(mod.ItemType("ManaElixir"), Main.rand.Next(2, 5));
            }
            if (Main.rand.Next(6) == 0)
            {
                player.QuickSpawnItem(mod.ItemType("RuneStone"), Main.rand.Next(3, 5));
            }
            if (Main.rand.Next(25) == 0 && Main.hardMode)
            {
                player.QuickSpawnItem(mod.ItemType("CannonofNightmares"));
            }
            if (Main.rand.Next(25) == 0)
            {
                player.QuickSpawnItem(mod.ItemType("ChestFounder"));
            }
            if (Main.rand.Next(15) == 0 && Main.hardMode)
            {
                player.QuickSpawnItem(mod.ItemType("SuspiciousFragment"), Main.rand.Next(1, 3));
            }
        }
    }
}
