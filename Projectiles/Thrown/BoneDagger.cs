using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Thrown
{
    public class BoneDagger : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 26;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.penetrate = 4;
            projectile.timeLeft = 600;
            projectile.extraUpdates = 1;
            aiType = 1;
			projectile.alpha = 100;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bone Dagger");
            DisplayName.AddTranslation(GameCulture.Chinese, "骸骨飞刀");
            DisplayName.AddTranslation(GameCulture.Russian, "Костяной клинок");
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 3;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			width = 10;
			height = 10;
			return true;
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

        public override void Kill(int timeLeft)
        {
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
            for (int k = 0; k < 8; k++)
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 1, projectile.oldVelocity.X * 0.2f, projectile.oldVelocity.Y * 0.2f);
			
			int item = Main.rand.Next(2) == 0 ? Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height, mod.ItemType("BoneDagger"), 1, false, 0, false, false) : 0;
			if (Main.netMode == 1 && item >= 0)
			{
				NetMessage.SendData(MessageID.SyncItem, -1, -1, null, item, 1f);
			}
        }
    }
}
