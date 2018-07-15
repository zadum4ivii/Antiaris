using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.NPCs.Enemies
{
    public class BabyCreeper : ModNPC
    {
        public override void SetDefaults()
        {
            npc.lifeMax = 50;
            npc.damage = 12;
            npc.defense = 6;
            npc.knockBackResist = 0f;
            npc.width = 34;
            npc.height = 36;
            npc.aiStyle = -1;
            npc.npcSlots = 0.5f;
            npc.HitSound = SoundID.NPCHit1;
            npc.noGravity = true;
            npc.buffImmune[20] = true;
            npc.buffImmune[70] = true;
            npc.npcSlots = 2f;
            npc.DeathSound = SoundID.NPCDeath1;
			npc.value = Item.buyPrice(0, 0, 1, 15);
            animationType = 238;
            npc.rarity = 1;
            banner = npc.type;
            bannerItem = mod.ItemType("BabyCreeperBanner");
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Baby Creeper");
            DisplayName.AddTranslation(GameCulture.Chinese, "爬行者幼体");
            DisplayName.AddTranslation(GameCulture.Russian, "Маленький паучок");
            Main.npcFrameCount[npc.type] = 4;
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
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SpiderMass"), Main.rand.Next(2, 4), false, 0, false, false);
            }
        }

        public override void AI()
        {
            //vanilla code
            npc.TargetClosest(true);
            Player player = Main.player[npc.target];
            if (npc.target < 0 || npc.target == (int)byte.MaxValue || Main.player[npc.target].dead)
                npc.TargetClosest(true);
            float num1 = 2f;
            float num2 = 0.08f;
            Vector2 vector2 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
            float num3 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2);
            float num4 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2);
            float num5 = (float)((int)((double)num3 / 8.0) * 8);
            float num6 = (float)((int)((double)num4 / 8.0) * 8);
            vector2.X = (float)((int)((double)vector2.X / 8.0) * 8);
            vector2.Y = (float)((int)((double)vector2.Y / 8.0) * 8);
            float num7 = num5 - vector2.X;
            float num8 = num6 - vector2.Y;
            float num9 = (float)Math.Sqrt((double)num7 * (double)num7 + (double)num8 * (double)num8);
            float num10;
            float num11;
            if ((double)num9 == 0.0)
            {
                num10 = npc.velocity.X;
                num11 = npc.velocity.Y;
            }
            else
            {
                float num12 = num1 / num9;
                num10 = num7 * num12;
                num11 = num8 * num12;
            }
            if (Main.player[npc.target].dead)
            {
                num10 = (float)((double)npc.direction * (double)num1 / 2.0);
                num11 = (float)(-(double)num1 / 2.0);
            }
            npc.spriteDirection = -1;
            if (!Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height))
            {
                ++npc.ai[0];
                if ((double)npc.ai[0] > 0.0)
                    npc.velocity.Y = npc.velocity.Y + 23f / 1000f;
                else
                    npc.velocity.Y = npc.velocity.Y - 23f / 1000f;
                if ((double)npc.ai[0] < -100.0 || (double)npc.ai[0] > 100.0)
                    npc.velocity.X = npc.velocity.X + 23f / 1000f;
                else
                    npc.velocity.X = npc.velocity.X - 23f / 1000f;
                if ((double)npc.ai[0] > 200.0)
                    npc.ai[0] = -200f;
                npc.velocity.X = npc.velocity.X + num10 * 0.007f;
                npc.velocity.Y = npc.velocity.Y + num11 * 0.007f;
                npc.rotation = (float)Math.Atan2((double)npc.velocity.Y, (double)npc.velocity.X);
                if ((double)npc.velocity.X > 1.5)
                    npc.velocity.X = npc.velocity.X * 0.9f;
                if ((double)npc.velocity.X < -1.5)
                    npc.velocity.X = npc.velocity.X * 0.9f;
                if ((double)npc.velocity.Y > 1.5)
                    npc.velocity.Y = npc.velocity.Y * 0.9f;
                if ((double)npc.velocity.Y < -1.5)
                    npc.velocity.Y = npc.velocity.Y * 0.9f;
                if ((double)npc.velocity.X > 3.0)
                    npc.velocity.X = 3f;
                if ((double)npc.velocity.X < -3.0)
                    npc.velocity.X = -3f;
                if ((double)npc.velocity.Y > 3.0)
                    npc.velocity.Y = 3f;
                if ((double)npc.velocity.Y < -3.0)
                    npc.velocity.Y = -3f;
            }
            else
            {
                if ((double)npc.velocity.X < (double)num10)
                {
                    npc.velocity.X = npc.velocity.X + num2;
                    if ((double)npc.velocity.X < 0.0 && (double)num10 > 0.0)
                        npc.velocity.X = npc.velocity.X + num2;
                }
                else if ((double)npc.velocity.X > (double)num10)
                {
                    npc.velocity.X = npc.velocity.X - num2;
                    if ((double)npc.velocity.X > 0.0 && (double)num10 < 0.0)
                        npc.velocity.X = npc.velocity.X - num2;
                }
                if ((double)npc.velocity.Y < (double)num11)
                {
                    npc.velocity.Y = npc.velocity.Y + num2;
                    if ((double)npc.velocity.Y < 0.0 && (double)num11 > 0.0)
                        npc.velocity.Y = npc.velocity.Y + num2;
                }
                else if ((double)npc.velocity.Y > (double)num11)
                {
                    npc.velocity.Y = npc.velocity.Y - num2;
                    if ((double)npc.velocity.Y > 0.0 && (double)num11 < 0.0)
                        npc.velocity.Y = npc.velocity.Y - num2;
                }
                npc.rotation = (float)Math.Atan2((double)num11, (double)num10);
            }
            float num13 = 0.5f;
            if (npc.collideX)
            {
                npc.netUpdate = true;
                npc.velocity.X = npc.oldVelocity.X * -num13;
                if (npc.direction == -1 && (double)npc.velocity.X > 0.0 && (double)npc.velocity.X < 2.0)
                    npc.velocity.X = 2f;
                if (npc.direction == 1 && (double)npc.velocity.X < 0.0 && (double)npc.velocity.X > -2.0)
                    npc.velocity.X = -2f;
            }
            if (npc.collideY)
            {
                npc.netUpdate = true;
                npc.velocity.Y = npc.oldVelocity.Y * -num13;
                if ((double)npc.velocity.Y > 0.0 && (double)npc.velocity.Y < 1.5)
                    npc.velocity.Y = 2f;
                if ((double)npc.velocity.Y < 0.0 && (double)npc.velocity.Y > -1.5)
                    npc.velocity.Y = -2f;
            }
            if (((double)npc.velocity.X > 0.0 && (double)npc.oldVelocity.X < 0.0 || (double)npc.velocity.X < 0.0 && (double)npc.oldVelocity.X > 0.0 || ((double)npc.velocity.Y > 0.0 && (double)npc.oldVelocity.Y < 0.0 || (double)npc.velocity.Y < 0.0 && (double)npc.oldVelocity.Y > 0.0)) && !npc.justHit)
                npc.netUpdate = true;
            if (Main.netMode == 1)
                return;
            if (Main.netMode != 1 && Main.expertMode && (npc.target >= 0 && Collision.CanHit(npc.Center, 1, 1, Main.player[npc.target].Center, 1, 1)))
            {
                ++npc.localAI[0];
                if (npc.justHit)
                {
                    npc.localAI[0] -= (float)Main.rand.Next(20, 60);
                    if ((double)npc.localAI[0] < 0.0)
                        npc.localAI[0] = 0.0f;
                }
                if ((double)npc.localAI[0] > 225.0)
                    npc.localAI[0] = 0.0f;
            }
            int num14 = (int)npc.Center.X / 16;
            int num15 = (int)npc.Center.Y / 16;
            bool flag = false;
            for (int index1 = num14 - 1; index1 <= num14 + 1; ++index1)
            {
                for (int index2 = num15 - 1; index2 <= num15 + 1; ++index2)
                {
                    if (Main.tile[index1, index2] == null)
                        return;
                    if ((int)Main.tile[index1, index2].wall > 0)
                        flag = true;
                }
            }
            if (flag)
                return;
            npc.Transform(mod.NPCType("BabyCreeperGround"));
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                for (var i = 0; i < 20; ++i)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, 53, 2.5f * (float)hitDirection, -2.5f, 0, new Color(), 1f);
                }
            }
            else
            {
                for (var i = 0; (double)i < damage / (double)npc.lifeMax * 50.0; ++i)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, 53, (float)hitDirection, -1f, 0, new Color(), 0.8f);
                }
            }
        }
    }
}