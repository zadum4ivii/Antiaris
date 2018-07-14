using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.NPCs.Enemies
{
    public class JungleFiend : ModNPC
    {
        private int timer = 0;

        public override void SetDefaults()
        {
            npc.lifeMax = 90;
            npc.damage = 28;
            npc.defense = 10;
            npc.knockBackResist = 0.5f;
            npc.width = 106;
            npc.height = 104;
            animationType = 62;
            npc.aiStyle = 14;
			aiType = 51;
            npc.npcSlots = 0.8f;
            npc.HitSound = SoundID.DD2_SkeletonHurt;
            npc.DeathSound = SoundID.NPCDeath40;
            npc.value = Item.buyPrice(0, 0, 2, 10);
			banner = npc.type;
            bannerItem = mod.ItemType("JungleFiendBanner");
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jungle Fiend");
            DisplayName.AddTranslation(GameCulture.Chinese, "丛林恶魔");
            DisplayName.AddTranslation(GameCulture.Russian, "Бес джунглей");
            Main.npcFrameCount[npc.type] = 2;
        }

        public void OverhaulInit()
        {
            this.SetTag("bone");
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 1);
            npc.damage = (int)(npc.damage * 1);
        }

        public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, 655, 1, 1f);
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 44, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/JungleFiendGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/JungleFiendGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/JungleFiendGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/JungleFiendGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/JungleFiendGore3"), 1f);
			}
		}

        public override void AI()
        {
            npc.TargetClosest(true);
            npc.netUpdate = true;
            timer++;
			if(timer == 140 && Main.netMode != 1)
			{
				NPC.NewNPC((int)npc.Center.X + 4, (int)npc.Center.Y + 40, 210, 0, (float)npc.whoAmI, npc.Center.X, npc.Center.Y, 0.0f, (int)byte.MaxValue);
			}		
			if(timer == 160 && Main.netMode != 1)
			{		
				NPC.NewNPC((int)npc.Center.X - 6, (int)npc.Center.Y + 42, 210, 0, (float)npc.whoAmI, npc.Center.X, npc.Center.Y, 0.0f, (int)byte.MaxValue);
				if (Main.expertMode)
				{
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y + 39, 210, 0, (float)npc.whoAmI, npc.Center.X, npc.Center.Y, 0.0f, (int)byte.MaxValue);
				}
                timer = 0;
			}	
        }

        public override void NPCLoot()
        {
            if (Main.netMode != 1)
            {
                int centerX = (int)(npc.position.X + (float)(npc.width / 2)) / 16;
                int centerY = (int)(npc.position.Y + (float)(npc.height / 2)) / 16;
                int halfLength = npc.width / 2 / 16 + 1;
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Bone, Main.rand.Next(10, 13), false, 0, false, false);
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            int x = spawnInfo.spawnTileX;
            int y = spawnInfo.spawnTileY;
            int tile = (int)Main.tile[x, y].type;
            return (Antiaris.NormalSpawn(spawnInfo) && NPC.downedBoss3 && Antiaris.NoZoneAllowWater(spawnInfo)) && spawnInfo.player.ZoneJungle && y < Main.worldSurface ? 0.02f : 0f;
        }
    }
}