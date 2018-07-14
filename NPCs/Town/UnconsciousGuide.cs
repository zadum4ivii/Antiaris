using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.NPCs.Town
{
    public class UnconsciousGuide : ModNPC
    {
        public override void SetDefaults()
        {
            npc.friendly = true;
            npc.townNPC = true;
            npc.dontTakeDamage = true;
            npc.width = 54;
            npc.height = 22;
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
            DisplayName.SetDefault("Unconscious Guide");
            DisplayName.AddTranslation(GameCulture.Chinese, "昏厥的向导");
            DisplayName.AddTranslation(GameCulture.Russian, "Гид без сознания");
        }

        public override bool UsesPartyHat() { return false; }

        public override void AI()
        {
			npc.wet = false;
            npc.lavaWet = false;
            npc.honeyWet = false;
            npc.spriteDirection = 0;
            foreach (var player in Main.player)
            {
                if (!player.active) continue;
                if (player.talkNPC == npc.whoAmI)
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

        public override string GetChat()
        {
            WakeUp();
            string Guide = Language.GetTextValue("Mods.Antiaris.UnconsciousGuide", Main.LocalPlayer.name);
            return Guide;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
			npc.life = npc.lifeMax;
            if (npc.life <= 0)
            {
                for (int k = 0; k < 20; k++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * (float)hitDirection, -2.5f, 0, default(Color), 0.7f);
                }
                Gore.NewGore(npc.position, npc.velocity, 73, 1f);
                Gore.NewGore(npc.position, npc.velocity, 74, 1f);
                Gore.NewGore(npc.position, npc.velocity, 75, 1f);
            }
        }

        public void WakeUp()
        {
            npc.dontTakeDamage = false;
            npc.Transform(22);
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
