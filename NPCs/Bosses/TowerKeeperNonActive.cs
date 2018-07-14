using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.NPCs.Bosses
{
    public class TowerKeeperNonActive : ModNPC
    {
        private double counting;

        private int frame;
        private double timerToVisible = 0.0;

        public override void SetDefaults()
        {
            npc.lifeMax = 20;
            npc.damage = 21;
            npc.defense = 15;
            npc.knockBackResist = 0f;
            npc.width = 204;
            npc.height = 160;
            npc.npcSlots = 5f;
            npc.HitSound = SoundID.NPCHit41;
            npc.noGravity = true;
			npc.dontTakeDamage = true;
			npc.alpha = 255;
            npc.DeathSound = SoundID.NPCDeath44;
            npc.value = Item.buyPrice(0, 0, 45, 0);
            npc.noTileCollide = true;
			Main.npcFrameCount[npc.type] = 6;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 1);
            npc.damage = (int)(npc.damage * 1);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tower Keeper");
            DisplayName.AddTranslation(GameCulture.Chinese, "守塔魔像");
            DisplayName.AddTranslation(GameCulture.Russian, "Хранитель башни");
        }

        public void OverhaulInit()
        {
            this.SetTag("boss");
            this.SetTag("fireResistance");
            this.SetTag("noStuns");
        }

        public override void AI()
        {
            npc.dontTakeDamage = true;
            npc.immune[255] = 30;
            Player player = Main.player[npc.target];
			Vector2 target = npc.HasPlayerTarget ? player.Center : Main.npc[npc.target].Center;
			npc.netAlways = true;
            npc.rotation = 0.0f;
            this.frame = 1;
			++this.timerToVisible;		
			Main.musicFade[Main.curMusic] = 1f / (float)(this.timerToVisible / 75 * 0.5f);
            if (npc.alpha > 0 && (double)this.timerToVisible >= 300.0)
			{
				npc.alpha -= (int)1.5;
				this.timerToVisible = 300.0;
				npc.netUpdate = true;
			}
			if ((double)this.timerToVisible == 299.0)
				Main.PlaySound(mod.GetLegacySoundSlot(Terraria.ModLoader.SoundType.Custom, "Sounds/NPCs/TowerKeeperSpawn"), npc.position);
			if (npc.alpha == 0)
			{
				++npc.ai[0];
				if ((double)npc.ai[0] >= 0.0 && (double)npc.ai[0] < 150.0)
				{
					this.frame = 1;
					npc.netUpdate = true;
				}
				else if ((double)npc.ai[0] >= 150.0 && (double)npc.ai[0] < 200)
				{
					this.frame = 0;
					npc.velocity.Y -= 0.03f;
					if ((double)npc.ai[0] == 175.0)
						Main.PlaySound(mod.GetLegacySoundSlot(Terraria.ModLoader.SoundType.Custom, "Sounds/NPCs/TowerKeeperLaugh"), npc.position);
					npc.netUpdate = true;
				}
				else if ((double)npc.ai[0] >= 200.0 && (double)npc.ai[0] < 300.0)
				{
					this.frame = 2;
					npc.velocity.X = npc.velocity.Y = 0f;
					npc.netUpdate = true;
				}
				else
				{
					if (WorldGen.crimson) npc.Transform(mod.NPCType("TowerKeeper"));
					else npc.Transform(mod.NPCType("TowerKeeper2"));
					npc.netUpdate = true;
				}
				if ((double)npc.ai[0] >= 175.0)
					Main.musicFade[Main.curMusic] = 0.2f;
			}
        }

        public override void FindFrame(int frameHeight)
		{
			if (this.frame == 0)
			{
				counting += 1.0;
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
                else
                {
                    counting = 0.0;
                }
			}
			else if (this.frame == 1)
				 npc.frame.Y = frameHeight * 4;
			else
				npc.frame.Y = frameHeight * 5;
		}
    }
}
