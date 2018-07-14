using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.NPCs.Enemies
{
    public class TreacherousConjurer : ModNPC
    {
        private int animation = 0;
        private float animationTimer = 0.0f;
        private float attack = 0.0f;

        private bool attacking;
        private float attackingTimer = 0f;
        private bool spawned = false;
        private int state = 1;
        private float timer = 0.0f;

        public override void SetDefaults()
        {
            npc.lifeMax = 445;
            npc.damage = 29;
            npc.defense = 9;
            npc.aiStyle = 0;
            npc.knockBackResist = 0.0f;
            npc.width = 38;
            npc.height = 62;
            npc.value = (float)Item.buyPrice(0, 0, 36, 75);
            npc.HitSound = SoundID.NPCHit2;
            npc.DeathSound = SoundID.NPCDeath2;
            npc.buffImmune[BuffID.OnFire] = true;
            npc.buffImmune[BuffID.Slow] = true;
            npc.buffImmune[mod.BuffType("Deceleration")] = true;
            npc.buffImmune[mod.BuffType("Electrified")] = true;
            bannerItem = mod.ItemType("TreacherousConjurerBanner");
            banner = npc.type;
            npc.rarity = 1;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Treacherous Conjurer");
            DisplayName.AddTranslation(GameCulture.Russian, "Коварный заклинатель");
			DisplayName.AddTranslation(GameCulture.Chinese, "千瞬巫师");
            Main.npcFrameCount[npc.type] = 17;
        }

        public void OverhaulInit()
        {
            this.SetTag("bone");
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.6f);
            npc.damage = (int)(npc.damage * 0.06f);
        }

        public override void AI()
		{
            npc.TargetClosest(true);
            this.spawned = true;
            Player player = Main.player[npc.target];
            Vector2 vector2_1 = player.Center + new Vector2(npc.Center.X, npc.Center.Y);
            Vector2 vector2_2 = npc.Center + new Vector2(npc.Center.X, npc.Center.Y);
            npc.netUpdate = true;
            if ((double)player.position.X > (double)npc.position.X) npc.spriteDirection = 1;
            else if ((double)player.position.X < (double)npc.position.X) npc.spriteDirection = -1;
            npc.TargetClosest(true);
            npc.velocity.X = npc.velocity.X * 0.93f;
            npc.velocity.X = 0.0f;
            npc.velocity.Y = 5.0f;
            if (npc.target < 0 || npc.target == 255 || player.dead || !player.active)
            {
                npc.TargetClosest(false);
                this.state = -1;
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 8);
                for (int k = 0; k < 50; k++)
                {
                    int dust = Dust.NewDust(npc.position, npc.width, npc.height, DustID.GoldFlame, 0.0f, 0.0f, 100, new Color(), 1.8f);
                    Main.dust[dust].velocity *= 3f;
                    Main.dust[dust].noGravity = true;
                }
                Projectile.NewProjectile(npc.Center.X - (float)(npc.width / 2), npc.Center.Y, 0.0f, 0.0f, mod.ProjectileType("TreacherousExplosion"), npc.damage, 10.0f, 0, 0.0f, 0.0f);
                npc.life = -1; npc.active = false; npc.checkDead();
            }
            if ((double)npc.velocity.X > -0.1 && (double)npc.velocity.X < 0.1) npc.velocity.X = 0.0f;
            if (this.spawned && (double)npc.ai[0] == 0.0) npc.ai[0] = 500f;
            if (this.state == -1) this.animation = 0;
            else if (this.state == 0)
            {
                this.animation = 11;
                ++this.timer;
                if ((double)this.timer >= 110.0)
                {
                    this.timer = 0.0f;
                    this.state = 2;
                }
            }
            else if (this.state == 1)
            {
                this.animationTimer++;
                if ((double)this.animationTimer > 7.0)
                {
                    this.animationTimer = 0.0f;
                    this.animation += 1;
                }
                if (this.animation >= 11)
                {
                    this.animationTimer = 0.0f;
                    this.state = 0;
                }
            }
            else if (this.state == 2)
            {
                ++this.animationTimer;
                if ((double)this.animationTimer > 7.0)
                {
                    this.animationTimer = 0.0f;
                    this.animation += 1;
                }
                if (this.animation >= 16)
                {
                    this.animationTimer = 0.0f;
                    this.state = -1;
                }
            }
            if ((double)npc.ai[2] != 0.0 && (double)npc.ai[3] != 0.0)
            {
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 8);
                for (int k = 0; k < 50; k++)
                {
                    int dust = Dust.NewDust(npc.position, npc.width, npc.height, DustID.GoldFlame, 0.0f, 0.0f, 100, new Color(), 1.8f);
                    Main.dust[dust].velocity *= 3f;
                    Main.dust[dust].noGravity = true;
                }
                npc.position.X = (float)((double)npc.ai[2] * 16.0 - (double)(npc.width / 2) + 8.0);
                npc.position.Y = npc.ai[3] * 16f - (float)npc.height;
                Projectile.NewProjectile(npc.Center.X - (float)(npc.width / 2), npc.Center.Y, 0.0f, 0.0f, mod.ProjectileType("TreacherousExplosion"), npc.damage, 10.0f, 0, 0.0f, 0.0f);
                npc.velocity.X = 0.0f;
                npc.velocity.Y = 0.0f;              
                npc.ai[2] = 0.0f;
                npc.ai[3] = 0.0f;
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 8);
                for (int k = 0; k < 50; k++)
                {
                    int dust = Dust.NewDust(npc.position, npc.width, npc.height, DustID.GoldFlame, 0.0f, 0.0f, 100, new Color(), 1.8f);
                    Main.dust[dust].velocity *= 3f;
                    Main.dust[dust].noGravity = true;
                }
            }
            ++npc.ai[0];
            int spawn = Main.rand.Next(350, (Main.expertMode ? 450 : 600));
            if ((int)npc.ai[0] >= spawn)
            {
                npc.ai[0] = 1.0f;
                this.attackingTimer = 1f;
                int pX = (int)player.position.X / 16;
                int pY = (int)player.position.Y / 16;
                int x = (int)npc.position.X / 16;
                int y = (int)npc.position.Y / 16;
                int rand = 20;
                int distance = 0;
                bool checkDistance = false;
                if ((double)Math.Abs(npc.position.X - player.position.X) + (double)Math.Abs(npc.position.Y - player.position.Y) > 2000.0)
                {
                    distance = 100;
                    checkDistance = true;
                }
                while (!checkDistance && distance < 100)
                {
                    ++distance;
                    int k = Main.rand.Next(pX - rand, pX + rand);
                    for (int j = Main.rand.Next(pY - rand, pY + rand); j < pY + rand; ++j)
                    {
                        if ((j < pY - 4 || j > pY + 4 || (k < pX - 4 || k > pX + 4)) && (j < y - 1 || j > y + 1 || (k < x - 1 || k > x + 1)) && Main.tile[k, j].nactive())
                        {
                            bool flag2 = true;
                            if (Main.tile[k, j - 1].lava())
                                flag2 = false;
                            if (flag2 && Main.tileSolid[(int)Main.tile[k, j].type] && !Collision.SolidTiles(k - 1, k + 1, j - 4, j - 1))
                            {
                                this.state = 1;
                                this.attack = 55.0f;
                                npc.ai[2] = (float)k;
                                npc.ai[3] = (float)j;
                                checkDistance = true;
                                this.spawned = false;
                                break;
                            }
                        }
                    }
                }
                npc.netUpdate = true;
            }
            if ((double)this.attack > 0.0 && Main.netMode != 1)
            {
                --this.attack;
                if ((double)this.attack > 35.0)
                    return;
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 8);
                NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("TreacherousSphere"), 0, (float)npc.whoAmI, 0.0f, 0.0f, 0.0f, 255);
                this.attack = 0.0f;
            }
            if ((double)npc.ai[0] >= 270.0 && (double)npc.ai[0] < spawn && Main.netMode != 1)
            {
                if ((double)npc.ai[0] % 5.0 == 1.0)
                {
                    float speed = (float)(3.0 + (double)Main.rand.NextFloat() * 6.0);
                    Vector2 start = Vector2.UnitY.RotatedByRandom(6.28318548202515);
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 45.0f, start.X * speed, start.Y * speed, mod.ProjectileType("TreacherousEnergy"), npc.damage / 3 + 15, 3.0f, 0, (float)npc.target, 0.0f);
                }
            }
            if ((double)npc.ai[0] < 250.0) this.attacking = true;
            else if ((double)npc.ai[0] >= 250.0) this.attacking = false;
        }

        public override void FindFrame(int frameHeight)
        {
            npc.frame.Y = this.animation * frameHeight;
        }

        public override void NPCLoot()
        {
            if (Main.rand.NextBool(1, 15)) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TreacheousBoltStaff"), 1, false, 0, false, false);
            if (Main.rand.NextBool(1, 15)) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TreacherousSphereStaff"), 1, false, 0, false, false);
            if (Main.rand.NextBool(1, 3)) return;
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("WandCore"), 1, false, 0, false, false);
        }

        public override void HitEffect(int hitDirection, double damage) { if (npc.life <= 0) for (int k = 0; k < 6; k++) Gore.NewGore(npc.position, new Vector2(), mod.GetGoreSlot("Gores/TreacherousConjurerGore" + k), 1f); }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (!Main.hardMode)
                return (double)spawnInfo.spawnTileY <= Main.worldSurface || spawnInfo.playerSafe || (!spawnInfo.player.ZoneDungeon || !Antiaris.NoInvasion(spawnInfo)) ? 0.0f : 0.02f;
            return (double)spawnInfo.spawnTileY <= Main.worldSurface || spawnInfo.playerSafe || (!spawnInfo.player.ZoneDungeon || !Antiaris.NoInvasion(spawnInfo)) ? 0.0f : 0.01f;
        }

        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor) { AntiarisUtils.DrawNPCGlowMask(spriteBatch, mod.GetTexture("Glow/" + GetType().Name + "_GlowMask"), npc, Color.White, 0.0f, 1f); }
    }
}

