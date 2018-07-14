using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.NPCs.Enemies
{
    public class TreacherousSphere : ModNPC
    {
        private float aiTimer = 0.0f;

        private bool charged = false;
        private int chargedTimer = 0;

        private int frame = 0;
        private double frameCounter = 0.0;
        private float scaleTimer = 0.2f;
        public override Color? GetAlpha(Color lightColor) { return Color.White; }

        public override void SetDefaults()
        {
            npc.lifeMax = 10;
            npc.damage = 29;
            npc.defense = 0;
            npc.knockBackResist = 0.0f;
            npc.aiStyle = 0;
            npc.dontTakeDamage = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.scale = 1.0f;
            npc.width = 48;
            npc.height = 46;
            for (int k = 0; k < npc.buffImmune.Length; ++k)
                npc.buffImmune[k] = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Treacherous Sphere");
            DisplayName.AddTranslation(GameCulture.Russian, "Коварная сфера");
			DisplayName.AddTranslation(GameCulture.Chinese, "千瞬光球");
            Main.npcFrameCount[npc.type] = 4;
        }

        public override void AI()
        {
            if (this.charged) ++this.chargedTimer;
            ++this.aiTimer;
            if ((double)this.aiTimer >= 5.0) this.aiTimer = 0.0f;
            if ((double)this.chargedTimer > 0.0)
            {
                if ((double)this.aiTimer <= 1.0)
                    Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 75);
            }
            npc.netUpdate = true;
            NPC owner = Main.npc[(int)npc.ai[0]];
            npc.position.X = owner.Center.X - npc.width / 2;
            npc.position.Y = owner.Center.Y - 70.0f;
            Player player = Main.player[owner.target];
            if (!owner.active)
                npc.active = false;
            if ((double)this.chargedTimer % 7.0 == 1.0 && (double)this.chargedTimer <= 125.0)
                NPC.NewNPC((int)((player.position.X - 500) + Main.rand.Next(1000)), (int)((player.position.Y - 500) + Main.rand.Next(1000)), mod.NPCType("TreacherousEnergy"), 0, 0.0f, 0.0f, 0.0f, 0.0f, 255);
            if ((double)this.chargedTimer >= 125.0) this.Kill();
            if ((double)this.scaleTimer < 1.0 && !this.charged) this.scaleTimer += 0.003f;
            if (this.scaleTimer >= 1.0f) this.charged = true;
            if (this.charged)
                npc.scale -= 0.007f;
            if ((double)Vector2.Distance(npc.Center, owner.Center) < 30.0) this.Kill();
            if (!owner.active || (player.dead || !player.active))
            {
                for (int j = 0; j < 13; j++)
                {
                    int dust = Dust.NewDust(npc.position, npc.width, npc.height, DustID.GoldFlame, 0.0f, 0.0f, 100, new Color(), 1f);
                    Main.dust[dust].noGravity = true;
                }
                this.Kill();
            }
            npc.netUpdate = true;
        }

        public override void FindFrame(int frameHeight)
        {
            this.frameCounter++;
            if (this.frameCounter >= 6.0) { this.frame++; this.frameCounter = 0; }
            if (this.frame >= 4) this.frame = 0;
            npc.frame.Y = this.frame * frameHeight;
        }

        public void Kill()
        {
            for (int k = 0; k < 13; k++)
            {
                int dust = Dust.NewDust(npc.position, npc.width, npc.height, DustID.GoldFlame, 0.0f, 0.0f, 100, new Color(), 1.0f);
                Main.dust[dust].noGravity = true;
                Vector2 velocity = npc.velocity;
                Main.dust[dust].velocity = velocity.RotatedBy((double)(15 * (k + 2)), new Vector2());
            }
            npc.life = -1; npc.active = false; npc.checkDead();
        }
    }
}
