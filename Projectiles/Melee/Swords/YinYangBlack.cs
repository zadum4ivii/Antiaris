using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Melee.Swords
{
    public class YinYangBlack : ModProjectile
    {
        public override Color? GetAlpha(Color lightColor) { return Color.White; }

        public override void SetDefaults()
        {
            projectile.width = 26;
            projectile.height = 22;
            projectile.penetrate = 4;
            projectile.scale = 1.0f;
            projectile.melee = true;
            projectile.friendly = true;
            projectile.timeLeft = 260;
            projectile.extraUpdates = 1;
            projectile.tileCollide = false;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Yin-Yang");
			DisplayName.AddTranslation(GameCulture.Chinese, "阴阳");
            DisplayName.AddTranslation(GameCulture.Russian, "Инь-Янь");
            Main.projFrames[projectile.type] = 1;
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
        {
            width = 4;
            height = 4;
            return true;
        }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            int byUUID = Projectile.GetByUUID(projectile.owner, (int)projectile.ai[0]);
            if (byUUID != -1)
            {
                if (Main.myPlayer != projectile.owner) return;
                var mainProj = Main.projectile[byUUID];
                if (!mainProj.active && mainProj.type != mod.ProjectileType("YinYang")) projectile.Kill();
                projectile.ai[1]++;
                float offset = (float)Math.Cos(projectile.ai[1] / 60 * Math.PI) * 50;
                projectile.rotation = mainProj.rotation;
                projectile.position = mainProj.position + ((float)projectile.rotation).ToRotationVector2() * offset;
                projectile.netUpdate = true;
            }
            for (int k = 0; k < 2; k++)
            {
                int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, mod.DustType(GetType().Name), projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, new Color(), 1.6f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity.X += 0.6f * projectile.spriteDirection;
            }
        }

        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 15; k++)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height,  mod.DustType(GetType().Name), (float)Main.rand.Next(-4, 4), (float)Main.rand.Next(-4, 4), 0, new Color(), 1.5f);
                Main.dust[dust].noGravity = true;
            }
        }
    }
}
