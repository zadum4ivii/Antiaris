using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.NPCs.Enemies
{
    public class BluePetitePixie : ModNPC
    {
        private int frame = 0;
        private double frameCounter = 0.0;

        private float timer = 0.0f;
        public override Color? GetAlpha(Color lightColor) { return Color.White; }

        public override void SetDefaults()
        {
            npc.noGravity = true;
            npc.width = 36;
            npc.height = 30;
            npc.aiStyle = -1;
            npc.damage = 31;
            npc.defense = 11;
            npc.lifeMax = 100;
            npc.HitSound = SoundID.NPCHit5;
            npc.knockBackResist = 0.5f;
            npc.DeathSound = SoundID.NPCDeath7;
            npc.value = (float)Item.buyPrice(0, 0, 1, 0);
            npc.buffImmune[20] = true;
            npc.buffImmune[24] = true;
            npc.buffImmune[39] = true;
            npc.buffImmune[31] = false;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blue Petite Pixie");
            DisplayName.AddTranslation(GameCulture.Russian, "Голубая маленькая пикси");
            DisplayName.AddTranslation(GameCulture.Chinese, "蓝色迷你精灵");
            Main.npcFrameCount[npc.type] = 4;
        }

        public void OverhaulInit()
        {
            this.SetTag("unholyWeakness");
        }

        public override void AI()
        {
            Player player = Main.player[npc.target];
            npc.spriteDirection = (double)npc.velocity.X <= 0.0 ? -1 : 1;
            npc.rotation = npc.velocity.X * 0.1f;
            if (Main.rand.Next(6) == 0)
            {
                int dust = Dust.NewDust(npc.position, npc.width, npc.height, 59, 0.0f, 0.0f, 200, default(Color), 1.0f);
                Main.dust[dust].velocity *= 0.3f;
            }
            if (Main.rand.Next(40) == 0)
                Main.PlaySound(27, (int)npc.position.X, (int)npc.position.Y, 1);
            if (npc.wet)
            {
                npc.velocity.Y -= 0.2f;
                if ((double)npc.velocity.Y < -2.0)
                    npc.velocity.Y = -2.0f;
            }
            float distanceTo = Vector2.Distance(player.Center, npc.Center);
            int ai1 = (int)npc.ai[1];
            ++this.timer;
            if (Main.npc[ai1].active)
            {
                if (Main.npc[ai1].life < Main.npc[ai1].lifeMax && (double)this.timer % 95.0 == 0.0)
                {
                    this.timer = 0.0f;
                    Main.npc[ai1].life += 15;
                    npc.HealEffect(15);
                }
                if (Main.npc[ai1].oldPos[1] != Vector2.Zero && Main.npc[ai1].type == mod.NPCType("BluePixie"))
                {
                    Vector2 vector23 = npc.position + Main.npc[ai1].position - Main.npc[ai1].oldPos[1];
                    npc.position = vector23;
                }
            }
            else
            {
                npc.life = -1; npc.active = false; npc.checkDead();
                for (int k = 0; k < 50; k++)
                {
                    int dust = Dust.NewDust(npc.position, npc.width, npc.height, 59, 0.0f, -2.0f, 0, new Color(), 2.0f);
                    Main.dust[dust].noGravity = true;
                    Dust dust1 = Main.dust[dust];
                    dust1.position.X = dust1.position.X + ((float)(Main.rand.Next(-50, 51) / 20) - 1.5f);
                    Dust dust2 = Main.dust[dust];
                    dust2.position.Y = dust2.position.Y + ((float)(Main.rand.Next(-50, 51) / 20) - 1.5f);
                    if (Main.dust[dust].position != npc.Center) Main.dust[dust].velocity = npc.DirectionTo(Main.dust[dust].position) * 1.0f;
                }
            }
            Vector2 velocity = npc.velocity + new Vector2((float)Math.Sign(Main.npc[ai1].Center.X - npc.Center.X), (float)Math.Sign(Main.npc[ai1].Center.Y - npc.Center.Y)) * new Vector2(0.2f, 0.08f);
            npc.velocity = velocity;
            if ((double)npc.velocity.Length() > 6.0)
            {
                Vector2 zero = npc.velocity * (6.0f / npc.velocity.Length());
                npc.velocity = zero;
            }
            Lighting.AddLight((int)npc.position.X / 16, (int)npc.position.Y / 16, 0.9f, 0.2f, 0.1f);
        }

        public override void FindFrame(int frameHeight)
        {
            this.frameCounter++;
            if (this.frameCounter >= 4.0) { this.frame++; this.frameCounter = 0; }
            if (this.frame >= 4) this.frame = 0;
            npc.frame.Y = this.frame * frameHeight;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life > 0)
            {
                for (int k = 0; k < 10; k++)
                    Dust.NewDust(npc.position, npc.width, npc.height, 59, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
            }
            else
            {
                for (int k = 0; k < 50; k++)
                {
                    int dust = Dust.NewDust(npc.position, npc.width, npc.height, 59, 0.0f, -2.0f, 0, new Color(), 2.0f);
                    Main.dust[dust].noGravity = true;
                    Dust dust1 = Main.dust[dust];
                    dust1.position.X = dust1.position.X + ((float)(Main.rand.Next(-50, 51) / 20) - 1.5f);
                    Dust dust2 = Main.dust[dust];
                    dust2.position.Y = dust2.position.Y + ((float)(Main.rand.Next(-50, 51) / 20) - 1.5f);
                    if (Main.dust[dust].position != npc.Center) Main.dust[dust].velocity = npc.DirectionTo(Main.dust[dust].position) * 1.0f;
                }
            }
        }
    }
}
