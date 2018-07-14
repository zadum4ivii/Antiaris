using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Ranged
{
    public class ShadowFlame : ModProjectile
    {
        public override void SetDefaults()
        {
			projectile.height = 28;
			projectile.width = 44;
			projectile.penetrate = 1;
            projectile.friendly = true;
            projectile.timeLeft = 240;
            projectile.light = 0.8f;
            Main.projFrames[projectile.type] = 3;
            projectile.tileCollide = false;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shadow Flame");
            DisplayName.AddTranslation(GameCulture.Chinese, "暗影火");
            DisplayName.AddTranslation(GameCulture.Russian, "Теневой огонёк");
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			width = 10;
			height = 10;
			return true;
		}

        public override void AI()
        {
            projectile.velocity.X = 0f;
            projectile.velocity.Y = 0f;
            if (Main.rand.Next(2) == 0)
            {
                var dust = Dust.NewDust(projectile.position, projectile.width, projectile.height / 2, 62);
                Main.dust[dust].velocity.Y -= 1.2f;
            }
            projectile.frameCounter++;
            if (projectile.frameCounter > 2)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame > 2)
            {
                projectile.frame = 0;
            }
            //VANILLA CODE
            float num472 = projectile.Center.X;
            float num473 = projectile.Center.Y;
            float num474 = 400f;
            bool flag17 = false;
            for (int num475 = 0; num475 < 200; num475++)
            {
                if (Main.npc[num475].CanBeChasedBy(projectile, false) && Collision.CanHit(projectile.Center, 1, 1, Main.npc[num475].Center, 1, 1))
                {
                    float num476 = Main.npc[num475].position.X + (float)(Main.npc[num475].width / 2);
                    float num477 = Main.npc[num475].position.Y + (float)(Main.npc[num475].height / 2);
                    float num478 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num476) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num477);
                    if (num478 < num474)
                    {
                        num474 = num478;
                        num472 = num476;
                        num473 = num477;
                        flag17 = true;
                    }
                }
            }
            if (flag17)
            {
                float num483 = 60f;
                Vector2 vector35 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
                float num484 = num472 - vector35.X;
                float num485 = num473 - vector35.Y;
                float num486 = (float)Math.Sqrt((double)(num484 * num484 + num485 * num485));
                num486 = num483 / num486;
                num484 *= num486;
                num485 *= num486;
                projectile.velocity.X = (projectile.velocity.X * 20f + num484) / 21f;
                projectile.velocity.Y = (projectile.velocity.Y * 20f + num485) / 21f;
                return;
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        { 
            target.AddBuff(BuffID.ShadowFlame, 240, false);
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
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
