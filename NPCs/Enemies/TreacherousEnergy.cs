using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.NPCs.Enemies
{
    public class TreacherousEnergy : ModNPC
    {
        public override Color? GetAlpha(Color lightColor) { return Color.White; }

        public override void SetDefaults()
        {
            npc.lifeMax = 35;
            npc.damage = 30;
            npc.defense = 0;
            npc.knockBackResist = 0.0f;
            npc.aiStyle = 0;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit3;
            npc.DeathSound = SoundID.NPCDeath56;
            npc.alpha = 244;
            npc.scale = 1.0f;
            npc.width = 18;
            npc.height = 18;
            for (int k = 0; k < npc.buffImmune.Length; ++k)
                npc.buffImmune[k] = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Treacherous Energy");
            DisplayName.AddTranslation(GameCulture.Russian, "Коварная энергия");
			DisplayName.AddTranslation(GameCulture.Chinese, "千瞬能量");
        }

        public override void AI()
        {
            if ((double)npc.ai[0] == 0.0)
            {
                npc.ai[1] = Main.rand.NextBool() ? -Main.rand.Next(1, 11) : Main.rand.Next(1, 11);
                npc.ai[0] = 1f;
            }
            else if ((double)npc.ai[0] == 1.0)
            {
                if (npc.scale < 1.0f) npc.scale += 0.75f / 105;
                else npc.scale = 1.0f;
                if ((double)(npc.alpha -= 4) <= 0.0)
                {
                    if (++npc.ai[1] >= 120)
                    {
                        npc.scale = 1.0f;
                        npc.ai[0] = 2.0f;
                    }
                    npc.alpha = 0;
                }
            }
            else if ((double)npc.ai[0] == 2.0) 
            {
                npc.scale -= 0.75f / 105;
                if ((npc.alpha += 4) >= 255) this.Kill();
            }
            npc.velocity *= Vector2.Zero;
            npc.rotation += (npc.ai[1] * 0.05f) / npc.Opacity;
            npc.netUpdate = true;
        }

        private void Kill()
        {
            for (int k = 0; k < 16; k++)
            {
                int dust = Dust.NewDust(npc.position, npc.width, npc.height, DustID.GoldFlame, 0.0f, 0.0f, 100, new Color(), 1f);
                Main.dust[dust].noGravity = true;
                Vector2 velocity = npc.velocity;
                Main.dust[dust].velocity = velocity.RotatedBy((double)(15 * (k + 2)), new Vector2());
            }
            npc.life = -1; npc.active = false; npc.checkDead();
        }
    }
}

