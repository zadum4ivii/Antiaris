using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Minions
{
    public class AntlionSummon : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.netImportant = true;
            projectile.width = 66;
            projectile.height = 42;
            projectile.damage = 0;
            Main.projFrames[projectile.type] = 2;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 2400;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Antlion Swarmer");
            DisplayName.AddTranslation(GameCulture.Chinese, "蚁狮蜂");
            DisplayName.AddTranslation(GameCulture.Russian, "Взрослый муравьиный лев");
        }

        public override void AI()
        {
			projectile.frameCounter++;
            if (projectile.frameCounter > 4)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame > 3)
            {
                projectile.frame = 0;
            }
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
            var aPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
            if (player.dead || !aPlayer.swarmerS)
            {
                projectile.Kill();
            }
            projectile.friendly = true;
            var speed = 8f;
            if (projectile.ai[0] == 1f)
            {
                speed = 12f;
            }
            var projCenter = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
            var posX = player.Center.X - projCenter.X;
            var posY = player.Center.Y - projCenter.Y - 60f;
            var distance = (float)Math.Sqrt((double)(posX * posX + posY * posY));
            if (distance < 100f && projectile.ai[0] == 1f && !Collision.SolidCollision(projectile.position, projectile.width, projectile.height))
            {
                projectile.ai[0] = 0f;
            }
            if (distance > 2000f)
            {
                projectile.position.X = Main.player[projectile.owner].Center.X - (float)(projectile.width / 2);
                projectile.position.Y = Main.player[projectile.owner].Center.Y - (float)(projectile.width / 2);
            }
            if (distance > 70f)
            {
                distance = speed / distance;
                posX *= distance;
                posY *= distance;
                projectile.velocity.X = (projectile.velocity.X * 20f + posX) / 21f;
                projectile.velocity.Y = (projectile.velocity.Y * 20f + posY) / 21f;
            }
            else
            {
                if (projectile.velocity.X == 0f && projectile.velocity.Y == 0f)
                {
                    projectile.velocity.X = -0.15f;
                    projectile.velocity.Y = -0.05f;
                }
                projectile.velocity *= 1.01f;
            }
            projectile.friendly = false;
            projectile.rotation = projectile.velocity.X * 0.1f;
            projectile.frameCounter++;
            if (projectile.frameCounter >= 3)
            {
                projectile.frameCounter = 0;
                projectile.frame++;
            }
            if (projectile.frame > 1)
            {
                projectile.frame = 0;
            }
            if ((double)Math.Abs(projectile.velocity.X) > 0.2)
            {
                projectile.spriteDirection = -projectile.direction;
                return;
            }
        }

        public override void Kill(int timeLeft)
        {
            for (var i = 0; i < 20; i++)
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, 64, projectile.velocity.X, projectile.velocity.Y);
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
