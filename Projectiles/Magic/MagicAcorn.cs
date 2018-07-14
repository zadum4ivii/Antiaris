using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Magic
{
    public class MagicAcorn : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(14);
            aiType = 14;
			projectile.magic = true;
            projectile.width = 2;
            projectile.height = 2;
            projectile.scale = 0.6f;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Acorn");
            DisplayName.AddTranslation(GameCulture.Chinese, "橡子");
            DisplayName.AddTranslation(GameCulture.Russian, "Жёлудь");
        }

        public override void Kill(int timeLeft)
        {
            if (Main.netMode != 2)
            {
                Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
                Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 1);
            }
            int a = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, mod.ProjectileType("AcornCreature"), projectile.damage, 1f, Main.myPlayer, 0f, 0f);
            Main.projectile[a].timeLeft = 600;
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
