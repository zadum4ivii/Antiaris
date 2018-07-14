using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.NPCs.Enemies
{
    public class LivingSnowman : ModNPC
    {
        public override void SetDefaults()
        {
            npc.lifeMax = 54;
            npc.damage = 18;
            npc.defense = 9;
            npc.knockBackResist = 0.5f;
            npc.width = 34;
            npc.height = 46;
            animationType = 3;
            npc.aiStyle = 3;
			aiType = 73;
            npc.npcSlots = 0.8f;
            npc.HitSound = SoundID.NPCHit11;
            npc.DeathSound = SoundID.NPCDeath15;
            npc.value = Item.buyPrice(0, 0, 0, 85);
			banner = npc.type;
            bannerItem = mod.ItemType("LivingSnowmanBanner");
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Living Snowman");
            DisplayName.AddTranslation(GameCulture.Chinese, "活雪人");
            DisplayName.AddTranslation(GameCulture.Russian, "Живой снеговик");
            Main.npcFrameCount[npc.type] = 3;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 1);
            npc.damage = (int)(npc.damage * 1);
        }

        public override void NPCLoot()
        {
            if (Main.netMode != 1)
            {
                int centerX = (int)(npc.position.X + (float)(npc.width / 2)) / 16;
                int centerY = (int)(npc.position.Y + (float)(npc.height / 2)) / 16;
                int halfLength = npc.width / 2 / 16 + 1;
				
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Snowball, Main.rand.Next(10,15), false, 0, false, false);
				if (Main.rand.Next(25) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SnowballCannon, 1, false, 0, false, false);
                }
            }
        }

        public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 76, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
                int num220 = 5;
                for (int num221 = 0; num221 < num220; num221++)
                {
                    Vector2 value17 = new Vector2((float)Main.rand.Next(-25, 25), (float)Main.rand.Next(-100, 101));
                    value17.Normalize();
                    value17 *= (float)Main.rand.Next(200, 500) * 0.01f;
                    int k = Projectile.NewProjectile(npc.position.X, npc.position.Y, value17.X, value17.Y, 166, npc.damage, 1f);
					Main.projectile[k].hostile = true;
					Main.projectile[k].friendly = false;
                }
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/LivingSnowmanGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/LivingSnowmanGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/LivingSnowmanGore3"), 1f);
			}
		}

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            var x = spawnInfo.spawnTileX;
            var y = spawnInfo.spawnTileY;
            var tile = (int)Main.tile[x, y].type;
            return (Antiaris.NormalSpawn(spawnInfo) && Antiaris.NoZoneAllowWater(spawnInfo)) && spawnInfo.player.ZoneSnow && y < Main.worldSurface ? 0.04f : 0f;
        }
    }
}