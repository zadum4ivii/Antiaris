using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Minions
{
    public class TrueTreacherousSphere : ModProjectile
    {
        private float aiTimer = 0.0f;

        private int chargedTimer = 0;
        private int targetNPC = -1;
        public override Color? GetAlpha(Color lightColor) { return Color.White; }

        public override void SetDefaults()
        {
            projectile.width = 48;
            projectile.height = 46;
            projectile.scale = 1.0f;
            projectile.tileCollide = false;
            projectile.timeLeft = 7200;
            projectile.minion = true;
            projectile.sentry = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Treacherous Sphere");
            DisplayName.AddTranslation(GameCulture.Russian, "Истинная коварная сфера");
			DisplayName.AddTranslation(GameCulture.Chinese, "千瞬光球");
            ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
            Main.projFrames[projectile.type] = 4;
        }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            projectile.velocity.X = projectile.rotation = 0.0f;
            projectile.velocity.Y = 0.0f;
            projectile.frameCounter++;
            if (projectile.frameCounter >= 6) { projectile.frame++; projectile.frameCounter = 0; }
            if (projectile.frame >= 4) projectile.frame = 0;
            float distance = 400.0f;            
            bool target = false;
            NPC minionAttackTargetNpc = projectile.OwnerMinionAttackTargetNPC;
            if (minionAttackTargetNpc != null && minionAttackTargetNpc.CanBeChasedBy((object)projectile, true))
            {
                float distance2 = Vector2.Distance(minionAttackTargetNpc.Center, projectile.Center);
                if (((double)distance2 < (double)distance))
                {
                    distance = distance2;
                    targetNPC = minionAttackTargetNpc.whoAmI;
                    target = true;
                }
            }
            if (!target)
            {
                for (int k = 0; k < 200; k++)
                {
                    NPC npc = Main.npc[k];
                    if (npc.CanBeChasedBy((object)projectile, false))
                    {
                        float distance2 = Vector2.Distance(npc.Center, projectile.Center);
                        if (((double)distance2 < (double)distance))
                        {
                            distance = distance2;
                            targetNPC = k;
                            target = true;
                        }
                    }
                }
            }
            if ((double)projectile.ai[0] <= 0.0 && target) ++this.chargedTimer;
            if (target)
            {
                int delay = 3;
                ++this.aiTimer;
                if ((double)this.aiTimer >= 1.0) this.aiTimer = 0.0f;
                if (projectile.soundDelay <= 0 && (double)this.chargedTimer > 0.0 && (double)projectile.ai[0] <= 0.0)
                {
                    projectile.soundDelay = delay;
                    projectile.soundDelay *= 2;
                    if ((double)this.aiTimer != 1.0)
                        Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 75);
                }
            }
            if (Main.myPlayer != projectile.owner)
                return;
            if ((double)this.chargedTimer % 5.0 == 1.0 && (double)this.chargedTimer < 100.0 && (double)projectile.ai[1] != 0.0)
            {
                float speed = (float)(3.0 + (double)Main.rand.NextFloat() * 6.0);
                Vector2 start = Vector2.UnitY.RotatedByRandom(6.28318548202515);
                int j = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, start.X * speed, start.Y * speed, mod.ProjectileType("TrueTreacherousEnergy"), projectile.damage, projectile.knockBack * 2.0f, projectile.owner, (float)Main.npc[targetNPC].whoAmI, 0.0f); Main.projectile[j].minion = true; Main.projectile[j].magic = false;
            }
            if ((double)this.chargedTimer >= 100.0)
            {
                projectile.ai[0] = 180.0f;
                this.chargedTimer = 0;
            }
            if ((double)projectile.ai[0] % 30.0 == 0.0 && projectile.ai[0] > 0.0f)
            {
                for (int j = 0; j < 50; j++)
                {
                    int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.GoldFlame, 0.0f, -2.0f, 0, new Color(), 2.0f);
                    Main.dust[dust].noGravity = true;
                    Dust dust1 = Main.dust[dust];
                    dust1.position.X = dust1.position.X + ((float)(Main.rand.Next(-50, 51) / 20) - 1.5f);
                    Dust dust2 = Main.dust[dust];
                    dust2.position.Y = dust2.position.Y + ((float)(Main.rand.Next(-50, 51) / 20) - 1.5f);
                    if (Main.dust[dust].position != projectile.Center) Main.dust[dust].velocity = projectile.DirectionTo(Main.dust[dust].position) * 2.0f;
                }
            }
            if ((double)projectile.ai[0] > 0.0) projectile.ai[0]--;
            if ((double)projectile.ai[1] == 0.0 && Main.myPlayer == projectile.owner)
            {
                for (int k = 0; k < 1000; ++k)
                {
                    Vector2 vector2;
                    vector2.X = Main.MouseWorld.X - 26.0f;
                    vector2.Y = Main.MouseWorld.Y - 26.0f;
                    projectile.position = vector2;
                }
                ++projectile.ai[1];
                projectile.netUpdate = true;
            }
            projectile.netUpdate = true;
        }

        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 13; k++)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.GoldFlame, 0.0f, 0.0f, 100, new Color(), 1.0f);
                Main.dust[dust].noGravity = true;
                Vector2 velocity = projectile.velocity;
                Main.dust[dust].velocity = velocity.RotatedBy((double)(15 * (k + 2)), new Vector2());
            }
        }
    }
}
