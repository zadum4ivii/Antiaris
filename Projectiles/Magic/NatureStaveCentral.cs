using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Magic
{
    public class NatureStaveCentral : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 60;
            projectile.height = 60;
            projectile.aiStyle = 0;
            projectile.magic = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 10;
            projectile.tileCollide = false;
			projectile.magic = true;
            aiType = 14;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nature Magic");
            DisplayName.AddTranslation(GameCulture.Chinese, "自然魔法");
            DisplayName.AddTranslation(GameCulture.Russian, "Магия природы");
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
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 75f, 0.0f, 0.2f, mod.ProjectileType("NatureMagic"), (int)(15 * player.magicDamage), 3.0f, projectile.owner, 0.0f, 0.0f);
            Projectile.NewProjectile(projectile.Center.X - 75f, projectile.Center.Y, 0.2f, 0.0f, mod.ProjectileType("NatureMagic"), (int)(15 * player.magicDamage), 3.0f, projectile.owner, 0.0f, 0.0f);
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y + 75f, 0.0f, -0.2f, mod.ProjectileType("NatureMagic"), (int)(15 * player.magicDamage), 3.0f, projectile.owner, 0.0f, 0.0f);
            Projectile.NewProjectile(projectile.Center.X + 75f, projectile.Center.Y, -0.2f, 0.0f, mod.ProjectileType("NatureMagic"), (int)(15 * player.magicDamage), 3.0f, projectile.owner, 0.0f, 0.0f);
        }
    }
}
