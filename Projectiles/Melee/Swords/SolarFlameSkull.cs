using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Melee.Swords
{
    public class SolarFlameSkull : ModProjectile
    {
        public override void SetDefaults()
        {
			projectile.width = 44;
			projectile.height = 80;
			projectile.aiStyle = 8;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.penetrate = 5;
			aiType = 502;
			Main.projFrames[projectile.type] = 4;
		}

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Solar Flame Skull");
            DisplayName.AddTranslation(GameCulture.Chinese, "日曜魔首");
            DisplayName.AddTranslation(GameCulture.Russian, "Череп солнечной вспышки");
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 8;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
			if (projectile.owner == Main.myPlayer)
            {
                int num220 = 3;
                for (int num221 = 0; num221 < num220; num221++)
                {
                    Vector2 value17 = new Vector2((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
                    value17.Normalize();
                    value17 *= (float)Main.rand.Next(200, 500) * 0.01f;
                    Projectile.NewProjectile(projectile.position.X, projectile.position.Y, value17.X, value17.Y, mod.ProjectileType("SolarFlameExplosion"), projectile.damage, 1f, projectile.owner, 0f, (float)Main.rand.Next(-45, 1));
                }
            }
			return true;
		}

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			width = 10;
			height = 10;
			return true;
		}

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        { 
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
            target.AddBuff(24, 60, false);
			if (projectile.owner == Main.myPlayer)
            {
                int num220 = 3;
                for (int num221 = 0; num221 < num220; num221++)
                {
                    Vector2 value17 = new Vector2((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
                    value17.Normalize();
                    value17 *= (float)Main.rand.Next(200, 500) * 0.01f;
                    Projectile.NewProjectile(projectile.position.X, projectile.position.Y, value17.X, value17.Y, mod.ProjectileType("SolarFlameExplosion"), projectile.damage, 1f, projectile.owner, 0f, (float)Main.rand.Next(-45, 1));
                }
            }
        }

        public override void AI()
        {
			projectile.frameCounter++;
            if (projectile.frameCounter > 2)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame >= 4)
            {
                projectile.frame = 0;
            }
            Lighting.AddLight(projectile.position, 0.9f, 0.9f, 0.1f);
        }
    }
}
