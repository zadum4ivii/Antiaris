using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.NPCs.Town
{
    public class BoundPirate : ModNPC
    {
        string HelpText;

        public override void SetDefaults()
        {
            npc.friendly = true;
            npc.townNPC = true;
            npc.dontTakeDamage = true;
            npc.width = 32;
            npc.height = 42;
            npc.aiStyle = 0;
            npc.damage = 10;
            npc.defense = 20;
            npc.lifeMax = 700;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0f;
            npc.rarity = 1;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bound Pirate");
            DisplayName.AddTranslation(GameCulture.Chinese, "被捆绑的船长");
            DisplayName.AddTranslation(GameCulture.Russian, "Связанный пират");
            NPCID.Sets.TownCritter[npc.type] = true;
        }

        public override string GetChat()
        {
            WakeUp();
            string BoundPirate = Language.GetTextValue("Mods.Antiaris.BoundPirate");
            return BoundPirate;
        }

        public override void HitEffect(int hitDirection, double damage)
		{
			npc.life = npc.lifeMax;
		}

        public override bool UsesPartyHat() { return false; }

        public override void AI()
        {
			npc.wet = false;
            npc.lavaWet = false;
            npc.honeyWet = false;
            npc.immune[255] = 30;
            string PirateHelp1 = Language.GetTextValue("Mods.Antiaris.PirateHelp1");
			string PirateHelp1F = Language.GetTextValue("Mods.Antiaris.PirateHelp1F");
			string PirateHelp2 = Language.GetTextValue("Mods.Antiaris.PirateHelp2");
			string PirateHelp3 = Language.GetTextValue("Mods.Antiaris.PirateHelp3");
            var player = Main.player[npc.target];
            if (player.Male)
			{
				switch (Main.rand.Next(0, 3))
				{
					case 0:
						HelpText = PirateHelp1;
						break;
					case 1:
						HelpText = PirateHelp2;
						break;
					case 2:
						HelpText = PirateHelp3;
						break;
				}
			}
			else
			{
				switch (Main.rand.Next(0, 3))
				{
					case 0:
						HelpText = PirateHelp1F;
						break;
					case 1:
						HelpText = PirateHelp2;
						break;
					case 2:
						HelpText = PirateHelp3;
						break;
				}
			}
            if (Main.rand.Next(300) == 0)
            {
                CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), Color.White, HelpText, false, false);
                Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/NPCs/PirateVoice"), npc.position);
            }
            npc.spriteDirection = 1;
            foreach (var player_ in Main.player)
            {
                if (!player_.active) continue;
                if (player_.talkNPC == npc.whoAmI)
                {
                    WakeUp();
                    return;
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
            npc.Transform(mod.NPCType("Pirate"));
        }

        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
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
