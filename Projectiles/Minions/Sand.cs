using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Minions
{
    public class Sand : ModProjectile
    {               
        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 14;
            projectile.friendly = true;
            projectile.minion = true;
            projectile.penetrate = 3;
            projectile.timeLeft = 240;
            projectile.extraUpdates = 1;
			projectile.tileCollide = true;
            projectile.aiStyle = 1;
			projectile.scale = 1.4f;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 12;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }
		
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sand");
            DisplayName.AddTranslation(GameCulture.Chinese, "沙子");
            DisplayName.AddTranslation(GameCulture.Russian, "Песок");
        }	
		
		public override void AI()
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
            if (Main.rand.Next(10) == 0)
            {
                var dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 32, 0f, projectile.velocity.Y / 2f, 0, default(Color), 1f);
                var dust1 = Main.dust[dust];
                dust1.velocity.X = dust1.velocity.X * 0.4f;
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
		
		public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			width = 14;
			height = 14;
			return true;
		}

        public override void Kill(int timeLeft)
        {
            for (var k = 0; k < 8; k++)
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 32, projectile.oldVelocity.X * 0.2f, projectile.oldVelocity.Y * 0.2f);
            Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 1);
        }
    }
}