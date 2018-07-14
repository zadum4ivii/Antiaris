using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Enemies
{
    public class EmeraldSlimeSpike : ModProjectile
    {
        public override void SetDefaults()
        {
			projectile.alpha = (int)byte.MaxValue; //or 255
			projectile.width = 6;
			projectile.height = 6;
			projectile.aiStyle = 1;
			projectile.hostile = true;
			projectile.penetrate = -1;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Emerald Slime Spike");
            DisplayName.AddTranslation(GameCulture.Chinese, "翡绿史莱姆尖刺");
            DisplayName.AddTranslation(GameCulture.Russian, "Шип изумрудного слизня");
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }

        public override void AI()
		{
		    if (projectile.alpha == 0)
			{
				var index = Dust.NewDust(projectile.oldPosition - projectile.velocity * 3f, projectile.width, projectile.height, 61, 0.0f, 0.0f, 50, new Color(), 1f);
				Main.dust[index].noGravity = true;
				Main.dust[index].noLight = true;
				Main.dust[index].velocity *= 0.5f;
			}
			projectile.alpha -= 50;
			if (projectile.alpha < 0)
				projectile.alpha = 0;
			if ((double)projectile.ai[1] == 0.0)
			{
				projectile.ai[1] = 1f;
				Main.PlaySound(SoundID.Item17, projectile.position);
			}
			if ((double)projectile.ai[0] >= 5.0)
			{
				projectile.ai[0] = 5f;
				projectile.velocity.Y += 0.15f;
			}
		}
    }
}
