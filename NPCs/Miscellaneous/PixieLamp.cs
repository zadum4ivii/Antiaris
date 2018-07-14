using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.NPCs.Miscellaneous
{
    public class PixieLamp : ModNPC
    {
        private int frame = 0;
        private double frameCounter = 0.0;

        public override void SetDefaults()
        {
			npc.lifeMax = 100;
            npc.friendly = true;
            npc.dontTakeDamage = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.townNPC = true;
            npc.width = 48;
            npc.height = 62;
            npc.aiStyle = 94;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pixie Lamp");
			DisplayName.AddTranslation(GameCulture.Chinese, "精灵灯");
            DisplayName.AddTranslation(GameCulture.Russian, "Лампа пикси");
            NPCID.Sets.TownCritter[npc.type] = true;
            Main.npcFrameCount[npc.type] = 8;
        }

        public override void AI()
		{
			npc.wet = false;
            npc.lavaWet = false;
            npc.honeyWet = false;
            npc.spriteDirection = 1;
            Vector2 dustPos = new Vector2(npc.spriteDirection == -1 ? -6.0f : -3.0f, -20.0f).RotatedBy((double)npc.rotation, new Vector2());
            if (Main.rand.Next(24) == 0)
            {
                Dust dust = Dust.NewDustDirect(npc.Center + dustPos, 4, 4, 90, 0.0f, 0.0f, 100, new Color(), 1.0f);
                if (Main.rand.NextBool(1, 3))
                {
                    dust.noGravity = true;
                    dust.velocity.Y -= 3.0f;
                }
                dust.velocity *= 0.5f;
                dust.velocity.Y -= 0.9f;
                dust.scale += (float)(0.1 + (double)Main.rand.NextFloat() * 0.6);
            }
            npc.wet = false;
            npc.lavaWet = false;
            npc.honeyWet = false;
            npc.immune[255] = 30;
            for (int k = 0; k < 2; k++) Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0.0f, 0.0f, mod.ProjectileType("PixieLampEffect"), 0, 0.0f, 0, (float)k, (float)npc.whoAmI);
            Lighting.AddLight((int)npc.position.X / 16, (int)npc.position.Y / 16, 0.9f, 0.2f, 0.1f);
            if (Main.netMode != 1) { npc.homeless = false; npc.homeTileX = -1; npc.homeTileY = -1; npc.netUpdate = true; }
        }

        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor) { AntiarisUtils.DrawNPCGlowMask(spriteBatch, mod.GetTexture("Glow/" + GetType().Name + "_GlowMask"), npc, Color.White, 0.0f, 1f); }
        public override bool UsesPartyHat() { return false; }

        public override void FindFrame(int frameHeight)
        {
            this.frameCounter++;
            if (this.frameCounter >= 6.0) { this.frame++; this.frameCounter = 0; }
            if (this.frame >= 8) this.frame = 0;
            npc.frame.Y = this.frame * frameHeight;
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            string collect = Language.GetTextValue("Mods.Antiaris.PixieLampCollect");
            button = collect;
        }

        public override string GetChat()
        {
            string chat = Language.GetTextValue("Mods.Antiaris.PixieLamp");
            return chat;
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                npc.checkDead(); npc.townNPC = false; npc.life = -1; npc.active = false;
                npc.HitEffect(0, 10.0);
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PixieLamp"), 1, false, 0, false, false);
            }
        }
    }
}

