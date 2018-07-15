using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.NPCs.Enemies
{
    public class WrathZombie : ModNPC
    {
        public override void SetDefaults()
        {
            npc.lifeMax = 44;
            npc.damage = 14;
            npc.defense = 8;
            npc.knockBackResist = 0.5f;
            npc.width = 18;
            npc.height = 40;
            animationType = 3;
            npc.aiStyle = 26;
            npc.npcSlots = 0.8f;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath2;
            npc.value = Item.buyPrice(0, 0, 14, 7);
			banner = npc.type;
            bannerItem = mod.ItemType("WrathZombieBanner");
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wrath Zombie");
            DisplayName.AddTranslation(GameCulture.Chinese, "狂怒丧尸");
            DisplayName.AddTranslation(GameCulture.Russian, "Яростный зомби");
            Main.npcFrameCount[npc.type] = 3;
        }

        public void OverhaulInit()
        {
            this.SetTag("zombie");
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 1);
            npc.damage = (int)(npc.damage * 1);
        }

        public override void AI()
        {
            npc.TargetClosest(true);
            npc.netUpdate = true;
            if (Main.rand.Next(40) == 0)
            {
                //VANILLA CODE
                var k = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + (float)npc.height * 0.25f), npc.width, (int)((float)npc.height * 0.5f), 5, npc.velocity.X, 2f, 0, default(Color), 1f);
                var expr_3390_cp_0 = Main.dust[k];
                expr_3390_cp_0.velocity.X = expr_3390_cp_0.velocity.X * 0.5f;
                Dust expr_33AE_cp_0 = Main.dust[k];
                expr_33AE_cp_0.velocity.Y = expr_33AE_cp_0.velocity.Y * 0.1f;
            }
        }

        public override void NPCLoot()
        {
            if (Main.netMode != 1)
            {
                int centerX = (int)(npc.position.X + (float)(npc.width / 2)) / 16;
                int centerY = (int)(npc.position.Y + (float)(npc.height / 2)) / 16;
                int halfLength = npc.width / 2 / 16 + 1;
                if (Main.rand.Next(50) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 216, 1, false, 0, false, false);
                }
                if (Main.rand.Next(250) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1304, 1, false, 0, false, false);
                }
                if (Main.rand.Next(3) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BloodDroplet"), Main.rand.Next(3, 5), false, 0, false, false);
                }
                if (Main.rand.Next(1) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("WrathElement"), 1, false, 0, false, false);
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
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WrathZombieGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WrathZombieGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/WrathZombieGore3"), 1f);
			}
		}

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            var x = spawnInfo.spawnTileX;
            var y = spawnInfo.spawnTileY;
            var tile = (int)Main.tile[x, y].type;
            return (Antiaris.NormalSpawn(spawnInfo) && Antiaris.NoZoneAllowWater(spawnInfo)) && !Main.dayTime && y < Main.worldSurface ? 0.03f : 0f;
        }
    }
}