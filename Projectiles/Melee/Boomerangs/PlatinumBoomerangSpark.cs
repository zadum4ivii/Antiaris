using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Melee.Boomerangs
{
    public class PlatinumBoomerangSpark : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 8;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.aiStyle = 0;
            projectile.penetrate = 1;
            projectile.timeLeft = 1200;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Platinum Spark");
            DisplayName.AddTranslation(GameCulture.Chinese, "铂金火花");
            DisplayName.AddTranslation(GameCulture.Russian, "Платиновая искра");
        }

        public override void AI()
        {
            projectile.localAI[0] += 1f;
            if (projectile.localAI[0] > 3f)
            {
                int num90 = 1;
                if (projectile.localAI[0] > 5f)
                {
                    num90 = 2;
                }
                for (int num91 = 0; num91 < num90; num91++)
                {
                    int num92 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y + 2f), projectile.width, projectile.height, 60, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 2f);
                    Main.dust[num92].noGravity = true;
                    Dust expr_46AC_cp_0 = Main.dust[num92];
                    expr_46AC_cp_0.velocity.X = expr_46AC_cp_0.velocity.X * 0.3f;
                    Dust expr_46CA_cp_0 = Main.dust[num92];
                    expr_46CA_cp_0.velocity.Y = expr_46CA_cp_0.velocity.Y * 0.3f;
                    Main.dust[num92].noLight = true;
                }
                if (projectile.wet && !projectile.lavaWet)
                {
                    projectile.Kill();
                    return;
                }
            }
        }

        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 5; k++)
            {
                int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 60, projectile.oldVelocity.X * 0.7f, projectile.oldVelocity.Y * 0.7f);
            }
            Main.PlaySound(SoundID.Item10, projectile.position);
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            projectile.ai[0] += 0.1f;
            projectile.velocity *= 0.75f;
        }
    }
}
