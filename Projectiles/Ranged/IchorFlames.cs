using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Ranged
{
    public class IchorFlames : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 12;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.ranged = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 60;
            projectile.extraUpdates = 3;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ichor Flames");
            DisplayName.AddTranslation(GameCulture.Chinese, "脓血烈焰");
            DisplayName.AddTranslation(GameCulture.Russian, "Ихоровое пламя");
        }

        public override void AI()
        {
            Lighting.AddLight(projectile.Center, ((255 - projectile.alpha) * 0.15f) / 255f, ((255 - projectile.alpha) * 0.45f) / 255f, ((255 - projectile.alpha) * 0.05f) / 255f);   
            if (projectile.timeLeft > 60)
            {
                projectile.timeLeft = 60;
            }
            if (projectile.ai[0] > 6f)  //this defines where the flames starts
            {
                if (Main.rand.Next(2) == 0)     //this defines how many dust to spawn
                {
                    int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 159, projectile.velocity.X * 1.2f, projectile.velocity.Y * 1.2f);
					Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 2.5f;
					Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 159, projectile.oldVelocity.X * 0.2f, projectile.oldVelocity.Y * 0.2f);
                    Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 159, projectile.velocity.X * 1.2f, projectile.velocity.Y * 1.2f, 130, default(Color), 1.5f);
                }
            }
            else
            {
                projectile.ai[0] += 1f;
            }
            return;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Ichor, 180); 
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return false;
        }
    }
}