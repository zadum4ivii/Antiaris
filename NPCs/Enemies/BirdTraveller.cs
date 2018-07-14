using System;
using Antiaris.NPCs.Town;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.NPCs.Enemies
{
    public class BirdTraveller : ModNPC
    {
        private int timer = 0;

        public override void SetDefaults()
        {
            npc.lifeMax = 165;
            npc.damage = 12;
            npc.defense = 8;
            npc.knockBackResist = 0f;
            npc.width = 78;
            npc.height = 54;
            npc.aiStyle = 44;
            aiType = NPCID.FlyingFish;
            animationType = 48;
            npc.npcSlots = 0.5f;
            npc.HitSound = SoundID.NPCHit1;
            npc.noGravity = true;
            npc.npcSlots = 2f;
            npc.DeathSound = SoundID.NPCDeath1;
			npc.value = Item.buyPrice(0, 0, 34, 5);
			bannerItem = mod.ItemType("BirdTravellerBanner");
            banner = npc.type;
            npc.rarity = 1;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bird Traveller");
            DisplayName.AddTranslation(GameCulture.Chinese, "荼毒女王鸟");
            DisplayName.AddTranslation(GameCulture.Russian, "Птица-путешественник");
            Main.npcFrameCount[npc.type] = 4;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 1);
            npc.damage = (int)(npc.damage * 1);
        }

        public override void AI()
        {
            npc.TargetClosest(true);
            ++timer;
            if ((int)(timer % 155) == 0)
            {
                var player = Main.player[npc.target];
                var startPos = new Vector2(npc.position.X + (npc.width * 0.5f), npc.position.Y + (npc.height / 2));
                var rot = (float)Math.Atan2(startPos.Y - (player.position.Y + (player.height * 0.5f)), startPos.X - (player.position.X + (player.width * 0.5f)));
                npc.velocity.X = (float)(Math.Cos(rot) * 14) * -1;
                npc.velocity.Y = (float)(Math.Sin(rot) * 14) * -1;
                npc.netUpdate = true;
            }
        }

        public override void NPCLoot()
        {
            if (Main.netMode != 1)
            {
                int centerX = (int)(npc.position.X + (float)(npc.width / 2)) / 16;
                int centerY = (int)(npc.position.Y + (float)(npc.height / 2)) / 16;
                int halfLength = npc.width / 2 / 16 + 1;
				if (Main.rand.Next(2) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TravellersFeather"), 1, false, 0, false, false);
				}
            }
        }

        public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TravalibirdGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TravalibirdGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TravalibirdGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TravalibirdGore3"), 1f);
			}
		}

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            var questSystem = spawnInfo.player.GetModPlayer<QuestSystem>(mod);
            return spawnInfo.sky ? 0.11f : 0f;
        }
    }
}