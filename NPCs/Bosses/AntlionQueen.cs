using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.NPCs.Bosses
{
    [AutoloadBossHead]
    public class AntlionQueen : ModNPC
    {
        private int ai;
        private int aiSECOND = 0;

        private double counting;
        private bool end = false;
        private int frame;
        private int moveSpeed;
        private int mv;
        private bool rage = false;
        private bool sAI = false;
        private bool stunned;
        private int stunnedTimer;
        private int swarmerSpawnTimer;

        public override void SetDefaults()
        {
            npc.lifeMax = 6150;
            npc.damage = 30;
            npc.defense = 8;
            npc.knockBackResist = 0f;
            npc.width = 284;
            npc.height = 256;
            npc.npcSlots = 4f;
            npc.HitSound = SoundID.NPCHit31;
            npc.noGravity = true;
            npc.npcSlots = 20f;
            npc.boss = true;
            npc.DeathSound = SoundID.NPCDeath34;
            npc.value = Item.buyPrice(0, 8, 0, 0);  
            npc.noTileCollide = true;
            bossBag = mod.ItemType("AntlionQueenTreasureBag");
            music = mod.GetSoundSlot(Terraria.ModLoader.SoundType.Music, "Sounds/Music/AntlionQueen");
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Antlion Queen");
            DisplayName.AddTranslation(GameCulture.Chinese, "蚁后");
            DisplayName.AddTranslation(GameCulture.Russian, "Королева муравьиных львов");
            Main.npcFrameCount[npc.type] = 9;
        }

        public void OverhaulInit()
        {
            this.SetTag("boss");
        }

        public override void ScaleExpertStats(int playerXPlayers, float bossLifeScale)
        {
            if (playerXPlayers > 1)
            {
                npc.lifeMax = (int)(8150 + (double)npc.lifeMax * 0.2 * (double)playerXPlayers);
            }
            else
            {
                npc.lifeMax = 8150;
            }
            npc.damage = (int)(npc.damage * 0.65f);
        }

        public override void NPCLoot()
        {
			AntiarisWorld.DownedAntlionQueen = true;
            if (Main.expertMode)
            {
                npc.DropBossBags();
            }
            if (!Main.expertMode)
            {
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.HealingPotion, Main.rand.Next(4,12), false, 0, false, false);
                switch (Main.rand.Next(4))
                {
                    case 0:
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DesertRage"), 1, false, 0, false, false);
                        break;
                    case 1:
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ThousandNeedles"), 1, false, 0, false, false);
                        break;
                    case 2:
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AntlionLongbow"), 1, false, 0, false, false);
                        break;
					case 3:
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AntlionStave"), 1, false, 0, false, false);
                        break;
                }
                if (Main.rand.Next(7) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AntlionQueenMask"), 1, false, 0, false, false);
                }
                if (Main.rand.Next(20) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AntlionQueenEgg"), 1, false, 0, false, false);
                }
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AntlionCarapace"), Main.rand.Next(30, 50), false, 0, false, false);
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SandstormScroll"), Main.rand.Next(2, 4), false, 0, false, false);
            }
            if (Main.rand.Next(10) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AntlionQueenTrophy"), 1, false, 0, false, false);
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
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/AntlionQueenGore1"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/AntlionQueenGore2"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/AntlionQueenGore3"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/AntlionQueenGore3"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/AntlionQueenGore4"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/AntlionQueenGore5"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/AntlionQueenGore5"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/AntlionQueenGore6"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/AntlionQueenGore6"), 1f);
            }
        }

        public override void AI()
        {
            Player player = Main.player[npc.target];
            Vector2 target = npc.HasPlayerTarget ? player.Center : Main.npc[npc.target].Center;
            npc.netAlways = true;
            npc.TargetClosest(true);
            npc.rotation = npc.velocity.X * 0.045f;
            this.moveSpeed = (int)((float)((double)npc.lifeMax / (double)npc.life) * 0.05f);
            if ((double)player.position.X >= (double)npc.position.X - 8.0)
                npc.spriteDirection = 1;
            else if ((double)player.position.X < (double)npc.position.X - 8.0)
                npc.spriteDirection = -1;
            if (((!Collision.CanHit(npc.position, npc.width, npc.height, player.position, player.width, player.height)) && npc.justHit) || npc.velocity.Y == 0f)
                if ((npc.collideY) || (npc.collideX))
                    npc.noTileCollide = true;
            else if ((Collision.CanHit(npc.position, npc.width, npc.height, player.position, player.width, player.height)))
                npc.noTileCollide = false;
            if (npc.target < 0 || npc.target == 255 || player.dead || !player.active)
            {
                npc.TargetClosest(false);
                npc.direction = 1;
                if (npc.velocity.X > 0f)
                    npc.velocity.X = npc.velocity.X + 0.75f;
                else
                    npc.velocity.X = npc.velocity.X - 0.75f;
                npc.velocity.Y = npc.velocity.Y - 0.1f;
                if (npc.timeLeft > 10)
                {
                    npc.timeLeft = 10;
                    return;
                }
            }
            if (!player.ZoneDesert)
                AntiarisHelper.MoveTowards(npc, player.Center, 75f, 75f);
            if (this.stunned)
            {
                npc.velocity.Y = 0.0f;
                npc.velocity.X = 0.0f;
                ++this.stunnedTimer;
                if (this.stunnedTimer >= 105)
                {
                    this.stunned = false;
                    this.stunnedTimer = 0;
                }
            }
            if (this.end)
            {
                this.mv = 0;
                this.ai = 0;
                npc.ai[0] = 0f;
                npc.ai[1] = 0f;
                npc.ai[2] = 0f;
                npc.ai[3] = 0f;
                this.sAI = false;
                this.stunned = false;
                this.end = false;
            }
            if (player.ZoneDesert && !player.ZoneBeach)
            {
                this.StartSandstorm();
            }
            ++this.ai;
            if ((double)npc.ai[0] < 150.0 && !this.stunned && !this.sAI)
            {
                npc.ai[0] = (float)this.ai * 1f;
                this.frame = 0;
                AntiarisHelper.MoveTowards(npc, target - new Vector2(0f, 250f), this.rage ? 40f : 30f, 30f);
                npc.ai[1] += 1f;
                if (npc.ai[1] % (float)(Main.expertMode ? 25 : 30) == 0)
                {
                    int y = (int)(npc.Center.Y / 16f);
                    int x = (int)(npc.Center.X / 16f);
                    int size = 100;
                    if (x < 10)
                    {
                        x = 10;
                    }
                    if (x > Main.maxTilesX - 10)
                    {
                        x = Main.maxTilesX - 10;
                    }
                    if (y < 10)
                    {
                        y = 10;
                    }
                    if (y > Main.maxTilesY - size - 10)
                    {
                        y = Main.maxTilesY - size - 10;
                    }
                    for (int finPos = y; finPos < y + size; finPos++)
                    {
                        Tile tile = Main.tile[x, finPos];
                        if (tile.active() && (Main.tileSolid[(int)tile.type] || tile.liquid != 0))
                        {
                            y = finPos;
                            break;
                        }
                    }
                    Projectile.NewProjectile((float)(x * 16 + 8), (float)(y * 16 - 56), 0f, 0f, mod.ProjectileType("Sandnado"), npc.damage / 2, 0f, Main.myPlayer, 16f, 15f);
                }
                npc.netUpdate = true;
            }
            else if ((double)npc.ai[0] >= 145.0 && !this.stunned && !this.sAI)
            {
                npc.noTileCollide = false;
                npc.velocity.X = 0f;
                npc.velocity.Y = 5f;
                this.frame = 1;
                npc.netUpdate = true;
                ++this.swarmerSpawnTimer;
                ++npc.ai[2];
                if ((double)npc.ai[2] > 60.0 && this.swarmerSpawnTimer > 60)
                {
                    Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
                    NPC.NewNPC((int)(player.Center.X + 1200f), (int)(player.Center.Y - 1000f), 509, 0, (float)npc.whoAmI, 0.0f, 0.0f, 0.0f, (int)byte.MaxValue);
                    if ((double)(npc.lifeMax - npc.life) > (double)(40.0 * 100f))
                    {
                        NPC.NewNPC((int)(player.Center.X - 1200f), (int)(player.Center.Y - 1000f), 508, 0, (float)npc.whoAmI, 0.0f, 0.0f, 0.0f, (int)byte.MaxValue);
                    }
                    this.swarmerSpawnTimer -= (Main.expertMode ? 30 : 60);
                }
                if ((double)npc.ai[2] > 120.0)
                {
                    this.swarmerSpawnTimer = 0;
                    this.sAI = true;
                    npc.ai[3] = 10f;
                }
                npc.netUpdate = true;
            }
            if ((double)npc.ai[3] >= 10.0 && (double)npc.ai[3] < 20.0)
            {
                this.mv += 1 + (int)((npc.life > npc.lifeMax / 2 ? 0 : 1) +  (npc.life > npc.lifeMax / 3 ? 0 : 1));
                this.frame = 0;
                npc.noTileCollide = true;
                if (this.mv >= 150 && this.mv < 500)
                {
                    Vector2 vector2_1 = player.Center + new Vector2(0.0f, -400.0f);
                    float speed = 7f;
                    Vector2 vector2_2 = vector2_1 - npc.Center;
                    float distance = (float)Math.Sqrt((double)vector2_2.X * (double)vector2_2.X + (double)vector2_2.Y * (double)vector2_2.Y);
                    vector2_2 *= speed / distance;
                    npc.velocity = vector2_2;
                    if (this.mv > 350)
                    {
                        Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
                        npc.velocity.X = 0.0f;
                        npc.velocity.Y = 20f;
                        if ((double)npc.position.Y < (double)player.position.Y + 500.0)
                        {
                            this.mv = 425;
                        }
                    }
                    if (this.mv >= 425)
                    {
                        AntiarisHelper.MoveTowards(npc, target - new Vector2(0f, 25f), (npc.life <= npc.lifeMax * 0.35f) ? 435f : 275f, 30f);
                    }
                }
                else if (this.mv >= 650 && this.mv < 1000)
                {
                    Vector2 vector2_1 = player.Center + new Vector2(-400.0f, 0.0f);
                    float speed = 7f;
                    Vector2 vector2_2 = vector2_1 - npc.Center;
                    float distance = (float)Math.Sqrt((double)vector2_2.X * (double)vector2_2.X + (double)vector2_2.Y * (double)vector2_2.Y);
                    vector2_2 *= speed / distance;
                    npc.velocity = vector2_2;
                    if (this.mv > 850)
                    {
                        Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
                        npc.velocity.X = 20f;
                        npc.velocity.Y = 0.0f;
                        if ((double)npc.position.X < (double)player.position.X + 500.0)
                        {
                            this.mv = 925;
                        }
                    }
                    if (this.mv >= 925)
                    {
                        AntiarisHelper.MoveTowards(npc, target - new Vector2(0f, 25f), (npc.life <= npc.lifeMax * 0.35f) ? 435f : 275f, 30f);
                    }
                }
                else if (this.mv >= 1150 && this.mv < 1500)
                {
                    Vector2 vector2_1 = player.Center + new Vector2(400.0f, 0.0f);
                    float speed = 7f;
                    Vector2 vector2_2 = vector2_1 - npc.Center;
                    float distance = (float)Math.Sqrt((double)vector2_2.X * (double)vector2_2.X + (double)vector2_2.Y * (double)vector2_2.Y);
                    vector2_2 *= speed / distance;
                    npc.velocity = vector2_2;
                    if (this.mv > 1350)
                    {
                        Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
                        npc.velocity.X = -20f;
                        npc.velocity.Y = 0.0f;
                        if ((double)npc.position.X > (double)player.position.X - 500.0)
                        {
                            this.mv = 1425;
                        }
                    }
                    if (this.mv >= 1425)
                    {
                        AntiarisHelper.MoveTowards(npc, target - new Vector2(0f, 25f), (npc.life <= npc.lifeMax * 0.35f) ? 435f : 275f, 30f);
                    }
                }
                else
                {
                    AntiarisHelper.MoveTowards(npc, target, Vector2.Distance(target, npc.Center) > 500 ? (Main.expertMode ? 32f : 30f) : (Main.expertMode ? 13f : 11f), 30f);
                }
                if (this.mv >= 1600)
                {
                    this.mv = 0;
                    npc.ai[3] = 20f;
                }
                npc.netUpdate = true;
            }
            else if ((double)npc.ai[3] >= 20.0 && (double)npc.ai[3] < 30.0)
            {
                AntiarisHelper.MoveTowards(npc, target, Vector2.Distance(target, npc.Center) > 500 ? (Main.expertMode ? 32f : 30f) : (Main.expertMode ? 13f : 11f), 30f);
                this.mv += (int)0.2 + (int)((npc.life > npc.lifeMax / 2 ? 0 : 1) +  (npc.life > npc.lifeMax / 3 ? 0 : 1));
                this.frame = 0;
                if (this.mv >= 100 && this.mv < 175)
                {
                    if (this.mv % 10 == 0)
                    {
                        Vector2 shootPos = (npc.Top + new Vector2((npc.direction == -1 ? -150f : 150f), 155f)).RotatedBy(npc.rotation, npc.Center);
                        float inaccuracy = 3f * (npc.life / npc.lifeMax);
                        Vector2 shootVel = target - shootPos + new Vector2(Main.rand.NextFloat(-inaccuracy, inaccuracy), Main.rand.NextFloat(-inaccuracy, inaccuracy));
                        shootVel.Normalize();
                        shootVel *= 28f;
                        int k = Projectile.NewProjectile(shootPos, shootVel, 31, npc.damage / 2, 5f, Main.myPlayer);
                        Main.projectile[k].friendly = false;
                        Main.projectile[k].hostile = true;
                        Main.projectile[k].scale = 1.4f;
                    }
                }
                else if (this.mv >= 175)
                {
                    this.mv = 0;
                    npc.ai[3] = 30f;
                }
                npc.netUpdate = true;
            }
            else if ((double)npc.ai[3] >= 30.0)
            {
                this.mv += 2 + (int)((npc.life > npc.lifeMax / 2 ? 0 : 1) +  (npc.life > npc.lifeMax / 3 ? 0 : 1));
                this.frame = 0;
                if (this.mv % 500 == 0)
                {
                    Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
                    NPC.NewNPC((int)(player.Center.X - 1200f), (int)(player.Center.Y - 1000f), 508, 0, (float)npc.whoAmI, 0.0f, 0.0f, 0.0f, (int)byte.MaxValue);
                    NPC.NewNPC((int)(player.Center.X + 1200f), (int)(player.Center.Y - 1000f), 508, 0, (float)npc.whoAmI, 0.0f, 0.0f, 0.0f, (int)byte.MaxValue);
                }
                if (this.mv >= 650 && this.mv < 800)
                {
                    if (this.mv >= 650 && this.mv < 725)
                    {
                        if (player.position.Y < npc.position.Y + 650)
                        {
                            npc.velocity.Y -= 0.44f;
                        }
                    }
                    if (player.position.Y >= npc.position.Y + 650)
                    {
                        Vector2 targetPos = player.Center;
                        float speed = 15f;
                        float speedFactor = 0.7f;
                        Vector2 center = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                        float posX = targetPos.X - center.X;
                        float posY = targetPos.Y - center.Y;
                        float distance = (float)Math.Sqrt((double)(posX * posX + posY * posY));
                        distance = speed / distance;
                        posX *= distance;
                        posY *= distance;
                        if (npc.velocity.X < posX)
                        {
                            npc.velocity.X = npc.velocity.X + speedFactor;
                            if (npc.velocity.X < 0f && posX > 0f)
                                npc.velocity.X = npc.velocity.X + speedFactor;
                        }
                        else if (npc.velocity.X > posX)
                        {
                            npc.velocity.X = npc.velocity.X - speedFactor;
                            if (npc.velocity.X > 0f && posX < 0f)
                                npc.velocity.X = npc.velocity.X - speedFactor;
                        }
                        if (npc.velocity.Y < posY)
                        {
                            npc.velocity.Y = npc.velocity.Y + speedFactor;
                            if (npc.velocity.Y < 0f && posY > 0f)
                                npc.velocity.Y = npc.velocity.Y + speedFactor;
                        }
                        else if (npc.velocity.Y > posY)
                        {
                            npc.velocity.Y = npc.velocity.Y - speedFactor;
                            if (npc.velocity.Y > 0f && posY < 0f)
                                npc.velocity.Y = npc.velocity.Y - speedFactor;
                        }
                        this.mv = 720;
                    }
                }
                else if (this.mv >= 1000 && this.mv < 1150)
                {
                    if (this.mv >= 1000 && this.mv < 1075)
                    {
                        if (player.position.Y < npc.position.Y + 650)
                        {
                            npc.velocity.Y -= 0.44f;
                        }
                    }
                    if (player.position.Y >= npc.position.Y + 650)
                    {
                        Vector2 targetPos = player.Center;
                        float speed = 15f;
                        float speedFactor = 0.7f;
                        Vector2 center = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                        float posX = targetPos.X - center.X;
                        float posY = targetPos.Y - center.Y;
                        float distance = (float)Math.Sqrt((double)(posX * posX + posY * posY));
                        distance = speed / distance;
                        posX *= distance;
                        posY *= distance;
                        if (npc.velocity.X < posX)
                        {
                            npc.velocity.X = npc.velocity.X + speedFactor;
                            if (npc.velocity.X < 0f && posX > 0f)
                                npc.velocity.X = npc.velocity.X + speedFactor;
                        }
                        else if (npc.velocity.X > posX)
                        {
                            npc.velocity.X = npc.velocity.X - speedFactor;
                            if (npc.velocity.X > 0f && posX < 0f)
                                npc.velocity.X = npc.velocity.X - speedFactor;
                        }
                        if (npc.velocity.Y < posY)
                        {
                            npc.velocity.Y = npc.velocity.Y + speedFactor;
                            if (npc.velocity.Y < 0f && posY > 0f)
                                npc.velocity.Y = npc.velocity.Y + speedFactor;
                        }
                        else if (npc.velocity.Y > posY)
                        {
                            npc.velocity.Y = npc.velocity.Y - speedFactor;
                            if (npc.velocity.Y > 0f && posY < 0f)
                                npc.velocity.Y = npc.velocity.Y - speedFactor;
                        }
                        this.mv = 1070;
                    }
                }
                else
                {
                    AntiarisHelper.MoveTowards(npc, target, Vector2.Distance(target, npc.Center) > 500 ? (Main.expertMode ? 32f : 30f) : (Main.expertMode ? 13f : 11f), 30f);
                }
                if (this.mv >= 1150)
                {
                    this.end = true;
                }
                npc.netUpdate = true;
            }
            if (npc.life <= npc.lifeMax * 0.35f)
                this.rage = true;
            if (npc.life <= npc.lifeMax * 0.15f)
            {
                this.end = true;
                this.frame = 0;
                this.stunned = true;
                npc.noTileCollide = false;
                Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
                ++this.aiSECOND;
                if (this.aiSECOND % 2 == 0 && this.aiSECOND <= 120)
                {
                    var ShootPos = player.position + new Vector2(Main.rand.Next(-1000, 1000), -1000);
                    var ShootVel = new Vector2(Main.rand.NextFloat(-3f, 3f), Main.rand.NextFloat(15f, 20f));
                    var k = Projectile.NewProjectile(ShootPos, ShootVel, 31, npc.damage / 4, 1f);
                    Main.projectile[k].friendly = false;
                    Main.projectile[k].hostile = true;
                    Main.projectile[k].scale = 1.4f;
					Main.projectile[k].tileCollide = false;
                }
                if (this.aiSECOND >= 250 && this.aiSECOND < 320 && this.aiSECOND % 15 == 0)
                {
                    var shootPos = (npc.Top + new Vector2((npc.direction == -1 ? -150f : 150f), 155f)).RotatedBy(npc.rotation, npc.Center);
                    var inaccuracy = 3f * (npc.life / npc.lifeMax);
                    var shootVel = target - shootPos + new Vector2(Main.rand.NextFloat(-inaccuracy, inaccuracy), Main.rand.NextFloat(-inaccuracy, inaccuracy));
                    shootVel.Normalize();
                    shootVel *= 28f;
                    var k = Projectile.NewProjectile(shootPos, shootVel, 31, npc.damage / 2, 5f, Main.myPlayer);
                    Main.projectile[k].friendly = false;
                    Main.projectile[k].hostile = true;
                    Main.projectile[k].scale = 1.4f;
                }
                if (this.aiSECOND >= 450)
                {
                    this.aiSECOND = 0;
                }
                if (Main.expertMode)
                {
                    if (this.aiSECOND % 250 == 0)
                    {
                        NPC.NewNPC((int)(player.Center.X - 1200f), (int)(player.Center.Y - 1000f), 508, 0, (float)npc.whoAmI, 0.0f, 0.0f, 0.0f, (int)byte.MaxValue);
                        NPC.NewNPC((int)(player.Center.X - 1200f), (int)(player.Center.Y - 1000f), 509, 0, (float)npc.whoAmI, 0.0f, 0.0f, 0.0f, (int)byte.MaxValue);
                    }
                }
            }
        }

        public override void FindFrame(int frameHeight)
        {
            if (this.frame == 0)
            {
                counting += 2.0;
                if (counting < 8.0)
                {
                    npc.frame.Y = 0;
                }
                else if (counting < 16.0)
                {
                    npc.frame.Y = frameHeight;
                }
                else if (counting < 24.0)
                {
                    npc.frame.Y = frameHeight * 2;
                }
                else if (counting < 32.0)
                {
                    npc.frame.Y = frameHeight * 3;
                }
                else if (counting < 40.0)
                {
                    npc.frame.Y = frameHeight * 4;
                }
                else if (counting < 48.0)
                {
                    npc.frame.Y = frameHeight * 5;
                }
                else if (counting < 56.0)
                {
                    npc.frame.Y = frameHeight * 6;
                }
                else if (counting < 64.0)
                {
                    npc.frame.Y = frameHeight * 7;
                }
                else
                {
                    counting = 0.0;
                }
            }
            else
                npc.frame.Y = frameHeight * 8;
        }

        public override void BossHeadRotation(ref float rotation)
        {
            rotation = npc.rotation;
        }

        private void StartSandstorm()
        {
            Sandstorm.Happening = true;
            Sandstorm.TimeLeft = (int)(3600.0 * (8.0 + (double)Main.rand.NextFloat() * 16.0));
            this.ChangeSeverityIntentions();
        }

        private void StopSandstorm()
        {
            Sandstorm.Happening = false;
            Sandstorm.TimeLeft = 0;
            this.ChangeSeverityIntentions();
        }

        private void ChangeSeverityIntentions()
        {
            Sandstorm.IntendedSeverity = !Sandstorm.Happening ? (Main.rand.Next(3) != 0 ? Main.rand.NextFloat() * 0.3f : 0.0f) : 0.4f + Main.rand.NextFloat();
        }

        public override bool CheckDead()
        {
            var player = Main.player[npc.target];
            if (player.ZoneDesert && !player.ZoneBeach)
            {
                StopSandstorm();
            }
            Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
            return base.CheckDead();
        }
    }
}