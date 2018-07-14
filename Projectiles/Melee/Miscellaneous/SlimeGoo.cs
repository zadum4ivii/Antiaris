using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Melee.Miscellaneous
{
	public class SlimeGoo : ModProjectile
	{
	    public override void SetDefaults()
		{
			projectile.scale = 1.2f;
			projectile.width = 16;
			projectile.height = 16;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = 3;
			projectile.melee = true;
			projectile.ignoreWater = true;
			aiType = ProjectileID.JavelinFriendly;
		}

	    public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Green Goo");
			DisplayName.AddTranslation(GameCulture.Russian, "Зеленая слизь");
            DisplayName.AddTranslation(GameCulture.Chinese, "绿色凝胶球");
		}

	    public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }

	    public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			width = 10;
			height = 10;
			return true;
		}

	    public override void AI()
        {
            for (var k = 0; k < 5; k++)
            {
                var dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 61, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, Color.White, 1.5f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity.X += 0.6f * -projectile.direction;
            }
        }

	    public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.penetrate--;
            if (projectile.penetrate <= 0)
            {
                projectile.Kill();
            }
            else
            {
                if (projectile.velocity.X != oldVelocity.X)
                {
                    projectile.velocity.X = -oldVelocity.X;
                }
                if (projectile.velocity.Y != oldVelocity.Y)
                {
                    projectile.velocity.Y = -oldVelocity.Y;
                }
                Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
            }
            return false;
        }

	    public override void Kill(int timeLeft)
		{
			Main.PlaySound(2, projectile.position, 10);
			for (var i = 0; i < 5; i++)
			{
		        Dust.NewDust(projectile.position, projectile.width, projectile.height, 61, projectile.velocity.X, projectile.velocity.Y);
			}
		}
	}
}
