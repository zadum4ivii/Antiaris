using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Minions
{
    public class Pixie2 : ModProjectile
    {
        public override Color? GetAlpha(Color lightColor) { return Color.White; }

        public override void SetDefaults()
        {
            projectile.netImportant = true;
            projectile.width = 36;
            projectile.height = 30;
            Main.projFrames[projectile.type] = 4;
            projectile.friendly = true;
            projectile.penetrate = 5;
            projectile.ignoreWater = true;
            projectile.timeLeft = 320;
            projectile.minion = true;
            projectile.tileCollide = false;
            projectile.aiStyle = -1;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pixie");
            DisplayName.AddTranslation(GameCulture.Chinese, "小精灵");
            DisplayName.AddTranslation(GameCulture.Russian, "Пикси");
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
            projectile.spriteDirection = (double)projectile.velocity.X <= 0.0 ? 1 : -1;
            projectile.rotation = projectile.velocity.X * 0.1f;
            if (Main.rand.Next(6) == 0)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 61, 0.0f, 0.0f, 200, default(Color), 1.0f);
                Main.dust[dust].velocity *= 0.3f;
            }
            if (Main.rand.Next(40) == 0)
                Main.PlaySound(27, (int)projectile.position.X, (int)projectile.position.Y, 1);
            if (projectile.tileCollide && WorldGen.SolidTile(Framing.GetTileSafely((int)projectile.Center.X / 16, (int)projectile.Center.Y / 16)))
                projectile.tileCollide = false;
            ++projectile.ai[0];
            Vector2 Position2;
            if ((double)projectile.ai[0] % 40.0 == 0.0)
            {
                Position2.X = Main.MouseWorld.X - 30f;
                Position2.Y = Main.MouseWorld.Y - 30f;
                Vector2 Vector = new Vector2(projectile.position.X + (projectile.width * 0.5f), projectile.position.Y + (projectile.height / 2));
                float Rotation = (float)Math.Atan2(Vector.Y - Position2.Y, Vector.X - Position2.X);
                projectile.velocity.X = (float)(Math.Cos(Rotation) * 6) * -1;
                projectile.velocity.Y = (float)(Math.Sin(Rotation) * 6) * -1;
            }
            Lighting.AddLight((int)projectile.position.X / 16, (int)projectile.position.Y / 16, 0.9f, 0.2f, 0.1f);
        }

        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 50; k++)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 61, 0.0f, -2.0f, 0, new Color(), 2.0f);
                Main.dust[dust].noGravity = true;
                Dust dust1 = Main.dust[dust];
                dust1.position.X = dust1.position.X + ((float)(Main.rand.Next(-50, 51) / 20) - 1.5f);
                Dust dust2 = Main.dust[dust];
                dust2.position.Y = dust2.position.Y + ((float)(Main.rand.Next(-50, 51) / 20) - 1.5f);
                if (Main.dust[dust].position != projectile.Center) Main.dust[dust].velocity = projectile.DirectionTo(Main.dust[dust].position) * 1.0f;
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
