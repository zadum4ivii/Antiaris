using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.Projectiles.Ranged
{
    public class PurpleCrystalBullet : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 2; 
            projectile.height = 30;  
            projectile.aiStyle = 1;      
            projectile.friendly = true;       
            projectile.hostile = false;     
            projectile.ranged = true;      
            projectile.penetrate = 3;   
            projectile.timeLeft = 420;
            projectile.alpha = 255;
            projectile.ignoreWater = true;   
            projectile.tileCollide = true;      
            projectile.extraUpdates = 1;  
            aiType = ProjectileID.Bullet;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Purple Crystal Bullet");
            DisplayName.AddTranslation(GameCulture.Russian, "Фиолетовая кристальная пуля");
            DisplayName.AddTranslation(GameCulture.Chinese, "紫水晶弹");
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;   
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;   
        }

        public void OverhaulInit()
        {
            this.SetTag("bullet");
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			width = 10;
			height = 10;
			return true;
		}

        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 8; k++)
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 173, projectile.oldVelocity.X * 0.2f, projectile.oldVelocity.Y * 0.2f);
            Main.PlaySound(SoundID.Item10, projectile.position);
            if ((double)projectile.ai[0] == 0.0)
            {
                int numberProjectiles = 2;
                for (int i = 0; i < numberProjectiles; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(8.0f, 8.0f).RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(0, 360)));
                    Projectile.NewProjectile(projectile.position.X, projectile.position.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("PurpleCrystalBullet"), 0, 0.0f, projectile.owner, 1.0f, 0.0f);
                }
            }
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            for (int k = 0; k < projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
            }
            return true;
        }
    }
}
