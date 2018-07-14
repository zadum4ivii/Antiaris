using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Ranged.Arrows
{
    public class PurpleCrystalArrow : ModProjectile
    {
        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor) { AntiarisUtils.DrawProjectileGlowMaskWorld(spriteBatch, projectile, mod.GetTexture("Glow/" + GetType().Name + "_GlowMask2"), projectile.rotation, projectile.scale); }

        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 44;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.penetrate = 2;
            projectile.timeLeft = 600;
            projectile.extraUpdates = 1;
            aiType = 1;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Purple Crystal Arrow");
            DisplayName.AddTranslation(GameCulture.Russian, "Фиолетовая кристальная стрела");
            DisplayName.AddTranslation(GameCulture.Chinese, "紫水晶箭");
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 4;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			width = 10;
			height = 10;
			return true;
		}

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 0);
            for (int i = 0; i < 25; i++)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 173, projectile.oldVelocity.X * 0.2f, projectile.oldVelocity.Y * 0.2f);
            }
            int numberProjectiles = 2;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(8.0f, 8.0f).RotatedByRandom(MathHelper.ToRadians(Main.rand.Next(0, 360)));
                Projectile.NewProjectile(projectile.position.X, projectile.position.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("PurpleCrystalArrow2"), 0, 0.0f, projectile.owner, 0.0f, 0.0f);
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
