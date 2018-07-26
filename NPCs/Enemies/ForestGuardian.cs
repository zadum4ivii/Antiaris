using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.NPCs.Enemies
{
    public class ForestGuardian : ModNPC
    {
        private int frame = 1;

        private int timer = 0;
        private int timer2 = 0;
        private int timer3 = 0;

        public override void SetDefaults()
        {
            npc.lifeMax = 54;
            npc.damage = 12;
            npc.defense = 5;
            npc.knockBackResist = 1f;
            npc.width = 44;
            npc.height = 66;
            npc.aiStyle = 22;
            npc.npcSlots = 0.5f;
            npc.HitSound = SoundID.NPCHit44;
            npc.DeathSound = SoundID.NPCDeath58;
            npc.value = Item.buyPrice(0, 0, 0, 5);
            npc.noTileCollide = true;
            npc.noGravity = true;
            banner = npc.type;
            aiType = 121;
            bannerItem = mod.ItemType("ForestGuardianBanner");
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Forest Guardian");
            DisplayName.AddTranslation(GameCulture.Chinese, "森林守护者");
            DisplayName.AddTranslation(GameCulture.Russian, "Страж леса");
            Main.npcFrameCount[npc.type] = 11;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 1);
            npc.damage = (int)(npc.damage * 1);
        }

        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            var GlowMask = mod.GetTexture("Glow/ForestGuardian_GlowMask");
            var Effects = npc.direction == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            spriteBatch.Draw(GlowMask, npc.Center - Main.screenPosition + new Vector2(0, npc.gfxOffY), npc.frame, Color.White, npc.rotation, npc.frame.Size() / 2, npc.scale, Effects, 0);
        }

        public override void AI()
        {
            npc.TargetClosest(true);
            var player = Main.player[npc.target];
            npc.netUpdate = true;
            npc.spriteDirection = npc.direction;
            npc.rotation = npc.velocity.X * 0.1f;
            if (npc.target < 0 || npc.target == 255 || player.dead || !player.active)
            {
                npc.TargetClosest(false);
                if (npc.velocity.X > 0.0f)
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
            if (Main.rand.Next(700) == 0)
                Main.PlaySound(29, (int)npc.position.X, (int)npc.position.Y, Main.rand.Next(81, 84));
            var velocity = AntiarisHelper.VelocityToPoint(npc.Center, AntiarisHelper.RandomPointInArea(new Vector2(player.Center.X - 10, player.Center.Y - 10), new Vector2(player.Center.X + 20, player.Center.Y + 20)), 6);
            if (!player.active || player.dead)
            {
                npc.TargetClosest(false);
                npc.velocity.Y = -10;
                timer = 0;
            }
            ++timer;
            if (timer < 350)
            {
                timer2++;
                if (timer2 >= 10)
                {
                    frame++;
                    timer2 = 0;
                }
                if (frame >= 5)
                {
                    frame = 1;
                }
            }
            if (timer >= 150 && timer < 350)
            {
                Vector2 vector2_1 = player.Center + new Vector2(0.0f, -200.0f);
                float speed = 3f;
                Vector2 vector2_2 = vector2_1 - npc.Center;
                float distance = (float)Math.Sqrt((double)vector2_2.X * (double)vector2_2.X + (double)vector2_2.Y * (double)vector2_2.Y);
                vector2_2 *= speed / distance;
                npc.velocity = vector2_2;
                if (timer > 250)
                {
                    npc.velocity.X = 0.0f;
                    npc.velocity.Y = 13f;
                    if ((double)npc.position.Y < (double)player.position.Y + 150.0)
                    {
                        timer = 350;
                        frame = 5;
                    }
                }
            }
            else if (timer >= 350)
            {
                npc.velocity.X = 0f;
                npc.velocity.Y = 0f;
                timer3++;
                if (timer3 >= 22)
                {
                    frame++;
                    timer3 = 0;
                }
                if (frame >= 11)
                {
                    frame = 5;
                }
                if (timer % 100 == 0 && Main.netMode != 1)
                {
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, velocity.X, velocity.Y, mod.ProjectileType("LeafMagic"), npc.damage, 1f);
                }
            }
            if (timer >= 550)
                timer = 0;
        }

        public override void FindFrame(int frameHeight)
        {
			npc.frame.Y = frameHeight * frame;
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
                int gore = Gore.NewGore(new Vector2(npc.position.X, npc.position.Y - 10f), new Vector2((float)hitDirection, 0f), 99, npc.scale);
                Main.gore[gore].velocity *= 0.3f;
                gore = Gore.NewGore(new Vector2(npc.position.X, npc.position.Y + (float)(npc.height / 2) - 15f), new Vector2((float)hitDirection, 0f), 99, npc.scale);
                Main.gore[gore].velocity *= 0.3f;
                gore = Gore.NewGore(new Vector2(npc.position.X, npc.position.Y + (float)npc.height - 20f), new Vector2((float)hitDirection, 0f), 99, npc.scale);
                Main.gore[gore].velocity *= 0.3f;
            }
        }

        public override void NPCLoot()
        {
            if (Main.netMode != 1)
            {
                int centerX = (int)(npc.position.X + (float)(npc.width / 2)) / 16;
                int centerY = (int)(npc.position.Y + (float)(npc.height / 2)) / 16;
                int halfLength = npc.width / 2 / 16 + 1;
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("NatureEssence"), Main.rand.Next(3,5), false, 0, false, false);
            }
        }
    }
}
