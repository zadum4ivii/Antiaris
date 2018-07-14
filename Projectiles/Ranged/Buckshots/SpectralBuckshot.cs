using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.Projectiles.Ranged.Buckshots
{
    public class SpectralBuckshot : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 24;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.penetrate = 2;
            projectile.timeLeft = 180;
            projectile.extraUpdates = 1;
            projectile.alpha = 255;
			projectile.tileCollide = false;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 4;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            aiType = ProjectileID.Bullet;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spectral Buckshot");
            DisplayName.AddTranslation(GameCulture.Chinese, "幽灵火铳弹");
            DisplayName.AddTranslation(GameCulture.Russian, "Спектральная картечь");
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

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }

        public override void Kill(int timeLeft)
        {
            if (Main.netMode != 2)
            {
				for (int k = 0; k < 8; k++)
					Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 211, projectile.oldVelocity.X * 0.2f, projectile.oldVelocity.Y * 0.2f);
                Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        { 
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
            if (projectile.owner == Main.myPlayer && aPlayer.boilingPoint)
			{
				target.AddBuff(BuffID.OnFire, 120, false);
			}
			if (projectile.owner == Main.myPlayer && aPlayer.cherryBlossom)
			{
				target.AddBuff(BuffID.Poisoned, 120, false);
			}
			if (projectile.owner == Main.myPlayer && aPlayer.despairingFlames)
			{
				target.AddBuff(mod.BuffType("DespairingFlames"), 120, false);
			}
			if (projectile.owner == Main.myPlayer && aPlayer.thoriumBlunderbuss)
			{
				projectile.penetrate++;
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
