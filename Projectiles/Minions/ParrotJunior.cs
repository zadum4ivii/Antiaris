using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Minions
{
    public class ParrotJunior : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.Spazmamini);
            aiType = ProjectileID.Spazmamini;
            projectile.netImportant = true;
            projectile.width = 54;
            projectile.height = 42;
            Main.projFrames[projectile.type] = 4;
            projectile.friendly = true;
            projectile.minion = true;
            projectile.minionSlots = 1;
            projectile.penetrate = -1;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Parrot Junior");
            DisplayName.AddTranslation(GameCulture.Chinese, "鹦鹉宝宝");
            DisplayName.AddTranslation(GameCulture.Russian, "Маленький попугай");
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
        }

        public override void AI()
        {
            Player owner = null;
            if (projectile.owner != -1)
            {
                owner = Main.player[projectile.owner];
            }
            else if (projectile.owner == 255)
            {
                owner = Main.LocalPlayer;
            }
            var player = owner;
            var flag = projectile.type == mod.ProjectileType("ParrotJunior");
            var modPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
            if (flag)
            {
                if (player.dead)
                {
                    modPlayer.parrot = false;
                }
                if (modPlayer.parrot)
                {
                    projectile.timeLeft = 2;
                }
            }      
            projectile.rotation = projectile.velocity.X * 0.05f;
            if ((double)Math.Abs(projectile.velocity.X) > 0.2)
            {
                projectile.spriteDirection = -projectile.direction;
            }
            projectile.frameCounter++;
            if (projectile.frameCounter > 12)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame > 3)
            {
                projectile.frame = 0;
            }
            for (var k = 0; k < Main.rand.Next(1, 2); k++)
            {
                var dust = Dust.NewDust(new Vector2(projectile.position.X + 10f * -projectile.direction, projectile.position.Y), projectile.width, projectile.height, 59, projectile.velocity.X * 0.4f, projectile.velocity.Y * 0.4f, 100, Color.White, 1.5f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity.X += 1.2f * -projectile.direction;
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.velocity.X != oldVelocity.X)
            {
                projectile.velocity.X = oldVelocity.X;
            }
            if (projectile.velocity.Y != oldVelocity.Y)
            {
                projectile.velocity.Y = oldVelocity.Y;
            }
            return false;
        }
    }
}
