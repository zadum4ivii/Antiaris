using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Magic
{
    public class RubyRoseBolt : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 4;
            projectile.height = 4;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.penetrate = 4;
            projectile.timeLeft = 600;
            projectile.extraUpdates = 1;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 2;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            aiType = ProjectileID.Bullet;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ruby Rose Bolt");
            DisplayName.AddTranslation(GameCulture.Chinese, "卢比箭");
            DisplayName.AddTranslation(GameCulture.Russian, "Снаряд рубиновой розы");
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
        {
            width = 10;
            height = 10;
            return true;
        }

        public override void AI()
        {
            for (var i = 0; i < 10; i++)
            {
                var x = projectile.Center.X - projectile.velocity.X / 10f * (float)i;
                var y = projectile.Center.Y - projectile.velocity.Y / 10f * (float)i;
                var dust = Dust.NewDust(new Vector2(x, y), 1, 1, 60, 0f, 0f, 0, default(Color), 2f);
                Main.dust[dust].alpha = projectile.alpha;
                Main.dust[dust].position.X = x;
                Main.dust[dust].position.Y = y;
                Main.dust[dust].velocity *= 0f;
                Main.dust[dust].noGravity = true;
            }
        }


        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            --projectile.penetrate;
            if (projectile.penetrate <= 0)
            {
                projectile.Kill();
            }
            else
            {
                projectile.ai[0] += 0.1f;
                if ((double)projectile.velocity.X != (double)oldVelocity.X)
                {
                    projectile.velocity.X = -oldVelocity.X;
                }
                if ((double)projectile.velocity.Y != (double)oldVelocity.Y)
                {
                    projectile.velocity.Y = -oldVelocity.Y;
                }
                Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10, 1f, 0.0f);
                for (int k = 0; k < 15; ++k)
                {
                    int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y + 2f), projectile.width + 5, projectile.height + 5, 60, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, new Color(), 1.8f);
                    Main.dust[dust].noGravity = true;
                }
            }
            return false;
        }

        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 15; ++k)
            {
                int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y + 2f), projectile.width + 5, projectile.height + 5, 60, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, new Color(), 1.8f);
                Main.dust[dust].noGravity = true;
            }
            Main.PlaySound(SoundID.Item10, projectile.position);
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
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
            if (Main.rand.Next(2) == 0)
            {
                int newLife = projectile.damage / 5;
                if (Main.rand.Next(3) == 0)
                {
                    newLife = projectile.damage / 4;
                }
                player.statLife += newLife;
                player.HealEffect(newLife);
                NetMessage.SendData(MessageID.SpiritHeal, -1, -1, null, projectile.owner, newLife);
            }
            projectile.ai[0] += 0.1f;
            projectile.velocity *= 0.75f;
        }
    }
}
