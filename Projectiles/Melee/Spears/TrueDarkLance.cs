using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Melee.Spears
{
    public class TrueDarkLance : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 22;
            projectile.height = 22;
            projectile.aiStyle = 19;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.scale = 1.0f;
            projectile.hide = true;
            projectile.ownerHitCheck = true;
            projectile.melee = true;
            aiType = 46;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Dark Lance");
			DisplayName.AddTranslation(GameCulture.Chinese, "真·暗黑长戟");
            DisplayName.AddTranslation(GameCulture.Russian, "Истинная Темная Пика");
        }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            if (player.itemAnimation < player.itemAnimationMax / 3)
            {
                projectile.ai[0] -= 1.1f;
                if (projectile.localAI[0] == 0f)
                {
                    projectile.localAI[0] = 1f;
                    float count = 25.0f;
                    for (int k = 0; (double)k < (double)count; k++)
                    {
                        Vector2 vector2 = (Vector2.UnitX * 0.0f + -Vector2.UnitY.RotatedBy((double)k * (6.22 / (double)count), new Vector2()) * new Vector2(2.0f, 8.0f)).RotatedBy((double)projectile.velocity.ToRotation(), new Vector2());
                        int dust = Dust.NewDust(projectile.Center - new Vector2(0.0f, 4.0f), 0, 0, 27, 0.0f, 0.0f, 0, new Color(), 1.0f);
                        Main.dust[dust].scale = 1.25f;
                        Main.dust[dust].noGravity = true;
                        Main.dust[dust].position = projectile.Center + vector2;
                        Main.dust[dust].velocity = projectile.velocity * 0.0f + vector2.SafeNormalize(Vector2.UnitY) * 1.0f;
                    }
                    if (player.itemAnimation < player.itemAnimationMax / 2) Projectile.NewProjectile(projectile.Center.X + projectile.velocity.X, projectile.Center.Y + projectile.velocity.Y, projectile.velocity.X * 1.5f, projectile.velocity.Y * 1.5f, mod.ProjectileType("TrueDarkLancePro"), projectile.damage, projectile.knockBack * 0.85f, projectile.owner, 0f, 0f);
                }
            }
            if (Main.rand.Next(6) == 0)
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, 15, 0.0f, 0.0f, 150, new Color(), 1.4f);
                int dust_ = Dust.NewDust(projectile.position, projectile.width, projectile.height, 15, 0.0f, 0.0f, 150, new Color(), 1.4f);
                Main.dust[dust_].noGravity = true;
            }
            if (Main.rand.NextBool(1, 3))
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 205, projectile.velocity.X * 0.2f + (float)(projectile.direction * 3), projectile.velocity.Y * 0.2f, 100, new Color(), 1.2f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity.X /= 2f;
                Main.dust[dust].velocity.Y /= 2f;
                int dust1 = Dust.NewDust(projectile.position - projectile.velocity * 2f, projectile.width, projectile.height, 15, 0.0f, 0.0f, 150, new Color(), 1.4f);
                Main.dust[dust1].velocity.X /= 5f;
                Main.dust[dust1].velocity.Y /= 5f;
            }
        }
    }
}
