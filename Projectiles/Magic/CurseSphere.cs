using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Magic
{
    public class CurseSphere : ModProjectile
    {
        public override Color? GetAlpha(Color lightColor) { return Color.White; }

        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 14;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.aiStyle = 1;
			projectile.penetrate = 1;
            projectile.timeLeft = 760;
			projectile.extraUpdates = 1;
			aiType = ProjectileID.Bullet;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Curse Sphere");
            DisplayName.AddTranslation(GameCulture.Russian, "Сфера проклятия");
			DisplayName.AddTranslation(GameCulture.Chinese, "诅咒火球");
			Main.projFrames[projectile.type] = 1;
        }

        public override void AI()
        {
			if (projectile.alpha > 0) projectile.alpha--;
			projectile.spriteDirection = -projectile.direction;
			projectile.frameCounter++;
            if (projectile.frameCounter >= 4) { projectile.frame++; projectile.frameCounter = 0; }
            if (projectile.frame >= (int)Main.projFrames[projectile.type]) projectile.frame = 0;
            if (Main.rand.Next(1) == 0)
            {
                float x = projectile.velocity.X / 3f;
                float y = projectile.velocity.Y / 3f;
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 107, 0.0f, 0.0f, 0, new Color(), 1.6f);
                Main.dust[dust].position.X = projectile.Center.X - x;
                Main.dust[dust].position.Y = projectile.Center.Y - y;
                Main.dust[dust].velocity *= 0.0f;
                Main.dust[dust].noGravity = true;
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Cursed, Main.rand.Next(120, 340), true);
        }

        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 7; k++)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 107, (float)Main.rand.Next(-4, 4), (float)Main.rand.Next(-4, 4), 0, new Color(), 1.5f);
                Main.dust[dust].noGravity = true;
            }
        }
    }
}
