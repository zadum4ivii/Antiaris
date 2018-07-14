using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.NPCs.Miscellaneous
{
    public class BrokenMirror : ModNPC
    {
        public static bool kill = false;
        private bool startRitual = true;

        public override void SetDefaults()
        {
            npc.friendly = true;
            npc.townNPC = true;
            npc.dontTakeDamage = true;
			npc.noGravity = true;
            npc.width = 48;
            npc.height = 54;
            npc.damage = 10;
            npc.defense = 15;
            npc.lifeMax = 250;
			npc.aiStyle = 0;
            npc.knockBackResist = 0f;
            npc.rarity = 1;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Broken Mirror");
            DisplayName.AddTranslation(GameCulture.Chinese, "破碎的魔镜");
            DisplayName.AddTranslation(GameCulture.Russian, "Разбитое зеркало");
            NPCID.Sets.TownCritter[npc.type] = true;
        }

        public override bool UsesPartyHat() { return false; }

        public override void AI()
        {
			npc.wet = false;
            npc.lavaWet = false;
            npc.honeyWet = false;
			npc.velocity.X = npc.velocity.Y = 0f;
            npc.dontTakeDamage = true;
            npc.immune[255] = 30;
            if (WorldGen.crimson)
			{
				Main.npcTexture[npc.type] = ModLoader.GetTexture("Antiaris/NPCs/Miscellaneous/BrokenMirror2");
			}
			else
			{
				Main.npcTexture[npc.type] = ModLoader.GetTexture("Antiaris/NPCs/Miscellaneous/BrokenMirror");
			}				
            if (Main.npc[(int)npc.ai[2]].active && Main.npc[(int)npc.ai[2]].type == mod.NPCType("TowerKeeperNonActive"))
				this.startRitual = false;
			if (AntiarisWorld.DownedTowerKeeper)
			{
				this.startRitual = false;
			}
			foreach (var golem in Main.npc)
			if (!golem.active && (golem.type == mod.NPCType("TowerKeeperNonActive") || golem.type == mod.NPCType("TowerKeeper") || golem.type == mod.NPCType("TowerKeeper2")) && !AntiarisWorld.DownedTowerKeeper)
			{
				npc.Transform(mod.NPCType("Mirror"));
			}
			if (startRitual)
			{
				npc.ai[0] = -1f;
				npc.ai[1] = 0.0f;
				int x = (int)npc.Center.X / 16 + 2;
				int y = (int)npc.Center.Y / 16 - 15;
				int boss = NPC.NewNPC(x * 16 + 10, y * 16 - 2, mod.NPCType("TowerKeeperNonActive"), 0, 0.0f, 0.0f, 0.0f, 0.0f, 255);
				npc.ai[2] = (float)boss;
				npc.netUpdate = true;
				startRitual = false;
			}
			if (!startRitual && !AntiarisWorld.DownedTowerKeeper)
			{
				if (Main.npc[(int)npc.ai[2]].alpha == 0)
					++npc.ai[3];
				if ((double)npc.ai[3] % 3.0 == 1.0 && (double)npc.ai[3] >= 200.0 && (double)npc.ai[3] < 300.0 && Main.netMode != 1)
				{
					float speed = (float)(3.0 + (double)Main.rand.NextFloat() * 6.0);
					Vector2 start = Vector2.UnitY.RotatedByRandom(6.28318548202515);
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, start.X * speed, start.Y * speed, mod.ProjectileType("Energy"), 0, 0.0f, Main.myPlayer, Main.npc[(int)npc.ai[2]].Center.X, Main.npc[(int)npc.ai[2]].Center.Y - 5f);
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
			string Mirror3 = Language.GetTextValue("Mods.Antiaris.Mirror3"); 
			return Mirror3;
        }
    }
}

