using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;
using Antiaris.NPCs.Town;

namespace Antiaris.NPCs.Enemies
{
    public class BabyCreeperGround : ModNPC
    {
        public override void SetDefaults()
        {
            npc.lifeMax = 50;
            npc.damage = 12;
            npc.defense = 6;
            npc.knockBackResist = 0f;
            npc.width = 34;
            npc.height = 36;
            npc.aiStyle = 1;
            npc.npcSlots = 0.5f;
            npc.HitSound = SoundID.NPCHit1;
            npc.noGravity = false;
            npc.buffImmune[20] = true;
            npc.buffImmune[70] = true;
            npc.npcSlots = 2f;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = Item.buyPrice(0, 0, 1, 15);
            animationType = 1;
            npc.rarity = 1;
            banner = npc.type;
            bannerItem = mod.ItemType("BabyCreeperBanner");
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Baby Creeper");
            DisplayName.AddTranslation(GameCulture.Chinese, "爬行者幼体");
            DisplayName.AddTranslation(GameCulture.Russian, "Маленький паучок");
            Main.npcFrameCount[npc.type] = 2;
        }

        public void OverhaulInit()
        {
            this.SetTag("waterResistance");
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 1);
            npc.damage = (int)(npc.damage * 1);
        }

        public override void NPCLoot()
        {
            if (Main.netMode != 1)
            {
                int playerIndex = npc.lastInteraction;
				if (!Main.player[playerIndex].active || Main.player[playerIndex].dead)
				{
					playerIndex = npc.FindClosestPlayer();
				}
				Player player = Main.player[playerIndex];
                int centerX = (int)(npc.position.X + (float)(npc.width / 2)) / 16;
                int centerY = (int)(npc.position.Y + (float)(npc.height / 2)) / 16;
                int halfLength = npc.width / 2 / 16 + 1;
                var questSystem = Main.player[playerIndex].GetModPlayer<QuestSystem>(mod);
				int number = 0;
				if (questSystem.currentQuest == QuestItemID.SpiderMass)
				{
					number = Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SpiderMass"), Main.rand.Next(2, 4), false, 0, false, false);
					if (Main.netMode == 1 && number >= 0)
						NetMessage.SendData(21, -1, -1, null, number, 1f, 0.0f, 0.0f, 0, 0, 0);
				}
            }
        }

        public override void AI()
        {
            //vanilla code
            npc.TargetClosest(true);
            Player player = Main.player[npc.target];
            if ((double)player.position.X > (double)npc.position.X)
                npc.spriteDirection = 1;
            else if ((double)player.position.X < (double)npc.position.X)
                npc.spriteDirection = -1;
            int num1 = (int)npc.Center.X / 16;
            int num2 = (int)npc.Center.Y / 16;
            bool flag = false;
            for (int index1 = num1 - 1; index1 <= num1 + 1; ++index1)
            {
                for (int index2 = num2 - 1; index2 <= num2 + 1; ++index2)
                {
                    if (Main.tile[index1, index2] == null)
                        return;
                    if ((int)Main.tile[index1, index2].wall > 0)
                        flag = true;
                }
            }
            if (!flag)
                return;
            npc.Transform(mod.NPCType("BabyCreeper"));
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                for (var i = 0; i < 20; ++i)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, 53, 2.5f * (float)hitDirection, -2.5f, 0, new Color(), 1f);
                }
            }
            else
            {
                for (var i = 0; (double)i < damage / (double)npc.lifeMax * 50.0; ++i)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, 53, (float)hitDirection, -1f, 0, new Color(), 0.8f);
                }
            }
        }
    }
}
