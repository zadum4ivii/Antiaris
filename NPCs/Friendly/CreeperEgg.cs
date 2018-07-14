using Antiaris.NPCs.Town;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.NPCs.Friendly
{
    public class CreeperEgg : ModNPC
    {
        private int timer = 0;

        public override void SetDefaults()
        {
            npc.friendly = false;
            npc.width = 30;
            npc.height = 30;
            npc.aiStyle = 0;
            npc.damage = 0;
            npc.defense = 0;
            npc.lifeMax = 1;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0f;
            npc.rarity = 1;
			npc.noTileCollide = false;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Creeper Egg");
            DisplayName.AddTranslation(GameCulture.Chinese, "爬行者之卵");
            DisplayName.AddTranslation(GameCulture.Russian, "Яйцо паука");
        }

        public override void AI()
        {
		    npc.velocity.X = 0f;
            npc.velocity.Y = 5f;
            timer++;
            if (timer >= 450)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CreeperEggGore1"));
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CreeperEggGore1"));
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CreeperEggGore2"));
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CreeperEggGore3"));
				npc.Transform(mod.NPCType("BabyCreeperGround"));
            }
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CreeperEggGore1"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CreeperEggGore1"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CreeperEggGore2"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CreeperEggGore3"), 1f);
				NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("BabyCreeperGround"), 0, (float)npc.whoAmI, npc.Center.X, npc.Center.Y, 0.0f, (int)byte.MaxValue);
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            var questSystem = spawnInfo.player.GetModPlayer<QuestSystem>(mod);
            return spawnInfo.spiderCave ? 0.09f : 0f;
        }
    }
}
