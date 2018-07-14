using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Ranged
{
    public class CrystalEnergy : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.penetrate = 2;
            projectile.timeLeft = 150;
            projectile.extraUpdates = 1;
            projectile.alpha = 255;
            aiType = ProjectileID.Bullet;
        }
		
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystal Energy");
			DisplayName.AddTranslation(GameCulture.Chinese, "水晶能量");
            DisplayName.AddTranslation(GameCulture.Russian, "Кристальная энергия");
            Main.projFrames[projectile.type] = 1;
        }

        public override void AI()
        {
            if ((double)projectile.ai[0] == 0.0)
            {
                float count = 25.0f;
                for (int k = 0; (double)k < (double)count; k++)
                {
                    Vector2 vector2 = (Vector2.UnitX * 0.0f + -Vector2.UnitY.RotatedBy((double)k * (6.22 / (double)count), new Vector2()) * new Vector2(2.0f, 8.0f)).RotatedBy((double)projectile.velocity.ToRotation(), new Vector2());
                    int dust = Dust.NewDust(projectile.Center - new Vector2(0.0f, 4.0f), 0, 0, 90, 0.0f, 0.0f, 0, new Color(), 1.0f);
                    Main.dust[dust].scale = 1.25f;
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].position = projectile.Center + vector2;
                    Main.dust[dust].velocity = projectile.velocity * 0.0f + vector2.SafeNormalize(Vector2.UnitY) * 1.0f;
                }
                ++projectile.ai[0];
                projectile.netUpdate = true;
            }
            for (int k = 0; k < 2; k++)
            {
                int dust = Dust.NewDust(projectile.Center, projectile.width, projectile.height, 90, 0.0f, 0.0f, 100, new Color(), 1f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].position += new Vector2(4f);
                Main.dust[dust].scale += Main.rand.NextFloat() * 1f;
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            var owner = projectile.owner;
            int healAmount = Main.rand.Next(1, 4);
            Main.player[owner].HealEffect(healAmount, false);
            Main.player[owner].statLife += healAmount;
            if (Main.player[owner].statLife > Main.player[owner].statLifeMax2)
                Main.player[owner].statLife = Main.player[owner].statLifeMax2;
            NetMessage.SendData(66, -1, -1, null, owner, (float)healAmount, 0.0f, 0.0f, 0, 0, 0);
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			width = 10;
			height = 10;
			return true;
		}
    }
}
