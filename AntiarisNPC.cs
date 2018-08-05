using System.Linq;
using Antiaris.NPCs.Town;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Antiaris
{
    public class AntiarisNPC : GlobalNPC
    {
        internal static readonly int[] Slimes =
        {
            1,
            16,
            59,
            71,
            81,
            138,
            121,
            122,
            141,
            147,
            183,
            184,
            204,
            225,
            244,
            302,
            333,
            335,
            334,
            336,
            537
        };

        public bool deceleration = false;
        public bool despairingFlamesB = false;
        public bool electrified = false;
        public bool lRage = false;

        private Rectangle NpcFrame;

        public bool splinter = false;

        public override bool InstancePerEntity
		{
			get
			{
				return true;
			}
		}

        public override void ResetEffects(NPC npc)
		{
			splinter = false;
			despairingFlamesB = false;
			electrified = false;
			lRage = false;
			deceleration = false;
		} 

        public override void UpdateLifeRegen(NPC npc, ref int damage)
		{
			if (despairingFlamesB)
			{
				if (npc.lifeRegen > 0) npc.lifeRegen = 0;
			    npc.lifeRegen -= 16;
				npc.velocity /= 1.2f;
			}
			if (electrified)
			{
				Lighting.AddLight((int)npc.Center.X / 16, (int)npc.Center.Y / 16, 0.3f, 0.8f, 1.1f);
				if (npc.lifeRegen > 0) npc.lifeRegen = 0;
				npc.lifeRegen -= 8;
			}
			if (lRage)
			{
				if (npc.lifeRegen > 0) npc.lifeRegen = 0;
				npc.lifeRegen -= 40;
			}
		}

        public override void DrawEffects(NPC npc, ref Color drawColor)
		{
			if (despairingFlamesB)
			    for (var i = 0; i < 2; i++)
			    {
			        var dust = Dust.NewDust(npc.position, npc.width, npc.height, 64, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, Color.White, 1.5f);
			        Main.dust[dust].noGravity = true;
			        Main.dust[dust].velocity.Y -= 2f;
			        if (Main.rand.Next(4) == 0)
			        {
			            Main.dust[dust].noGravity = false;
			            Main.dust[dust].scale *= 0.5f;
			        }
			    }

		    if (electrified)
		        if (Main.rand.NextBool(1, 3))
		        {
		            var dust = Dust.NewDust(new Vector2(npc.position.X - 2f, npc.position.Y - 2f), npc.width + 4, npc.height + 4, 226, 0.0f, 0.0f, 100, new Color(), 0.5f);
		            Main.dust[dust].velocity *= 1.6f;
		            --Main.dust[dust].velocity.Y;
		            Main.dust[dust].position = Vector2.Lerp(Main.dust[dust].position, npc.Center, 0.5f);
		        }

		    if (deceleration)
		        for (var k = 0; k < 2; k++)
		            if (Main.rand.NextBool(1, 3))
		            {
		                var dust = Dust.NewDust(npc.position, npc.width, npc.height, 29, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 1.5f);
		                Main.dust[dust].noGravity = true;
		                Main.dust[dust].velocity.Y += 2f;
		            }
		}

        public override void PostDraw(NPC npc, SpriteBatch spriteBatch, Color drawColor)
        {
            var texture = mod.GetTexture("Miscellaneous/QuestIcon");
            if (texture == null) return;
            var questSystem = Main.player[Main.myPlayer].GetModPlayer<QuestSystem>();
            if (questSystem.currentQuest >= 0 && questSystem.currentQuest != -1 && questSystem.GetCurrentQuest() is KillQuest)
                foreach (var i in (questSystem.GetCurrentQuest() as KillQuest).TargetType)
                    if (npc.type == i)
                    {
                        var effects = npc.spriteDirection == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
                        var origin = new Vector2(texture.Width / 2, texture.Height / 2);
                        var y = 50.0f;
                        var position = npc.Center - Main.screenPosition - new Vector2(0.0f, y);
                        spriteBatch.Draw(texture, position, null, Color.White, 0.0f, origin, npc.scale, effects, 0.0f);
                    }
					
			
			var texture2 = mod.GetTexture("Miscellaneous/QuestIcon2");
            if (texture2 == null) return;
            if (npc.type == 105 || npc.type == 106 || npc.type == 123 || npc.type == 354 || npc.type == 376 || npc.type == 579)
			{
                var effects = npc.spriteDirection == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
                var origin = new Vector2(texture2.Width / 2, texture2.Height / 2);
                var y = 50.0f;
                var position = npc.Center - Main.screenPosition - new Vector2(0.0f, y);
                spriteBatch.Draw(texture2, position, null, Color.White, npc.rotation, origin, npc.scale, effects, 0.0f);
            }
        }

        public override void NPCLoot(NPC npc)
        {
			int playerIndex = npc.lastInteraction;
			if (!Main.player[playerIndex].active || Main.player[playerIndex].dead)
			{
				playerIndex = npc.FindClosestPlayer();
			}
			Player player = Main.player[playerIndex];
            var questSystem = Main.player[playerIndex].GetModPlayer<QuestSystem>(mod);
            var aPlayer = Main.player[playerIndex].GetModPlayer<AntiarisPlayer>(mod);
			var pirateQuestSystem = Main.player[playerIndex].GetModPlayer<Pirate.PirateQuestSystem>(mod);
            int number = 0;
            if (!npc.SpawnedFromStatue)
            {
                if ((npc.type == 3 || npc.type == 132 || npc.type == 161 || npc.type == 186 || npc.type == 187 ||
                     npc.type == 188 || npc.type == 189 || npc.type == 200
                     || npc.type == 223 || npc.type == 254 || npc.type == 255 || npc.type == 319 || npc.type == 320 ||
                     npc.type == 321 || npc.type == 331 || npc.type == 332 || npc.type == 430
                     || npc.type == 431 || npc.type == 432 || npc.type == 433 || npc.type == 434 || npc.type == 435 ||
                     npc.type == 436 || npc.type == 489) && Main.rand.Next(3) == 0)
                    Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height,mod.ItemType("BloodDroplet"), Main.rand.Next(3, 4), false, 0, false, false);

                if ((npc.type == 3 || npc.type == 132 || npc.type == 161 || npc.type == 186 || npc.type == 187 ||
                     npc.type == 188 || npc.type == 189 || npc.type == 200
                     || npc.type == 223 || npc.type == 254 || npc.type == 255 || npc.type == 319 || npc.type == 320 ||
                     npc.type == 321 || npc.type == 331 || npc.type == 332 || npc.type == 430 || npc.type == 431
                     || npc.type == 432 || npc.type == 433 || npc.type == 434 || npc.type == 435 || npc.type == 436 ||
                     npc.type == 489) && Main.rand.Next(3) == 0)
                    Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, mod.ItemType("BloodDroplet"), Main.rand.Next(3, 4), false, 0, false, false);

                if ((npc.type == 480 || npc.type == 481 || npc.type == 482 || npc.type == 483) && Main.rand.Next(4) == 0)
                    Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, mod.ItemType("RuneStone"), 1, false, 0, false, false);

                if (npc.type == 283 || npc.type == 284)
                    Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, mod.ItemType("NecroCloth"), Main.rand.Next(10, 14), false, 0, false, false);

                if (questSystem.currentQuest == QuestItemID.GlacialCrystal &&
                    (npc.type == 206 || npc.type == 167 || npc.type == 147 || npc.type == 169 || npc.type == 184 ||
                     npc.type == 150) && Main.rand.Next(4) == 0)
                {
                    number = Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, mod.ItemType("GlacialCrystal"), 1, false, 0, false, false);
                    if (Main.netMode == 1 && number >= 0)
                        NetMessage.SendData(21, -1, -1, null, number, 1f, 0.0f, 0.0f, 0, 0, 0);
                }

                if (questSystem.currentQuest == QuestItemID.Necronomicon &&
                    (npc.type == 31 || npc.type == 294 || npc.type == 295 || npc.type == 296 || npc.type == 32 ||
                     npc.type == 34) && Main.rand.Next(6) == 0)
                {
                    number = Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, mod.ItemType("Necronomicon"), 1, false, 0, false, false);
                    if (Main.netMode == 1 && number >= 0)
                        NetMessage.SendData(21, -1, -1, null, number, 1f, 0.0f, 0.0f, 0, 0, 0);
                }

                if (questSystem.currentQuest == QuestItemID.HarpyEgg && npc.type == 48 && Main.rand.Next(6) == 0)
                {
                    number = Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, mod.ItemType("HarpyEgg"), 1, false, 0, false, false);
                    if (Main.netMode == 1 && number >= 0)
                        NetMessage.SendData(21, -1, -1, null, number, 1f, 0.0f, 0.0f, 0, 0, 0);
                }

                if (questSystem.currentQuest == QuestItemID.AdventurersFishingRod && (npc.type == 3 ||
                                                                                      npc.type == 132 ||
                                                                                      npc.type == 161 ||
                                                                                      npc.type == 186 ||
                                                                                      npc.type == 187 || 
																					  npc.type == 188 ||
                                                                                      npc.type == 189 ||
                                                                                      npc.type == 200 ||
                                                                                      npc.type == 223 ||
                                                                                      npc.type == 254 ||
                                                                                      npc.type == 255 ||
                                                                                      npc.type == 319 ||
                                                                                      npc.type == 320 ||
                                                                                      npc.type == 321 || 
																					  npc.type == 331 ||
                                                                                      npc.type == 332 ||
                                                                                      npc.type == 430 ||
                                                                                      npc.type == 431 ||
                                                                                      npc.type == 432 ||
                                                                                      npc.type == 433 ||
                                                                                      npc.type == 434 ||
                                                                                      npc.type == 435 ||
                                                                                      npc.type == 436 ||
                                                                                      npc.type == 489)
                                                                                  && Main.rand.Next(6) == 0)
                {
                    number = Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, mod.ItemType("AdventurersFishingRodPart1"), 1, false, 0, false, false);
                    if (Main.netMode != 1 && number >= 0)
                        NetMessage.SendData(21, -1, -1, null, number, 1f, 0.0f, 0.0f, 0, 0, 0);
                }

                if (questSystem.currentQuest == QuestItemID.AdventurersFishingRod && (npc.type == 3 ||
                                                                                      npc.type == 132 ||
                                                                                      npc.type == 161 ||
                                                                                      npc.type == 186 ||
                                                                                      npc.type == 187 || 
																					  npc.type == 188 ||
                                                                                      npc.type == 189 ||
                                                                                      npc.type == 200 ||
                                                                                      npc.type == 223 ||
                                                                                      npc.type == 254 ||
                                                                                      npc.type == 255 ||
                                                                                      npc.type == 319 ||
                                                                                      npc.type == 320 ||
                                                                                      npc.type == 321 || 
																					  npc.type == 331 ||
                                                                                      npc.type == 332 ||
                                                                                      npc.type == 430 ||
                                                                                      npc.type == 431 ||
                                                                                      npc.type == 432 ||
                                                                                      npc.type == 433 ||
                                                                                      npc.type == 434 ||
                                                                                      npc.type == 435 ||
                                                                                      npc.type == 436 ||
                                                                                      npc.type == 489)
                                                                                  && Main.rand.Next(6) == 0)
                {
                    number = Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, mod.ItemType("AdventurersFishingRodPart2"), 1, false, 0, false, false);
                    if (Main.netMode == 1 && number >= 0)
                        NetMessage.SendData(21, -1, -1, null, number, 1f, 0.0f, 0.0f, 0, 0, 0);
                }

                if (questSystem.currentQuest == QuestItemID.AdventurersFishingRod && (npc.type == 3 ||
                                                                                      npc.type == 132 ||
                                                                                      npc.type == 161 ||
                                                                                      npc.type == 186 ||
                                                                                      npc.type == 187 || 
																					  npc.type == 188 ||
                                                                                      npc.type == 189 ||
                                                                                      npc.type == 200 ||
                                                                                      npc.type == 223 ||
                                                                                      npc.type == 254 ||
                                                                                      npc.type == 255 ||
                                                                                      npc.type == 319 ||
                                                                                      npc.type == 320 ||
                                                                                      npc.type == 321 || 
																					  npc.type == 331 ||
                                                                                      npc.type == 332 ||
                                                                                      npc.type == 430 ||
                                                                                      npc.type == 431 ||
                                                                                      npc.type == 432 ||
                                                                                      npc.type == 433 ||
                                                                                      npc.type == 434 ||
                                                                                      npc.type == 435 ||
                                                                                      npc.type == 436 ||
                                                                                      npc.type == 489)
                                                                                  && Main.rand.Next(6) == 0)
                {
                    number = Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, mod.ItemType("AdventurersFishingRodPart3"), 1, false, 0, false, false);
                    if (Main.netMode == 1 && number >= 0)
                        NetMessage.SendData(21, -1, -1, null, number, 1f, 0.0f, 0.0f, 0, 0, 0);
                }

                if (questSystem.currentQuest == QuestItemID.DemonWings && npc.type == 62 && Main.rand.Next(1) == 0)
                {
                    Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, mod.ItemType("DemonWingPiece"), Main.rand.Next(1, 3), false, 0, false, false);
                    if (Main.netMode == 1 && number >= 0)
                       NetMessage.SendData(21, -1, -1, null, number, 1f, 0.0f, 0.0f, 0, 0, 0);
                }

                if (questSystem.currentQuest == QuestItemID.AdventurerChest && npc.type == 65 && Main.rand.Next(6) == 0)
                {
                    number = Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, mod.ItemType("AdventurerChest"), 1, false, 0, false, false);
                    if (Main.netMode == 1 && number >= 0)
                        NetMessage.SendData(21, -1, -1, null, number, 1f, 0.0f, 0.0f, 0, 0, 0);
                }

                if (npc.type == 62 && Main.rand.Next(22) == 0 && Main.hardMode)
                    Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, mod.ItemType("HellScythe"), 1, false, 0, false, false);
                if (npc.type == 158 || npc.type == 159)
                    Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, mod.ItemType("VampiricEssence"), Main.rand.Next(2, 4), false, 0, false, false);
                if (npc.type == 383 && Main.rand.Next(25) == 0)
                    Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, mod.ItemType("ShieldGenerator"), 1, false, 0, false, false);
                if (npc.type == 471 && Main.rand.Next(12) == 0)
                    Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, mod.ItemType("ShadowflameCharm"), 1, false, 0, false, false);
                if (npc.type == 471)
                    Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, mod.ItemType("Shadowflame"), Main.rand.Next(5, 10), false, 0, false, false);
                if (npc.type == 489)
                    Item.NewItem((int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, mod.ItemType("BloodDroplet"), Main.rand.Next(4, 6), false, 0, false, false);
			}  
			if (pirateQuestSystem.currentPirateQuest == 0)
			{
				if (npc.type == 4 && Main.rand.Next(2) == 0)
				{
					number = Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AmuletPiece2"), 1, false, 0, false, false);
					if (Main.netMode == 1 && number >= 0)
						NetMessage.SendData(21, -1, -1, null, number, 1f, 0.0f, 0.0f, 0, 0, 0);
				}
				if (npc.type == 13 || npc.type == 14 || npc.type == 15)
					if (npc.boss)
					{
						number = Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AmuletPiece1"), 1, false, 0, false, false);
						if (Main.netMode == 1 && number >= 0)
							NetMessage.SendData(21, -1, -1, null, number, 1f, 0.0f, 0.0f, 0, 0, 0);
					}
				if (npc.type == 266 && Main.rand.Next(2) == 0)
				{
					number = Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AmuletPiece1"), 1, false, 0, false, false);
					if (Main.netMode == 1 && number >= 0)
						NetMessage.SendData(21, -1, -1, null, number, 1f, 0.0f, 0.0f, 0, 0, 0);
				}
				if (npc.type == 50 && Main.rand.Next(2) == 0)
				{
					number = Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AmuletPiece3"), 1, false, 0, false, false);
					if (Main.netMode == 1 && number >= 0)
						NetMessage.SendData(21, -1, -1, null, number, 1f, 0.0f, 0.0f, 0, 0, 0);
				}
			}
        }

        public override bool CheckDead(NPC npc)
        {
            var aPlayer = Main.player[Main.myPlayer].GetModPlayer<AntiarisPlayer>(mod);
            if (aPlayer.RavenousSpores && Main.rand.Next(3) == 0)
            {
                for (var k = 0; k < 20; k++) Dust.NewDust(npc.position, npc.width, npc.height, 44, 2.5f * (float)npc.velocity.X, -2.5f, 0, default(Color), 0.7f);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -2f, 0f, 228, npc.damage * 2, 0.0f, 0, 0.0f, 0.0f);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 2f, 0f, 228, npc.damage * 2, 0.0f, 0, 0.0f, 0.0f);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0f, -2f, 228, npc.damage * 2, 0.0f, 0, 0.0f, 0.0f);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0f, 2f, 228, npc.damage * 2, 0.0f, 0, 0.0f, 0.0f);
            }
            if (npc.type == 48 && Main.rand.Next(3) == 0) Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0f, 0f, mod.ProjectileType("CalmnessEnergy"), 0, 0.0f, 0, 0.0f, 0.0f);      
            return base.CheckDead(npc);
        }

        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            if (type == NPCID.WitchDoctor && Main.hardMode)
            {
                shop.item[nextSlot].SetDefaults(mod.ItemType<Items.Equipables.Accessories.ScaryMask>());
                nextSlot++;
            }
            if (type == NPCID.ArmsDealer && Main.hardMode)
            {
                shop.item[nextSlot].SetDefaults(mod.ItemType<Items.Weapons.Ranged.Guns.ArmyRifle>());
                nextSlot++;
            }
            if (type == NPCID.ArmsDealer)
            {
                shop.item[nextSlot].SetDefaults(mod.ItemType<Items.Consumables.Ammo.Buckshots.Buckshot>());
                nextSlot++;
            }
            if (type == NPCID.ArmsDealer && NPC.downedBoss3)
            {
                shop.item[nextSlot].SetDefaults(mod.ItemType<Items.Weapons.Ranged.Guns.AssaultRifle>());
                nextSlot++;
            }
            var questSystem = Main.player[Main.myPlayer].GetModPlayer<QuestSystem>(mod);
            if (type == NPCID.ArmsDealer && questSystem.CurrentQuest == 12)
            {
                shop.item[nextSlot].SetDefaults(mod.ItemType<Items.Materials.BonebardierBlueprint>());
                nextSlot++;
            }
			if (type == NPCID.Painter && Main.bloodMoon)
            {
                shop.item[nextSlot].SetDefaults(mod.ItemType<Items.Placeables.Decorations.TheKiller>());
                nextSlot++;
            }
			if (type == NPCID.Dryad && Main.player[Main.myPlayer].ZoneHoly)
            {
                shop.item[nextSlot].SetDefaults(mod.ItemType<Items.Miscellaneous.PixieLamp>());
                nextSlot++;
            }
        }

        public bool NoDamage;
        public override void SetDefaults(NPC npc)
        {
            NoDamage = npc.dontTakeDamage;
			if(!AntiarisWorld.frozenTime)
			    this.NpcFrame = npc.frame;
			else
			    npc.frame = this.NpcFrame;
		}

        public override bool PreAI(NPC npc)
		{
            if (AntiarisWorld.frozenTime)
			{
				npc.position.X = npc.oldPosition.X;
				npc.position.Y = npc.oldPosition.Y;
				npc.dontTakeDamage = true;
                npc.frameCounter = 0;
				npc.damage = 0;
				return false;
			}
				
			else
			{
                if(!NoDamage)
			    	npc.dontTakeDamage = false;
				return true;
			}
			return base.PreAI(npc);
		}

        public override void FindFrame(NPC npc, int frameHeight)
		{
			if(AntiarisWorld.frozenTime)
				return;
		}

        public override void AI(NPC npc)
        {
			var aPlayer = Main.player[Main.myPlayer].GetModPlayer<AntiarisPlayer>(mod);
			var player = Main.player[Main.myPlayer];
            for (var l = 3; l < 8 + player.extraAccessorySlots; l++)
                if (AntiarisNPC.Slimes.Contains(npc.type)) npc.catchItem = (short)(mod.ItemType("GreenGoo"));
        }
    }
}