using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Accessories
{
    public class CosmicMana : ModProjectile
    {
        public override Color? GetAlpha(Color lightColor) { return Color.White; }

        public override void SetDefaults()
        {
			projectile.width = 16;
			projectile.height = 16;
			projectile.tileCollide = true;
            projectile.aiStyle = 1;
			projectile.timeLeft = 145;
			projectile.alpha = 255;
            projectile.hostile = true;
            aiType = ProjectileID.Bullet;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cosmic Mana");
			DisplayName.AddTranslation(GameCulture.Chinese, "宇宙魔力");
            DisplayName.AddTranslation(GameCulture.Russian, "Космическая мана");
        }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            projectile.rotation += projectile.velocity.X * 0.2f;
            if (player.active && ((double)Vector2.Distance(player.Center, projectile.Center) < 25.0))
            {
                int newMana = Main.rand.Next(4, 10);
                player.statMana += newMana;
                player.ManaEffect(newMana);
                projectile.Kill();
            }
            if (projectile.soundDelay == 0)
            {
                projectile.soundDelay = 20 + Main.rand.Next(40);
                Main.PlaySound(SoundID.Item9, projectile.position);
            }
            for (int k = 0; k < 1; k++) Dust.NewDust(projectile.position, projectile.width, projectile.height, 62, projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 150, new Color(), 1.2f);
        }

        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 15; k++)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 62, (float)Main.rand.Next(-4, 4), (float)Main.rand.Next(-4, 4), 0, new Color(), 1.2f);
                Main.dust[dust].noGravity = true;
            }
        }
    }
}
