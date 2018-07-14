using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Melee.Yoyos
{
	class DarkBall : ModProjectile
	{
	    public float rot;
	    public Vector2 rotVec = new Vector2(0.0f, 50.0f);

	    public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.friendly = true;
			projectile.penetrate = 2;
            projectile.aiStyle = -1;
            projectile.timeLeft = 180;
            projectile.tileCollide = false;
			projectile.melee = true;
			projectile.scale = 1.0f;
            projectile.alpha = 0;
        }

	    public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dark Ball");
            DisplayName.AddTranslation(GameCulture.Chinese, "暗影球");
            DisplayName.AddTranslation(GameCulture.Russian, "Темный шар");
		}

	    public override void AI()
        {
            if (projectile.timeLeft <= 100) projectile.alpha += 2;
            this.rot -= 0.09f;
            for (var k = 0; k < 1; k++)
            {
                var dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 62, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, Color.White, 1.5f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity.X += 0.6f * -projectile.direction;
            }
            projectile.rotation += 0.05f / projectile.Opacity;
            Projectile projectile2 = Main.projectile[(int)projectile.ai[0]];
            if (!projectile2.active) projectile.Kill();
            projectile.Center = projectile2.Center + AntiarisHelper.RotateVector(new Vector2(), this.rotVec, this.rot + projectile.ai[1] * 0.628f);
            projectile.netUpdate = true;
        }
	}
}
