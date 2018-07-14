using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Thrown
{
	public class RoyalDagger : ModProjectile
	{
	    public override void SetDefaults()
		{
			Main.projFrames[projectile.type] = 3;
			projectile.width = 14;
			projectile.height = 44;
			projectile.friendly = true;
			projectile.thrown = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 600;
			projectile.aiStyle = 2;
            aiType = 48;
        }

	    public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Royal Dagger");
            DisplayName.AddTranslation(GameCulture.Chinese, "皇家飞刀");
            DisplayName.AddTranslation(GameCulture.Russian, "Королевский клинок");
        }

	    public override void AI()
        {
            projectile.frameCounter++;
            if (projectile.frameCounter > 3)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame >= 3)
            {
                projectile.frame = 0;
            }
		}

	    public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			width = 10;
			height = 10;
			return true;
		}

	    public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(2) == 0)
            {
                target.AddBuff(BuffID.Midas, 100);
            }
            projectile.velocity.X = -projectile.velocity.X;
            projectile.velocity.Y = -projectile.velocity.Y;
            Main.PlaySound(SoundID.Item10, projectile.position);
        }

	    public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item10, projectile.position);
            for (var k = 0; k < 8; k++)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 59, projectile.oldVelocity.X * 0.2f, projectile.oldVelocity.Y * 0.2f);
            }
        }
	}
}