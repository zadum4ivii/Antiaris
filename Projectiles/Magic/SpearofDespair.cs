using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Magic
{
	public class SpearofDespair : ModProjectile
	{
	    public override void PostDraw(SpriteBatch spriteBatch, Color lightColor) { AntiarisUtils.DrawProjectileGlowMaskWorld(spriteBatch, projectile, mod.GetTexture("Glow/" + GetType().Name + "_GlowMask"), projectile.rotation, projectile.scale); }

	    public override void SetDefaults()
		{
			projectile.scale = 1.2f;
			projectile.width = 18;
			projectile.height = 52;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = 3;
			projectile.magic = true;
			projectile.ignoreWater = true;
			aiType = ProjectileID.JavelinFriendly;
		}

	    public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spear of Despair");
			DisplayName.AddTranslation(GameCulture.Russian, "Копьё отчаяния");
            DisplayName.AddTranslation(GameCulture.Chinese, "绝望");
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 8;
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
			Main.PlaySound(2, projectile.position, 10);
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, mod.ProjectileType("DespairBall"), projectile.damage, 1f, projectile.owner, 0f, 0f);
			for (var i = 0; i < 5; i++)
			{
		        Dust.NewDust(projectile.position, projectile.width, projectile.height, 62, projectile.velocity.X, projectile.velocity.Y);
			}
		}

	    public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            for(int k = 0; k < projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
            }
            return true;
        }
	}
}
