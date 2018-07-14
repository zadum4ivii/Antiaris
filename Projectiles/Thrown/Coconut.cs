using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Projectiles.Thrown
{
	public class Coconut : ModProjectile
	{
	    public override void SetDefaults()
		{
			projectile.width = 44;
			projectile.height = 40;
			projectile.friendly = true;
			projectile.thrown = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 130;
			projectile.aiStyle = 2;
			aiType = ProjectileID.Shuriken;
		}

	    public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Coconut");
            DisplayName.AddTranslation(GameCulture.Chinese, "椰子");
            DisplayName.AddTranslation(GameCulture.Russian, "Кокос");
        }

	    public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			width = 10;
			height = 10;
			return true;
		}

	    public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Dig, projectile.position);
            Gore.NewGore(projectile.position, Main.rand.NextVector2Unit() * 2f, mod.GetGoreSlot("Gores/CoconutGore1"));
            Gore.NewGore(projectile.position, Main.rand.NextVector2Unit() * 2f, mod.GetGoreSlot("Gores/CoconutGore2"));
            Gore.NewGore(projectile.position, Main.rand.NextVector2Unit() * 2f, mod.GetGoreSlot("Gores/CoconutGore3"));
			for (int k = 0; k < 8; k++)
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 7, projectile.oldVelocity.X * 0.2f, projectile.oldVelocity.Y * 0.2f);
        }
	}
}
