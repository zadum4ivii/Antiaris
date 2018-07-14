using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.NPCs.Enemies
{
    public class SporeCarrier : ModNPC
    {
        private int timer = 0;

        public override void SetDefaults()
        {
            npc.lifeMax = 85;
            npc.damage = 22;
            npc.defense = 7;
            npc.knockBackResist = 0.5f;
            npc.width = 34;
            npc.height = 48;
            animationType = 3;
            npc.aiStyle = 3;
			aiType = 73;
            npc.npcSlots = 0.8f;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.DD2_SkeletonDeath;
            npc.value = Item.buyPrice(0, 0, 2, 0);
			banner = npc.type;
            bannerItem = mod.ItemType("SporeCarrierBanner");
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spore Carrier");
            DisplayName.AddTranslation(GameCulture.Chinese, "孢子带菌者");
            DisplayName.AddTranslation(GameCulture.Russian, "Носитель спор");
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

        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            var GlowMask = mod.GetTexture("Glow/SporeCarrier_GlowMask");
            var Effects = npc.direction == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            spriteBatch.Draw(GlowMask, npc.Center - Main.screenPosition + new Vector2(0, npc.gfxOffY), npc.frame, Color.White, npc.rotation, npc.frame.Size() / 2, npc.scale, Effects, 0);
        }

        public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 44, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SporeCarrierGore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SporeCarrierGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SporeCarrierGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SporeCarrierGore3"), 1f);
			}
		}

        public override void AI()
        {
            npc.TargetClosest(true);
            npc.netUpdate = true;
            this.timer++;
			if(timer == 120 && Main.netMode != 1)
			{
				timer = 0;
				int ProjectileAmount = 6;
				if(Main.expertMode)
				{
					ProjectileAmount = 8;
				}
                for (int i = 0; i < ProjectileAmount; i++)
                {
                    Vector2 value17 = new Vector2((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
                    value17.Normalize();
                    value17 *= (float)Main.rand.Next(200, 500) * 0.01f;
                    int a = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, value17.X, value17.Y, 228, 1, 1f);
					Main.projectile[a].friendly = false;
					Main.projectile[a].hostile = true;
					Main.projectile[a].damage = 10;
                }
			}
        }

        public override void NPCLoot()
        {
            if (Main.netMode != 1)
            {
                int centerX = (int)(npc.position.X + (float)(npc.width / 2)) / 16;
                int centerY = (int)(npc.position.Y + (float)(npc.height / 2)) / 16;
                int halfLength = npc.width / 2 / 16 + 1;
				if (Main.rand.Next(20) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("RavenousSpores"), 1, false, 0, false, false);
				}
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.JungleSpores, Main.rand.Next(3, 5), false, 0, false, false);
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            int x = spawnInfo.spawnTileX;
            int y = spawnInfo.spawnTileY;
            int tile = (int)Main.tile[x, y].type;
            return (Antiaris.NormalSpawn(spawnInfo) && NPC.downedBoss2 && Antiaris.NoZoneAllowWater(spawnInfo)) && spawnInfo.player.ZoneJungle && y < Main.worldSurface ? 0.02f : 0f;
        }
    }
}