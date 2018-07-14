using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Minions
{
    public class StardustMothercell : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 60;
            projectile.height = 60;  
            projectile.hostile = false;  
            projectile.friendly = false;   
            projectile.ignoreWater = true; 
            projectile.timeLeft = 7200;  
            projectile.penetrate = -1; 
            projectile.tileCollide = true; 
            projectile.sentry = true;
            ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
			Main.projFrames[projectile.type] = 3;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stardust Mothercell");
            DisplayName.AddTranslation(GameCulture.Chinese, "星尘母体细胞");
            DisplayName.AddTranslation(GameCulture.Russian, "Материнская клетка звёздной пыли");
			Main.projPet[projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }

        public override void AI()
        {
			projectile.frameCounter++;
            if (projectile.frameCounter > 6)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame > 2)
            {
                projectile.frame = 0;
            }
			
            for (int i = 0; i < 200; i++)
            {
                NPC target = Main.npc[i];
                float shootToX = target.position.X + (float)target.width * 0.2f - projectile.Center.X;
                float shootToY = target.position.Y + (float)target.height * 0.2f - projectile.Center.Y;
                float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));
                if (distance < 520f && !target.friendly && target.active && !target.dontTakeDamage)
                {
                    if (projectile.ai[0] > 20f) // Time in ticks
                    {
                        distance = 10000f; // distance;
                        shootToX *= distance * 5;
                        shootToY *= distance * 5;
						Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, 624, 0, 0, projectile.owner, 0f, 0f);
                        Projectile.NewProjectile(projectile.Center.X + 1, projectile.Center.Y + 1, shootToX, shootToY, mod.ProjectileType("StardustEnergy"), projectile.damage, 165, projectile.owner, 0f, 0f);
                        projectile.ai[0] = 0f;
                    }
                }
            }
            projectile.ai[0] += 1f; 
        }
    }
}
