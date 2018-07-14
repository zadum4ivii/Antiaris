using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Magic
{
    public class OrderEnergy : ModProjectile
    {
        public override Color? GetAlpha(Color lightColor) { return Color.White; }

        public override void SetDefaults()
        {
            projectile.width = 34;
            projectile.height = 90;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.aiStyle = 1;
			projectile.alpha = 255;
			projectile.penetrate = -1;
			projectile.extraUpdates = 1;
            projectile.timeLeft = 460;
			projectile.ignoreWater = true;
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = -1;
			projectile.scale = 0.8f;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Energy of Order");
			DisplayName.AddTranslation(GameCulture.Chinese, "秩序之力");
            DisplayName.AddTranslation(GameCulture.Russian, "Энергия порядка");
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
			Main.projFrames[projectile.type] = 1;
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			width = 10;
			height = 10;
			return true;
		}

        public override void AI()
        {
			if ((double)projectile.ai[0] >= 10.0) projectile.velocity.Y += 0.1f;
            if ((double)projectile.ai[0] >= 20.0) projectile.velocity.Y += 0.1f;
            if ((double)projectile.ai[0] > 20.0) projectile.ai[0] = 20f;
            projectile.velocity.X *= 0.99f;
            if ((double)projectile.velocity.Y > 32.0) projectile.velocity.Y = 32f;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			target.AddBuff(mod.BuffType("LightRage"), 160, false);
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            for (int k = 0; k < projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
				color.B = color.G = color.R = 150;
                spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
            }
            return true;
        }

        public override void Kill(int timeLeft)
		{
            for (int k = -1; k <= 1; k += 2) Projectile.NewProjectile(projectile.position, Vector2.Zero - new Vector2(-0.57f * -(float)k, 10.5f), mod.ProjectileType("Copy" + GetType().Name), (int)(projectile.damage * 0.8f), projectile.knockBack, projectile.owner, projectile.whoAmI);
            projectile.netUpdate = true;
		    for (int k = 0; k < 23; k++)
            {
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("Order"), 0.0f, 0.0f, 100, new Color(), 1f);
                Main.dust[dust].noGravity = true;
				Main.dust[dust].noLight = true;
                Main.dust[dust].velocity = projectile.velocity.RotatedBy(15 * (k + 2));
            }
			Main.PlayTrackedSound(SoundID.DD2_BetsyFireballImpact, projectile.position); 
		}
    }
}
