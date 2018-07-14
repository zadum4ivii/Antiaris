using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Bosses
{
    public class GolemCrystal2 : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 42;
            projectile.aiStyle = 1;
            aiType = ProjectileID.Bullet;
            projectile.friendly = false;
            projectile.ignoreWater = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 540;
            projectile.tileCollide = false;
            projectile.hostile = true;
			projectile.scale = 1.4f;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Golem Crystal");
            DisplayName.AddTranslation(GameCulture.Chinese, "魔像水晶");
            DisplayName.AddTranslation(GameCulture.Russian, "Кристалл голема");
        }

        public override void AI()
        {
            projectile.velocity.Y += projectile.ai[0];
            float count = 25.0f;
            if (projectile.timeLeft == 540)
            {
                for (int k = 0; (double)k < (double)count; k++)
                {
                    Vector2 vector2 = (Vector2.UnitX * 0.0f + -Vector2.UnitY.RotatedBy((double)k * (6.22 / (double)count), new Vector2()) * new Vector2(2.0f, 8.0f)).RotatedBy((double)projectile.velocity.ToRotation(), new Vector2());
                    int dust_ = Dust.NewDust(projectile.Center - new Vector2(0.0f, 4.0f), 0, 0, 62, 0.0f, 0.0f, 0, new Color(), 1.0f);
                    Main.dust[dust_].scale = 1.25f;
                    Main.dust[dust_].noGravity = true;
                    Main.dust[dust_].position = projectile.Center + vector2;
                    Main.dust[dust_].velocity = projectile.velocity * 0.0f + vector2.SafeNormalize(Vector2.UnitY) * 1.0f;
                }
            }
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
