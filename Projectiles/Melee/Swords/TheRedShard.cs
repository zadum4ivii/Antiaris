using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Melee.Swords
{
    public class TheRedShard : ModProjectile
    {
        public override Color? GetAlpha(Color lightColor) { return Color.White; }

        public override void SetDefaults()
        {
            projectile.width = 26;
            projectile.height = 50;
            projectile.aiStyle = 1;
            aiType = ProjectileID.Bullet;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            Main.projFrames[projectile.type] = 1;
            projectile.penetrate = 5;
            projectile.timeLeft = 145;
            projectile.tileCollide = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Red Shard");
            DisplayName.AddTranslation(GameCulture.Chinese, "红水晶碎刃");
            DisplayName.AddTranslation(GameCulture.Russian, "Красный осколок");
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 6;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
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

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			width = 10;
			height = 10;
			return true;
		}

        public override void Kill(int timeLeft)
        {
            for (var k = 0; k < 18; k++)
            {
                var dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width + 5, projectile.height + 5, 60, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, new Color(), 1.4f);
                Main.dust[dust].noGravity = true;
            }
        }
    }
}
