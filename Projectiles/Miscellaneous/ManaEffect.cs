using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Miscellaneous
{
    public class ManaEffect : ModProjectile
    {
        public override void SetDefaults()
        {
			projectile.width = 16;
			projectile.height = 16;
			projectile.aiStyle = -1;
			projectile.tileCollide = false;
			projectile.timeLeft = 360;
			projectile.alpha = 255;
            projectile.hostile = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mana Energy");
            DisplayName.AddTranslation(GameCulture.Russian, "Энергия маны");
            DisplayName.AddTranslation(GameCulture.Chinese, "魔力能量");
            Main.projFrames[projectile.type] = 1;
        }

        public override void AI()
        {
            --projectile.ai[1];
            if ((double)projectile.ai[1] <= 0.0)
            {
                projectile.ai[1] = 0.0f;
                projectile.velocity.X = projectile.velocity.Y = 0.0f;
            }
            int owner = projectile.owner;
            Vector2 vector2 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
            float x = Main.player[owner].Center.X - vector2.X;
            float y = Main.player[owner].Center.Y - vector2.Y;
            float distance = (float)Math.Sqrt((double)x * (double)x + (double)y * (double)y);
            float speed = 70.0f;
            float velocity = speed / distance;
            float velocityX = x * velocity;
            float velocityY = y * velocity;
            projectile.velocity.X = (float)(((double)projectile.velocity.X * 15.0 + (double)velocityX) / 16.0);
            projectile.velocity.Y = (float)(((double)projectile.velocity.Y * 15.0 + (double)velocityY) / 16.0);
            if ((double)distance < 50.0 && (double)projectile.position.X < (double)Main.player[owner].position.X + (double)Main.player[owner].width && ((double)projectile.position.X + (double)projectile.width > (double)Main.player[owner].position.X && (double)projectile.position.Y < (double)Main.player[owner].position.Y + (double)Main.player[owner].height) && (double)projectile.position.Y + (double)projectile.height > (double)Main.player[owner].position.Y)
            {
                if (projectile.owner == Main.myPlayer)
                {
                    int manaAmount = (int)projectile.ai[0];
                    Main.player[owner].ManaEffect(manaAmount);
                    Main.player[owner].statMana += manaAmount;
                    NetMessage.SendData(66, -1, -1, null, owner, (float)manaAmount, 0.0f, 0.0f, 0, 0, 0);
                }
                projectile.Kill();
            }
            for (int k = 0; k < 4; k++)
            {
                int dust = Dust.NewDust(projectile.Center, projectile.width, projectile.height, 62, 0.0f, 0.0f, 100, new Color(), 1f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].position += new Vector2(4f);
                Main.dust[dust].scale += Main.rand.NextFloat() * 1f;
            }
        }
    }
}
