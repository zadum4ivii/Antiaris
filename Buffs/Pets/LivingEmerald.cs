using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Pets
{
	public class LivingEmerald : ModBuff
	{
	    public override void SetDefaults()
		{
			DisplayName.SetDefault("Living Emerald");
            Description.SetDefault("It's pretty bouncy!");
            DisplayName.AddTranslation(GameCulture.Chinese, "活翡翠");
            Description.AddTranslation(GameCulture.Chinese, "非常有弹性！");
            DisplayName.AddTranslation(GameCulture.Russian, "Живой изумруд");
            Description.AddTranslation(GameCulture.Russian, "Он неплохо прыгает!");
			Main.buffNoTimeDisplay[Type] = true;
			Main.lightPet[Type] = true;
		}

	    public override void Update(Player player, ref int buffIndex)
		{
			player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<AntiarisPlayer>(mod).livingEmerald = true;
			bool petProjectileNotSpawned = player.ownedProjectileCounts[mod.ProjectileType("LivingEmerald")] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
			{
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("LivingEmerald"), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}