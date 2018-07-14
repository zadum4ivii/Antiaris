using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Ranged.Arrows
{
    public class SatArrow : ModProjectile
    {
        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor) { AntiarisUtils.DrawProjectileGlowMaskWorld(spriteBatch, projectile, mod.GetTexture("Glow/" + GetType().Name + "_GlowMask"), projectile.rotation, projectile.scale); }

        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 32;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 600;
            projectile.extraUpdates = 1;
            aiType = ProjectileID.Bullet;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sat Arrow");
            DisplayName.AddTranslation(GameCulture.Chinese, "Sat箭");
            DisplayName.AddTranslation(GameCulture.Russian, "Стрела Сата");
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 4;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			width = 10;
			height = 10;
			return true;
		}

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        { 
            target.AddBuff(BuffID.ShadowFlame, 180, false);
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
            projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
            projectile.width = 80;
            projectile.height = 80;
            projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);	
            for (int num628 = 0; num628 < 40; num628++)
            {
                int num629 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 62, 0f, 0f, 100, default(Color), 2f);
                Main.dust[num629].velocity *= 3f;
                if (Main.rand.Next(2) == 0)
                {
                    Main.dust[num629].scale = 0.5f;
                    Main.dust[num629].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
                }
            }	
            for (int num630 = 0; num630 < 70; num630++)
            {
                int num631 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 62, 0f, 0f, 100, default(Color), 3f);
                Main.dust[num631].noGravity = true;
                Main.dust[num631].velocity *= 5f;
                num631 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 62, 0f, 0f, 100, default(Color), 2f);
                Main.dust[num631].velocity *= 2f;
            }
            projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
            projectile.width = 10;
            projectile.height = 10;
            projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
            Player owner = null;
            if (projectile.owner != -1)
            {
                owner = Main.player[projectile.owner];
            }
            else if (projectile.owner == 255)
            {
                owner = Main.LocalPlayer;
            }
            var player = owner;
            var aPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
            if (projectile.owner == Main.myPlayer && aPlayer.SatBow)
            {
                int num220 = Main.rand.Next(1, 2);
                for (int num221 = 0; num221 < num220; num221++)
                {
                    Vector2 value17 = new Vector2((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
                    value17.Normalize();
                    value17 *= (float)Main.rand.Next(10, 201) * 0.01f;
                    Projectile.NewProjectile(projectile.position.X, projectile.position.Y, value17.X, value17.Y, mod.ProjectileType("ShadowFlame"), projectile.damage, 1f, projectile.owner, 0f, (float)Main.rand.Next(-45, 1));
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
