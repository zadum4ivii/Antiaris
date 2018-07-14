using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Magic
{
    public class EnchantedDagger : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 34;
            projectile.height = 34;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.penetrate = 3;
            projectile.timeLeft = 270;
            projectile.light = 0.75f;
            projectile.tileCollide = false;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Enchanted Dagger");
            DisplayName.AddTranslation(GameCulture.Chinese, "附魔的光短剑");
            DisplayName.AddTranslation(GameCulture.Russian, "Зачарованный клинок");
        }

        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation() + 1.57f;  
            if (Main.rand.Next(5) == 0)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 15, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            }
        }
    }
}
