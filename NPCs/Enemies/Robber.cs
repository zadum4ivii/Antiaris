using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.NPCs.Enemies
{
	public class Robber : ModNPC
	{
	    public override void SetDefaults()
		{
			npc.width = 28;
			npc.height = 44;
			npc.damage = 5;
			npc.defense = 6;
			npc.lifeMax = 62;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/NPCs/RobberDeath");
            npc.value = Item.buyPrice(0, 0, 4, 0);
			npc.knockBackResist = 0.5f;
            npc.aiStyle = 3;
            aiType = 214;
			animationType = 110;
			npc.noTileCollide = false;
            banner = npc.type;
            bannerItem = mod.ItemType("RobberBanner");
		}

	    public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Robber");
            DisplayName.AddTranslation(GameCulture.Chinese, "土匪");
            DisplayName.AddTranslation(GameCulture.Russian, "Разбойник");
			Main.npcFrameCount[npc.type] = 20;
		}

	    public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/RobberGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/RobberGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/RobberGore3"), 1f);
			}
		}

	    public override void NPCLoot()
        {
            if (Main.netMode != 1)
            {
                int centerX = (int)(npc.position.X + (float)(npc.width / 2)) / 16;
                int centerY = (int)(npc.position.Y + (float)(npc.height / 2)) / 16;
                int halfLength = npc.width / 2 / 16 + 1;
				if(Main.rand.Next(2) == 0)
				{
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LesserHealingPotion, Main.rand.Next(2,3), false, 0, false, false);
				}
				if(Main.rand.Next(2) == 0)
				{
				    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.LesserManaPotion, Main.rand.Next(2,3), false, 0, false, false);
				}
				if(Main.rand.Next(3) == 0)
				{
				    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.ThrowingKnife, Main.rand.Next(10,15), false, 0, false, false);
				}
                if (Main.rand.Next(5) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("RobberSack"), 1, false, 0, false, false);
                }
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Leather, Main.rand.Next(2,4), false, 0, false, false);
            }
        }

	    public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            int x = spawnInfo.spawnTileX;
            int y = spawnInfo.spawnTileY;
            int tile = (int)Main.tile[x, y].type;
            return (Antiaris.NormalSpawn(spawnInfo) && Antiaris.NoZoneAllowWater(spawnInfo)) && !Main.dayTime && y < Main.worldSurface ? 0.02f : 0f;
        }

	    public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 1);
            npc.damage = (int)(npc.damage * 1);
        }
	}
}
