using System;
using System.IO;
using System.Collections.Generic;
using Terraria;
using System.Text;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using System.Linq;
using Terraria.ModLoader.IO;
using Terraria.Localization;
using Antiaris.NPCs.Town;

namespace Antiaris.NPCs.Enemies
{
    public class BirdTraveller : ModNPC
    {        
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

        private float timer;
        public override void AI()
        {
            npc.TargetClosest(true);
            Player player = Main.player[npc.target];
            ++timer;
            if (timer >= 180f && timer % 20f == 0f)
            {
                Vector2 player2 = player.Center;
                Vector2 vector2_1 = player2;
                float speed = 10f;
                Vector2 vector2_2 = vector2_1 - npc.Center;
                float distance = (float)Math.Sqrt((double)vector2_2.X * (double)vector2_2.X + (double)vector2_2.Y * (double)vector2_2.Y);
                vector2_2 *= speed / distance;
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vector2_2.X, vector2_2.Y, mod.ProjectileType("TravellerFeather"), npc.damage / 3 + 15, 5.0f, 0, 0.0f, 0.0f);
            }
            if (timer >= 260.0f)
                timer = 0.0f;
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

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            var questSystem = spawnInfo.player.GetModPlayer<QuestSystem>(mod);
            return spawnInfo.sky ? 0.11f : 0f;
        }
    }
}