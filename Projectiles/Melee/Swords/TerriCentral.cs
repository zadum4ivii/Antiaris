using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Melee.Swords
{
    public class TerriCentral : ModProjectile
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
            DisplayName.SetDefault("True Celestial Magic");
            DisplayName.AddTranslation(GameCulture.Chinese, "真·神圣魔法");
            DisplayName.AddTranslation(GameCulture.Russian, "Истинная небесная магия");
        }

        public override void AI()
        {
            var player = Main.player[projectile.owner];
            if (Main.myPlayer != projectile.owner)
                return;
            Vector2 vector;
            vector.X = Main.MouseWorld.X - 30f;
            vector.Y = Main.MouseWorld.Y - 30f;
            projectile.netUpdate = true;
            projectile.position = vector;
        }

        public override void Kill(int timeLeft)
        {
            var player = Main.player[projectile.owner];
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 100f, 0.0f, 0.1f, mod.ProjectileType("TerriFiend"), (int)(94 * (double)player.meleeDamage), 8f, projectile.owner, 0.0f, 0.0f);
            Projectile.NewProjectile(projectile.Center.X - 100f, projectile.Center.Y, 0.1f, 0.0f, mod.ProjectileType("TerriFiend"), (int)(94 * (double)player.meleeDamage), 8f, projectile.owner, 0.0f, 0.0f);
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y + 100f, 0.0f, -0.1f, mod.ProjectileType("TerriFiend"), (int)(94 * (double)player.meleeDamage), 8f, projectile.owner, 0.0f, 0.0f);
            Projectile.NewProjectile(projectile.Center.X + 100f, projectile.Center.Y, -0.1f, 0.0f, mod.ProjectileType("TerriFiend"), (int)(94 * (double)player.meleeDamage), 8f, projectile.owner, 0.0f, 0.0f);
            Projectile.NewProjectile(projectile.Center.X - 75f, projectile.Center.Y - 75f, 0.1f, 0.1f, mod.ProjectileType("TerriFiend"), (int)(94 * (double)player.meleeDamage), 8f, projectile.owner, 0.0f, 0.0f);
            Projectile.NewProjectile(projectile.Center.X + 75f, projectile.Center.Y + 75f, -0.1f, -0.1f, mod.ProjectileType("TerriFiend"), (int)(94 * (double)player.meleeDamage), 8f, projectile.owner, 0.0f, 0.0f);
            Projectile.NewProjectile(projectile.Center.X - 75f, projectile.Center.Y + 75f, 0.1f, -0.1f, mod.ProjectileType("TerriFiend"), (int)(94 * (double)player.meleeDamage), 8f, projectile.owner, 0.0f, 0.0f);
            Projectile.NewProjectile(projectile.Center.X + 75f, projectile.Center.Y - 75f, -0.1f, 0.1f, mod.ProjectileType("TerriFiend"), (int)(94 * (double)player.meleeDamage), 8f, projectile.owner, 0.0f, 0.0f);
        }
    }
}
