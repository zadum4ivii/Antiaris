using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.NPCs.Bosses
{
	[AutoloadBossHead]
    public class TowerKeeper2 : ModNPC
    {
        private int ai;
        private int attackTimer = 0;
        private int buffTime = 0;
        private int buffTimeKey;
        private bool checkDead = false;

        private double counting;
        private int deadTimer = 0;
        private bool fastSpeed = false;
        private int frame;
        private bool secondState;
        private bool secondState2;
        private bool stunned;
        private int stunnedTimer;

        public override void SetDefaults()
        {
            npc.lifeMax = 9000;
            npc.damage = 30;
            npc.defense = 17;
            npc.knockBackResist = 0f;
            npc.width = 204;
            npc.height = 160;
            npc.npcSlots = 5f;
            npc.HitSound = mod.GetLegacySoundSlot(Terraria.ModLoader.SoundType.Custom, "Sounds/NPCs/TowerKeeperHit");
            npc.noGravity = true;
            npc.npcSlots = 5f;
			npc.boss = true;
            npc.value = Item.buyPrice(0, 11, 0, 0);
            npc.noTileCollide = true;
			Main.npcFrameCount[npc.type] = 6;
			bossBag = mod.ItemType("TowerKeeperTreasureBag2");
			music = mod.GetSoundSlot(Terraria.ModLoader.SoundType.Music, "Sounds/Music/TowerKeeper");
        }

        public override void ScaleExpertStats(int playerXPlayers, float bossLifeScale)
        {
            if (playerXPlayers > 1)
            {
                npc.lifeMax = (int)(11000 + (double)npc.lifeMax * 0.2 * (double)playerXPlayers);
            }
            else
            {
                npc.lifeMax = 11000;
            }
            npc.damage = (int)(npc.damage * 0.65f);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tower Keeper");
            DisplayName.AddTranslation(GameCulture.Chinese, "守塔魔像");
            DisplayName.AddTranslation(GameCulture.Russian, "Хранитель башни");
        }

        public void OverhaulInit()
        {
            this.SetTag("boss");
            this.SetTag("noStuns");
        }

        public override void NPCLoot()
        {
			AntiarisWorld.DownedTowerKeeper = true;
            if (Main.expertMode)
            {
                npc.DropBossBags();
            }
            if (!Main.expertMode)
            {
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ShadowChargedCrystal"), Main.rand.Next(15,24), false, 0, false, false);
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MirrorShard"), Main.rand.Next(10,15), false, 0, false, false);
                if (Main.rand.Next(7) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TowerKeeperMask2"), 1, false, 0, false, false);
                }
				if (Main.rand.Next(7) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GuardianHeart"), 1, false, 0, false, false);
                }
            }
            if (Main.rand.Next(10) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TowerKeeperTrophy2"), 1, false, 0, false, false);
            }
		}

        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = 188;
        }

        public override void AI()
        {
            Player player = Main.player[npc.target];
            Vector2 target = npc.HasPlayerTarget ? player.Center : Main.npc[npc.target].Center;
            npc.netAlways = true;
            npc.rotation = 0.0f;
            npc.TargetClosest(true);
            if (npc.life >= npc.lifeMax)
                npc.life = npc.lifeMax;
            if (npc.target < 0 || npc.target == 255 || player.dead || !player.active)
            {
                npc.TargetClosest(false);
                npc.direction = 1;
                npc.velocity.Y = npc.velocity.Y - 0.1f;
                if (npc.timeLeft > 10)
                {
                    npc.timeLeft = 10;
                    return;
                }
            }
            if (this.stunned)
            {
                npc.velocity.Y = 0.0f;
                npc.velocity.X = 0.0f;
                ++this.stunnedTimer;
                if (this.stunnedTimer >= 105)
                {
                    this.stunned = false;
                    this.stunnedTimer = 0;
                }
            }
            if (!this.secondState)
            {
                float distance = 160f;
                float k = 1.26f;
                for (int count = 0; count < 10; count++)
                {
                    Vector2 spawn = npc.Center + distance * ((float)count * k).ToRotationVector2();
                    NPC.NewNPC((int)spawn.X, (int)spawn.Y, mod.NPCType("ProtectiveStone2"), 0, (float)npc.whoAmI, 0.0f, (float)count, 0.0f, 255);
                }
                this.secondState = true;
            }
            ++this.ai;
            npc.ai[0] = (float)this.ai * 1f;
            int velocity = (int)((double)npc.ai[0] / 50f);
            bool speedB = ((double)npc.life <= npc.lifeMax * 0.6 ? true : false);
            int speedV = (int)(speedB ? 6f : 0f);
            if ((double)npc.ai[0] < 350.0 && !this.stunned)
            {
                this.frame = 0;
                AntiarisHelper.MoveTowards(npc, target, (int)(Vector2.Distance(target, npc.Center) > 300 ? (Main.expertMode ? 24f : 20f) : (Main.expertMode ? 9f : 7f)) + speedV, 30f);
                for (int k = 0; k < 5 * (npc.ai[0] / 50); k++)
                {
                    float scale = 0.4f;
                    if (npc.ai[0] % 2 == 1) scale = 0.65f;
                    Vector2 sDust = npc.Center + ((float)Main.rand.NextDouble() * 6.283185f).ToRotationVector2() * (12f - (float)(velocity * 2));
                    int index2 = Dust.NewDust(sDust - Vector2.One * 12f, 24, 24, 62, npc.velocity.X / 2f, npc.velocity.Y / 2f, 0, new Color(), 1f);
                    Main.dust[index2].position -= new Vector2(2f);
                    Main.dust[index2].velocity = Vector2.Normalize(npc.Center - sDust) * 1.5f * (float)(10.0 - (double)velocity * 2.0) / 10f;
                    Main.dust[index2].noGravity = true;
                    Main.dust[index2].scale = scale;
                    Main.dust[index2].customData = (object)npc;
                }
                npc.netUpdate = true;
                if ((double)npc.ai[0] % 349.0 == 0)
                {
                    this.buffTime += 1;
                    //CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), Color.Purple, "+1", false, false);
                }
            }
            else if ((double)npc.ai[0] >= 350.0 && (double)npc.ai[0] < 450.0)
            {
                this.stunned = true;
                this.frame = 2;
                AntiarisHelper.MoveTowards(npc, target, (int)(Vector2.Distance(target, npc.Center) > 300 ? (Main.expertMode ? 24f : 20f) : (Main.expertMode ? 9f : 7f)) + speedV, 30f);
                for (int k = 0; k < 2 * (npc.ai[0] / 45); k++)
                {
                    float scale = 0.65f;
                    if (npc.ai[0] % 2 == 1) scale = 0.81f;
                    Vector2 sDust = npc.Center + ((float)Main.rand.NextDouble() * 6.283185f).ToRotationVector2() * (12f - (float)(velocity * 2));
                    int index2 = Dust.NewDust(sDust - Vector2.One * 12f, 24, 24, 62, npc.velocity.X / 2f, npc.velocity.Y / 2f, 0, new Color(), 1f);
                    Main.dust[index2].position -= new Vector2(2f);
                    Main.dust[index2].velocity = Vector2.Normalize(npc.Center - sDust) * 1.5f * (float)(10.0 - (double)velocity * 2.0) / 10f;
                    Main.dust[index2].noGravity = true;
                    Main.dust[index2].scale = scale;
                    Main.dust[index2].customData = (object)npc;
                }
                player.AddBuff(mod.BuffType("Injured"), Main.expertMode ? 560 : 420, true);
                npc.netUpdate = true;
            }
            if ((double)npc.ai[0] > 450.0)
            {
                this.frame = 1;
                this.stunned = false;
                npc.defense = 40;
                if (!this.fastSpeed)
                {
                    if (Main.rand.Next(2) == 0)
                    {
                        this.fastSpeed = true;
                        npc.ai[2] = 0f;
                    }
                    else
                    {
                        this.fastSpeed = true;
                        npc.ai[2] = 1f;
                    }
                }
                else
                {
                    if ((double)npc.ai[2] == 0.0)
                    {
                        if ((double)npc.ai[0] % 50 == 0)
                        {
                            float speed = 21f + speedV;
                            if (Main.expertMode)
                                speed = 25f + speedV;
                            Vector2 vector_ = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                            float x = player.position.X + (float)(player.width / 2) - vector_.X;
                            float y = player.position.Y + (float)(player.height / 2) - vector_.Y;
                            float distanse = (float)Math.Sqrt((double)x * (double)x + (double)y * (double)y);
                            float resuceFactor = speed / distanse;
                            npc.velocity.X = x * resuceFactor;
                            npc.velocity.Y = y * resuceFactor;
                        }
                    }
                    else
                    {
                        npc.alpha = 180;
                        if ((double)npc.ai[0] % 35 == 0)
                        {
                            float speed = 28f + speedV;
                            if (Main.expertMode)
                                speed = 30f + speedV;
                            Vector2 vector_ = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                            float x = player.position.X + (float)(player.width / 2) - vector_.X;
                            float y = player.position.Y + (float)(player.height / 2) - vector_.Y;
                            float distanse = (float)Math.Sqrt((double)x * (double)x + (double)y * (double)y);
                            float resuceFactor = speed / distanse;
                            npc.velocity.X = x * resuceFactor;
                            npc.velocity.Y = y * resuceFactor;
                        }
                    }
                }
                npc.netUpdate = true;
            }
            else
                npc.defense = 22;
            if ((double)npc.ai[0] >= 650.0)
            {
                this.ai = 0;
                npc.alpha = 0;
                npc.ai[2] = 0;
                this.fastSpeed = false;
            }
            if ((double)npc.life <= npc.lifeMax * 0.333)
            {
                npc.alpha = 0;
                this.ai = 0;
                this.frame = 0;
                npc.ai[1] += 1 + ((double)npc.life <= npc.lifeMax * 0.111 ? 1 : ((double)npc.life <= npc.lifeMax * 0.222 ? 1 : 0));
                npc.defense = 25;
                if ((double)npc.ai[1] < 200.0)
                {
                    this.frame = 2;
                    npc.velocity.X = 0f; npc.velocity.Y = 0f;
                }
                if ((double)npc.ai[1] < 200.0)
                    for (int k = 0; k < 3 * (npc.ai[1] / 50); k++)
                    {
                        float scale = 0.81f;
                        if (npc.ai[0] % 2 == 1) scale = 1f;
                        Vector2 sDust = npc.Center + ((float)Main.rand.NextDouble() * 6.283185f).ToRotationVector2() * (12f - (float)(velocity * 2));
                        int index2 = Dust.NewDust(sDust - Vector2.One * 12f, 24, 24, 62, npc.velocity.X / 2f, npc.velocity.Y / 2f, 0, new Color(), 1f);
                        Main.dust[index2].position -= new Vector2(2f);
                        Main.dust[index2].velocity = Vector2.Normalize(npc.Center - sDust) * 1.5f * (float)(10.0 - (double)velocity * 2.0) / 10f;
                        Main.dust[index2].noGravity = true;
                        Main.dust[index2].scale = scale;
                        Main.dust[index2].customData = (object)npc;
                    }
                if ((double)npc.ai[1] % 200.0 == 0 && (double)npc.ai[1] <= 399.0)
                {
                    this.attackTimer += 1;
                    if (this.attackTimer <= 2)
                    {
                        Vector2 shootPos = npc.Center;
                        float inaccuracy = 10f * (npc.life / npc.lifeMax);
                        Vector2 shootVel = target - shootPos + new Vector2(Main.rand.NextFloat(-inaccuracy, inaccuracy), Main.rand.NextFloat(-inaccuracy, inaccuracy));
                        shootVel.Normalize();
                        shootVel *= 14f;
                        Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 88);
                        for (int k = 0; k < (Main.expertMode ? 5 : 3); k++) Projectile.NewProjectile(shootPos.X + (float)(-100 * npc.direction) + (float)Main.rand.Next(-40, 41), shootPos.Y - (float)Main.rand.Next(-50, 40), shootVel.X, shootVel.Y, mod.ProjectileType("GolemCrystal2"), npc.damage / 3, 5f);
                    }
                    else
                    {
                        if (Main.expertMode)
                        {
                            for (int i = 0; i < 7; i++)
                                Projectile.NewProjectile((int)((player.position.X - 50) + Main.rand.Next(100)), (int)((player.position.Y - 50) + Main.rand.Next(100)), 0.0f, 0.0f, mod.ProjectileType("TowerKeeper2Sheet"), npc.damage / 3, 4.5f);
                        }
                        for (int k = 0; k < (Main.expertMode ? 8 : 5); k++)
                        {
                            Vector2 shootPos = player.position + new Vector2(Main.rand.Next(-300, 300), -1000);
                            Vector2 shootVel = new Vector2(Main.rand.NextFloat(-3f, 3f), Main.rand.NextFloat(9f, 14f));
                            Projectile.NewProjectile(shootPos, shootVel, mod.ProjectileType("GolemCrystal2"), npc.damage / 2, 4.5f);
                        }
                        Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 88);
                        this.attackTimer = 0;
                    }
                }
                if ((double)npc.ai[1] > 200.0)
                {
                    AntiarisHelper.MoveTowards(npc, player.Center, 8f + (float)((double)npc.life <= npc.lifeMax * 0.111 ? 3 : ((double)npc.life <= npc.lifeMax * 0.222 ? 2 : 0)), 8f + (float)((double)npc.life <= npc.lifeMax * 0.111 ? 3 : ((double)npc.life <= npc.lifeMax * 0.222 ? 2 : 0)));
                }
                if (npc.ai[1] >= 350f)
                    npc.ai[1] = 0f;
                npc.netUpdate = true;
            }
			if ((double)npc.life <= npc.lifeMax * 0.135)
            {
                this.frame = 1;
                this.stunned = true;
                if (!this.secondState2)
                {
                    float distance = 160f;
                    float k = 1.26f;
                    for (int count = 0; count < 10; count++)
                    {
                        Vector2 spawn = npc.Center + distance * ((float)count * k).ToRotationVector2();
                        NPC.NewNPC((int)spawn.X, (int)spawn.Y, mod.NPCType("ProtectiveStone2"), 0, (float)npc.whoAmI, 0.0f, (float)count, 0.0f, 255);
                    }
                    this.secondState2 = true;
                }
                if (NPC.AnyNPCs(mod.NPCType("ProtectiveStone2")))
                {
                    //if ((double)this.ai % 215.0 == 0.0)
					if(Main.rand.Next(5) == 0)
                        Projectile.NewProjectile((int)((npc.position.X - 500) + Main.rand.Next(1000)), (int)((npc.position.Y - 500) + Main.rand.Next(1000)), 0.0f, 0.0f, mod.ProjectileType("TowerKeeper2Sheet"), npc.damage / 3, 4.5f);
                    npc.dontTakeDamage = true;
                }
                else
                {
                    //if ((double)this.ai % 225.0 == 0.0)
					if(Main.rand.Next(5) == 0)
                        Projectile.NewProjectile((int)((npc.position.X - 500) + Main.rand.Next(1000)), (int)((npc.position.Y - 500) + Main.rand.Next(1000)), 0.0f, 0.0f, mod.ProjectileType("TowerKeeper2Sheet"), npc.damage / 3, 4.5f);
                    npc.dontTakeDamage = false;
                }
            }
            if (this.buffTime >= 3)
            {
                ++this.buffTimeKey;
                if (this.buffTimeKey >= 120)
                {
                    player.AddBuff(BuffID.Cursed, Main.expertMode ? 320 : 60, true);
                    player.AddBuff(BuffID.BrokenArmor, Main.expertMode ? 320 : 60, true);
                    player.AddBuff(BuffID.Slow, Main.expertMode ? 320 : 60, true);
                    Main.player[Main.myPlayer].statMana = 0;
                    this.buffTime = 0;
                    this.buffTimeKey = 0;
                    npc.netUpdate = true;
                }
            }
            if (this.checkDead)
            {
                npc.dontTakeDamage = true;
                this.ai = 0;
                npc.ai[0] = 0;
                npc.ai[1] = 0;
                npc.velocity.X = npc.velocity.Y = 0f;
                ++this.deadTimer;
                this.frame = 0;
                for (int k = 0; k < 5 * (this.deadTimer / 50); k++)
                {
                    npc.dontTakeDamage = true;
                    float scale = 0.81f;
                    if (npc.ai[0] % 2 == 1) scale = 1f;
                    Vector2 sDust = npc.Center + ((float)Main.rand.NextDouble() * 6.283185f).ToRotationVector2() * (12f - (float)(velocity * 2));
                    int index2 = Dust.NewDust(sDust - Vector2.One * 12f, 24, 24, 62, npc.velocity.X / 2f, npc.velocity.Y / 2f, 0, new Color(), 1f);
                    Main.dust[index2].position -= new Vector2(2f);
                    Main.dust[index2].velocity = Vector2.Normalize(npc.Center - sDust) * 1.5f * (float)(10.0 - (double)velocity * 2.0) / 10f;
                    Main.dust[index2].noGravity = true;
                    Main.dust[index2].scale = scale;
                    Main.dust[index2].customData = (object)npc;
                }
                if (this.deadTimer == 100)
                {
                    Main.PlaySound(mod.GetLegacySoundSlot(Terraria.ModLoader.SoundType.Custom, "Sounds/NPCs/TowerKeeperDeath"), npc.position);
                }
                if (this.deadTimer >= 300)
                {
                    this.frame = 1;
                    if (this.deadTimer >= 400)
                    {
                        npc.life = 0;
                        npc.HitEffect(0, 1337);
                        npc.checkDead();
                        Main.PlaySound(4, (int)npc.position.X, (int)npc.position.Y, 43);
                        Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TowerKeeperGore1"), 1f);
                        Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TowerKeeperGore2"), 1f);
                        Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TowerKeeperGore2"), 1f);
                        Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TowerKeeperGore2"), 1f);
                        Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TowerKeeperGore3"), 1f);
                        Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TowerKeeperGore3"), 1f);
                        Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TowerKeeperGore3"), 1f);
                        Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TowerKeeperGore4"), 1f);
                        Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TowerKeeperGore4"), 1f);
                        Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TowerKeeperGore4"), 1f);
                        Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/TowerKeeperGore4"), 1f);
                    }
                }
                if (this.deadTimer >= 0)
                    Main.musicFade[Main.curMusic] = 1f / (float)(this.deadTimer / 15 * 0.5f);
            }
        }

        public override void ModifyHitByProjectile(Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			if (Main.expertMode && this.frame == 1)
			{
				projectile.velocity.X = -projectile.velocity.X;
				projectile.velocity.Y = -projectile.velocity.Y;
				projectile.friendly = false;
				projectile.hostile = true;
				projectile.damage /= 3;
			}
		}

        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            var GlowMask = mod.GetTexture("Glow/TowerKeeper2_GlowMask");
            var Effects = npc.direction == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            spriteBatch.Draw(GlowMask, npc.Center - Main.screenPosition + new Vector2(0, npc.gfxOffY), npc.frame, Color.White, npc.rotation, npc.frame.Size() / 2, npc.scale, Effects, 0);
        }

        public override bool CheckDead()
		{
			if (this.deadTimer <= 0)
			{
				this.checkDead = true;
				npc.life = npc.lifeMax;
				npc.dontTakeDamage = true;
				npc.netUpdate = true;
				return false;
			}
			return base.CheckDead();
		}

        public override void FindFrame(int frameHeight)
		{
			if (this.frame == 0)
			{
				counting += 1.0;
                if (counting < 8.0)
                {
                    npc.frame.Y = 0;
                }
                else if (counting < 16.0)
                {
                    npc.frame.Y = frameHeight;
                }
                else if (counting < 24.0)
                {
                    npc.frame.Y = frameHeight * 2;
                }
                else if (counting < 32.0)
                {
                    npc.frame.Y = frameHeight * 3;
                }               
                else
                {
                    counting = 0.0;
                }
			}
			else if (this.frame == 1)
				 npc.frame.Y = frameHeight * 4;
			else
				npc.frame.Y = frameHeight * 5;
		}
    }
}
