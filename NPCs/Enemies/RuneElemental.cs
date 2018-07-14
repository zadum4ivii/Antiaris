using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.NPCs.Enemies
{
    public class RuneElemental : ModNPC
    {
        public override void SetDefaults()
        {
            npc.lifeMax = 120;
            npc.damage = 12;
            npc.defense = 6;
            npc.knockBackResist = 0.2f;
            npc.width = 32;
            npc.height = 54;
            npc.aiStyle = -1;
            animationType = 48;
            npc.npcSlots = 0.5f;
            npc.HitSound = SoundID.NPCHit52;
            npc.noGravity = true;
            npc.buffImmune[31] = false;
            npc.noTileCollide = true;
            npc.DeathSound = SoundID.NPCDeath6;
			npc.value = Item.buyPrice(0, 0, 5, 0);
			banner = npc.type;
            bannerItem = mod.ItemType("RuneElementalBanner");
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rune Elemental");
            DisplayName.AddTranslation(GameCulture.Chinese, "符文元素");
            DisplayName.AddTranslation(GameCulture.Russian, "Рунный элементаль");
            Main.npcFrameCount[npc.type] = 4;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 1);
            npc.damage = (int)(npc.damage * 1);
        }

        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            var GlowMask = mod.GetTexture("Glow/RuneElemental_GlowMask");
            var Effects = npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            spriteBatch.Draw(GlowMask, npc.Center - Main.screenPosition + new Vector2(0, npc.gfxOffY), npc.frame,
            Color.White, npc.rotation, npc.frame.Size() / 2, npc.scale, Effects, 0);
        }

        public override void AI()
        {
            npc.TargetClosest(true);
            Vector2 vector2 = new Vector2(npc.Center.X, npc.Center.Y);
            float x = Main.player[npc.target].Center.X - vector2.X;
            float y = Main.player[npc.target].Center.Y - vector2.Y;
            float distance = 6f / (float)Math.Sqrt((double)x * (double)x + (double)y * (double)y);
            float velocityX = x * distance;
            float velocityY = y * distance;
            npc.velocity.X = (float)(((double)npc.velocity.X * 100.0 + (double)velocityX) / 101.0);
            npc.velocity.Y = (float)(((double)npc.velocity.Y * 100.0 + (double)velocityY) / 101.0);
            npc.rotation = (float)Math.Atan2((double)velocityY, (double)velocityX) - 1.57f;
        }

        public override void NPCLoot()
        {
            if (Main.netMode != 1)
            {
                int centerX = (int)(npc.position.X + (float)(npc.width / 2)) / 16;
                int centerY = (int)(npc.position.Y + (float)(npc.height / 2)) / 16;
                int halfLength = npc.width / 2 / 16 + 1;
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("RuneStone"), Main.rand.Next(7,10), false, 0, false, false);
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            int x = spawnInfo.spawnTileX;
            int y = spawnInfo.spawnTileY;
            int tile = (int)Main.tile[x, y].type;
            return (Antiaris.NoZoneAllowWater(spawnInfo)) && !spawnInfo.player.ZoneDungeon && !spawnInfo.player.ZoneJungle && y > Main.rockLayer ? 0.01f : 0f;
        }
    }
}