using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.NPCs.Town
{
    public class FrozenAdventurer : ModNPC
    {
        private int frame = 0;
        private float timer = 0.0f;

        public override void SetDefaults()
        {
            npc.friendly = true;
            npc.townNPC = true;
            npc.dontTakeDamage = true;
            npc.width = 46;
            npc.height = 26;
            npc.aiStyle = 0;
            npc.damage = 10;
            npc.defense = 15;
            npc.lifeMax = 250;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
            npc.rarity = 1;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frozen Adventurer");
            DisplayName.AddTranslation(GameCulture.Chinese, "被冻住的冒险家");
            DisplayName.AddTranslation(GameCulture.Russian, "Замерзший путешественник");
            NPCID.Sets.TownCritter[npc.type] = true;
            Main.npcFrameCount[npc.type] = 4;
        }

        public override void AI()
        {
            npc.wet = false;
            npc.lavaWet = false;
            npc.honeyWet = false;
            npc.immune[255] = 30;
            npc.direction = npc.spriteDirection = -1;
            if (timer > 0.0f) timer--;
            foreach (var player in Main.player)
            {
                if (!player.active) continue;
                if (player.inventory[player.selectedItem].type == mod.ItemType("SteelShovel"))
                {
                    if (player.itemAnimation > 0 && timer <= 0.0f)
                    {
                        var FirstRectangle = new Rectangle((int)player.itemLocation.X, (int)player.itemLocation.Y, 34, 34);
                        FirstRectangle.Width = (int)((float)FirstRectangle.Width * player.inventory[player.selectedItem].scale);
                        FirstRectangle.Height = (int)((float)FirstRectangle.Height * player.inventory[player.selectedItem].scale);
                        if (player.direction == -1)
                        {
                            FirstRectangle.X -= FirstRectangle.Width;
                        }
                        if (player.gravDir == 1f)
                        {
                            FirstRectangle.Y -= FirstRectangle.Height;
                        }
                        if ((double)player.itemAnimation < (double)player.itemAnimationMax * 0.333)
                        {
                            if (player.direction == -1)
                            {
                                FirstRectangle.X -= (int)((double)FirstRectangle.Width * 1.4 - (double)FirstRectangle.Width);
                            }
                            FirstRectangle.Width = (int)((double)FirstRectangle.Width * 1.4);
                            FirstRectangle.Y += (int)((double)FirstRectangle.Height * 0.5 * (double)player.gravDir);
                            FirstRectangle.Height = (int)((double)FirstRectangle.Height * 1.1);
                        }
                        else if ((double)player.itemAnimation >= (double)player.itemAnimationMax * 0.666)
                        {
                            if (player.direction == 1)
                            {
                                FirstRectangle.X -= (int)((double)FirstRectangle.Width * 1.2);
                            }
                            FirstRectangle.Width *= 2;
                            FirstRectangle.Y -= (int)(((double)FirstRectangle.Height * 1.4 - (double)FirstRectangle.Height) * (double)player.gravDir);
                            FirstRectangle.Height = (int)((double)FirstRectangle.Height * 1.4);
                        }
                        Rectangle SecondRectangle = new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height);
                        if (FirstRectangle.Intersects(SecondRectangle) && (npc.noTileCollide || Collision.CanHit(player.position, player.width, player.height, npc.position, npc.width, npc.height)))
                        {
							if (frame < 3)
							{
								timer = 60.0f;
								Main.PlaySound(2, (int)player.position.X, (int)player.position.Y, 48);
								for (int i = 0; i < 20; i++)
									Dust.NewDust(npc.position + new Vector2(6.0f, 0.0f), npc.width, npc.height, 212, (i - 20) * 0.1f, -1.5f);
								if (frame < 3) frame += 1;
							}
                        }
                    }
                }
            }
            if (Main.netMode != 1)
            {
                npc.homeless = false;
                npc.homeTileX = -1;
                npc.homeTileY = -1;
                npc.netUpdate = true;
            }
        }

        public void WakeUp()
        {
            npc.dontTakeDamage = false;
			AntiarisWorld.savedAdventurer = true;
            npc.Transform(mod.NPCType("Adventurer"));
        }

        public override string GetChat()
        {
			string FrozenAdventurer1 = Language.GetTextValue("Mods.Antiaris.FrozenAdventurer1");
			string FrozenAdventurer2 = Language.GetTextValue("Mods.Antiaris.FrozenAdventurer2");
            if (frame == 3)
            {
                WakeUp();
                return FrozenAdventurer2;
            }
            return FrozenAdventurer1;
        }

        public override void FindFrame(int frameHeight)
        {
            npc.frame.Y = frameHeight * frame;
        }

        public override bool UsesPartyHat() { return false; }

        public override void HitEffect(int hitDirection, double damage)
        {
			npc.life = npc.lifeMax;
            if (npc.life <= 0)
            {
                for (int k = 0; k < 20; k++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
                }
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/AdventurerGore1"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/AdventurerGore2"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/AdventurerGore3"), 1f);
            }
        }

        public override void NPCLoot()
        {
            AntiarisWorld.savedAdventurer = true;
            if (Main.netMode != 1)
            {
                int centerX = (int)(npc.position.X + (float)(npc.width / 2)) / 16;
                int centerY = (int)(npc.position.Y + (float)(npc.height / 2)) / 16;
                int halfLength = npc.width / 2 / 16 + 1;
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AdventurerHat"), 1, false, 0, false, false);
            }
        }

        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            if (frame != 3) return;
            Texture2D texture = mod.GetTexture("Miscellaneous/QuestIcon2");
            if (texture == null) return;
            SpriteEffects effects = npc.spriteDirection == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            Vector2 origin = new Vector2(texture.Width / 2, texture.Height / 2);
            float y = 50.0f;
            Vector2 position = npc.Center - Main.screenPosition - new Vector2(0.0f, y);
            spriteBatch.Draw(texture, position, null, Color.White, npc.rotation, origin, npc.scale, effects, 0.0f);
        }
    }
}
