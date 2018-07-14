using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Melee.Swords
{
    public class TerriBlade : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 22;
            projectile.height = 66;
            projectile.aiStyle = 1;
            aiType = ProjectileID.Bullet;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            Main.projFrames[projectile.type] = 1;
            projectile.penetrate = 3;
            projectile.timeLeft = 43;
            projectile.tileCollide = false;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Terri Blade");
            DisplayName.AddTranslation(GameCulture.Chinese, "狂世界");
            DisplayName.AddTranslation(GameCulture.Russian, "Терри меч");
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 4;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

        public override void Kill(int timeLeft)
        {
            for (var i = 0; i < 6; ++i)
                Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y + 2f), projectile.width, projectile.height, 59, projectile.velocity.X * 0.24f, projectile.velocity.Y * 0.24f, 59, new Color(), 1.4f);
            for (var i = 0; i < 6; ++i)
                Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y + 2f), projectile.width, projectile.height, 62, projectile.velocity.X * 0.24f, projectile.velocity.Y * 0.24f, 62, new Color(), 1.4f);
            for (var i = 0; i < 6; ++i)
                Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y + 2f), projectile.width, projectile.height, 65, projectile.velocity.X * 0.24f, projectile.velocity.Y * 0.24f, 65, new Color(), 1.4f);
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            var drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            for(var k = 0; k < projectile.oldPos.Length; k++)
            {
                var drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                var color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
            }
            return true;
        }
    }
}
