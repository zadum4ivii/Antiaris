using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Melee.Swords
{
    public class CelestialMagicCentral : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 60;
            projectile.height = 60;
            projectile.aiStyle = 0;
            projectile.melee = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 10;
            projectile.tileCollide = false;
            aiType = 14;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Celestial Flame");
            DisplayName.AddTranslation(GameCulture.Chinese, "神圣火焰");
            DisplayName.AddTranslation(GameCulture.Russian, "Небесное пламя");
        }

        public override void AI()
        {
            var player = Main.player[projectile.owner];
            if (Main.myPlayer != projectile.owner)
                return;
            projectile.netUpdate = true;
        }

        public override void Kill(int timeLeft)
        {
            var velocity = AntiarisHelper.VelocityToPoint(projectile.Center, Main.MouseWorld, 4);
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, velocity.X, velocity.Y, mod.ProjectileType("CelestialMagic"), projectile.damage, projectile.knockBack * 0.5f, projectile.owner);
        }
    }
}
