using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Melee.Swords
{
    public class TheClaymoreOfRedCrystalCentral : ModProjectile
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
			projectile.magic = true;
            aiType = 14;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Claymore Of Red Crystal");
            DisplayName.AddTranslation(GameCulture.Chinese, "红水晶之刃");
            DisplayName.AddTranslation(GameCulture.Russian, "Клеймор красного кристалла");
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
            var velocity = AntiarisHelper.VelocityToPoint(Main.MouseWorld, projectile.Center, 14);
            Projectile.NewProjectile(projectile.Center.X + Main.rand.Next(-150, 150), projectile.Center.Y + Main.rand.Next(-150, 150), velocity.X, velocity.Y, mod.ProjectileType("TheRedShard"), (int)(36 * player.meleeDamage), 6.0f, projectile.owner, 0.0f, 0.0f);
        }
    }
}
