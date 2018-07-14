using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Melee.Yoyos
{
    public class PrescriptionProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(189);
			projectile.height = 16;
			projectile.width = 16;
			projectile.penetrate = 2;
            projectile.friendly = true;
            projectile.timeLeft = 240;
            projectile.light = 0.8f;
			projectile.damage = 38;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Prescription");
            DisplayName.AddTranslation(GameCulture.Chinese, "处方药");
            DisplayName.AddTranslation(GameCulture.Russian, "Рецепт");
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
            int newLife = Main.rand.Next(3, 6);
            player.statLife += newLife;
            player.HealEffect(newLife);
            NetMessage.SendData(MessageID.SpiritHeal, -1, -1, null, projectile.owner, newLife);
	    	for (int num158 = 0; num158 < 20; num158++)
		    {
		    	int num159 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 62, projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 0, default(Color), 0.3f);
		    	if (Main.rand.Next(3) == 0)
		    	{
		    		Main.dust[num159].fadeIn = 1.1f + (float)Main.rand.Next(-10, 11) * 0.01f;
		    		Main.dust[num159].scale = 0.35f + (float)Main.rand.Next(-10, 11) * 0.01f;
		    		Main.dust[num159].type++;
		    	}
		    	else
		    	{
				Main.dust[num159].scale = 1.2f + (float)Main.rand.Next(-10, 11) * 0.01f;
		    	}
		    	Main.dust[num159].noGravity = true;
		    	Main.dust[num159].velocity *= 2.5f;
		    	Main.dust[num159].velocity -= projectile.oldVelocity / 10f;
		    }
		    if (Main.myPlayer == projectile.owner)
		    {
		        int num160 = Main.rand.Next(0, 0);
			    for (int num161 = 0; num161 < num160; num161++)
			    {
			    	Vector2 value12 = new Vector2((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
			    	while (value12.X == 0f && value12.Y == 0f)
			    	{
			    		value12 = new Vector2((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
			    	}
			    	value12.Normalize();
			    	value12 *= (float)Main.rand.Next(70, 101) * 0.1f;
			    	Projectile.NewProjectile(projectile.oldPosition.X + (float)(projectile.width / 2), projectile.oldPosition.Y + (float)(projectile.height / 2), value12.X, value12.Y, 400, (int)((double)projectile.damage * 0.8), projectile.knockBack * 2.8f, projectile.owner, 0f, 0f);
			    }
		    }
        }
    }
}
