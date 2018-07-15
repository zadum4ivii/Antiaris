using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.NPCs.Miscellaneous
{
    public class Ghost : ModNPC
    {
        private int timer = 0;

        public override void SetDefaults()
        {
            npc.friendly = true;
			npc.dontTakeDamage = true;
            npc.width = 30;
            npc.height = 40;
            npc.aiStyle = 0;
            npc.damage = 0;
            npc.defense = 99999;
            npc.lifeMax = 5000;
            npc.knockBackResist = 0f;
			npc.noTileCollide = true;
			animationType = 238;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ghost");
            DisplayName.AddTranslation(GameCulture.Chinese, "灵魂");
            DisplayName.AddTranslation(GameCulture.Russian, "Призрак");
			Main.npcFrameCount[npc.type] = 4;
        }

        public override void AI()
        {
            npc.dontTakeDamage = true;
			npc.velocity.X = 0f;
			npc.velocity.Y = -2f;
			npc.spriteDirection = -npc.direction;
			if (Main.player[(int)npc.ai[0]].statLife > 0)
				++timer;
			if ((double)timer >= 180.0)
			{
				npc.life = 0;
				npc.HitEffect(0, 10.0);
				npc.active = false;
				Gore.NewGore(npc.position, npc.velocity, 11);
				Gore.NewGore(npc.position, npc.velocity, 12);
				Gore.NewGore(npc.position, npc.velocity, 13);
				if (Main.netMode != 1)
					NetMessage.SendData(23, -1, -1, null, npc.whoAmI, 0.0f, 0.0f, 0.0f, 0, 0, 0);
			}
        }
    }
}
