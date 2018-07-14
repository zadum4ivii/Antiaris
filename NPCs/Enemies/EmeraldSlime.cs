using System;
using Antiaris.NPCs.Town;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.NPCs.Enemies
{
    public class EmeraldSlime : ModNPC
    {
        public override void SetDefaults()
        {
            npc.lifeMax = 84;
            npc.damage = 22;
            npc.defense = 10;
            npc.knockBackResist = 0.4f;
            npc.width = 42;
            npc.height = 34;
            npc.aiStyle = 1;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = Item.buyPrice(0, 0, 10, 0);
            npc.noTileCollide = false;
			npc.buffImmune[20] = true;
			npc.buffImmune[31] = false;
			animationType = 1;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Emerald Slime");
            DisplayName.AddTranslation(GameCulture.Chinese, "翡绿史莱姆");
            DisplayName.AddTranslation(GameCulture.Russian, "Изумрудный слизень");
            Main.npcFrameCount[npc.type] = 2;
        }

        public void OverhaulInit()
        {
            this.SetTag("slime");
            this.SetTag("fireWeakness");
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 1);
            npc.damage = (int)(npc.damage * 1);
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }

        public override void NPCLoot()
        {
            if (Main.netMode != 1)
            {
                int centerX = (int)(npc.position.X + (float)(npc.width / 2)) / 16;
                int centerY = (int)(npc.position.Y + (float)(npc.height / 2)) / 16;
                int halfLength = npc.width / 2 / 16 + 1;
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Gel, Main.rand.Next(1, 3), false, 0, false, false);
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Emerald, Main.rand.Next(4, 7), false, 0, false, false);
				if(Main.rand.Next(3) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("LiquidEmerald"), Main.rand.Next(2, 5), false, 0, false, false);
				}
                var questSystem = Main.player[Main.myPlayer].GetModPlayer<QuestSystem>(mod);
                int number = 0;
                if (questSystem.CurrentQuest == QuestItemID.EmeraldShard)
                {
                    number = Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EmeraldShard"), Main.rand.Next(4, 7), false, 0, false, false);
                    if (Main.netMode == 1 && number >= 0)
                        NetMessage.SendData(21, -1, -1, (NetworkText)null, number, 1f, 0.0f, 0.0f, 0, 0, 0);
                }
            }
        }

        public override void AI()
        {
            npc.TargetClosest(true);
            npc.netUpdate = true;    
			Player player = Main.player[npc.target];
			if (Main.rand.Next(6) == 0)
			{
				var index = Dust.NewDust(npc.position -npc.velocity, npc.width, npc.height, 61, 0.0f, 0.0f, 0, new Color(), 1f);
				Main.dust[index].noGravity = true;
				Main.dust[index].velocity *= 0.15f;
			}
			if ((double)npc.localAI[0] > 0.0)
				--npc.localAI[0];
			if (!npc.wet && !player.npcTypeNoAggro[npc.type])
			{
				Vector2 vector2_1 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
				float x = player.position.X + (float) player.width * 0.5f - vector2_1.X;
				float y = player.position.Y - vector2_1.Y;
				float distance = (float) Math.Sqrt((double) x * (double) x + (double) y * (double) y);
				if (Main.expertMode && (double) distance < 120.0 && (Collision.CanHit(npc.position, npc.width, npc.height, player.position, player.width, player.height) && (double)npc.velocity.Y == 0.0))
				{
					npc.ai[0] = -40f;
					if ((double)npc.velocity.Y == 0.0)
						npc.velocity.X *= 0.9f;
					if (Main.netMode != 1 && (double)npc.localAI[0] == 0.0)
					{
						for (int index = 0; index < 5; ++index)
						{
							Vector2 vector2_2 = new Vector2((float) (index - 2), -4f);
							vector2_2.X *= (float) (1.0 + (double) Main.rand.Next(-50, 51) * 0.00499999988824129);
							vector2_2.Y *= (float) (1.0 + (double) Main.rand.Next(-50, 51) * 0.00499999988824129);
							vector2_2.Normalize();
							vector2_2 *= (float) (4.0 + (double) Main.rand.Next(-50, 51) * 0.00999999977648258);
							Projectile.NewProjectile(vector2_1.X, vector2_1.Y, vector2_2.X, vector2_2.Y, mod.ProjectileType("EmeraldSlimeSpike"), 14, 0.0f, Main.myPlayer, 0.0f, 0.0f);
							npc.localAI[0] = 30f;
						}
					}
				}
				else if ((double) distance < 200.0 && Collision.CanHit(npc.position, npc.width, npc.height, player.position, player.width, player.height) && (double)npc.velocity.Y == 0.0)
				{
					npc.ai[0] = -40f;
					if ((double)npc.velocity.Y == 0.0)
						npc.velocity.X *= 0.9f;
					if (Main.netMode != 1 && (double)npc.localAI[0] == 0.0)
					{
						float newX = player.position.Y - vector2_1.Y - (float) Main.rand.Next(0, 200);
						float newY = 4.5f / (float) Math.Sqrt((double) x * (double) x + (double) newX * (double) newX);
						float sX = x * newY;
						float sY = newX * newY;
						npc.localAI[0] = 50f;
						Projectile.NewProjectile(vector2_1.X, vector2_1.Y, sX, sY, mod.ProjectileType("EmeraldSlimeSpike"), 11, 0.0f, Main.myPlayer, 0.0f, 0.0f);
					}
				}
			}
        }

        public override void HitEffect(int hitDirection, double damage)
        {    
            if (npc.life <= 0)
            {
                for (int k = 0; k < 20; k++)
                {
                    int dust = Dust.NewDust(npc.position, npc.width, npc.height, 61, 0f, 0f, 50, default(Color), 1.5f);
                    Main.dust[dust].velocity *= 2f;
                    Main.dust[dust].noGravity = true;
                }
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            int x = spawnInfo.spawnTileX;
            int y = spawnInfo.spawnTileY;
            int tile = (int)Main.tile[x, y].type;
            return (Antiaris.NoZoneAllowWater(spawnInfo)) && !spawnInfo.player.ZoneDungeon && y > Main.rockLayer ? 0.01f : 0f;
        }
    }
}
