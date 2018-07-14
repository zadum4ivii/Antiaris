using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Pets
{
	public class SnowOwl : ModBuff
	{
	    public override void SetDefaults()
		{
			DisplayName.SetDefault("Snow Owl");
            Description.SetDefault("Sadly, it doesn't carry any letters!");
            DisplayName.AddTranslation(GameCulture.Chinese, "雪鹰");
            Description.AddTranslation(GameCulture.Chinese, "遗憾的是，它没有携带任何信件！");
            DisplayName.AddTranslation(GameCulture.Russian, "Снежная сова");
            Description.AddTranslation(GameCulture.Russian, "Увы, она не не принесла никаких писем!");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

	    public override void Update(Player player, ref int buffIndex)
		{
			player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<AntiarisPlayer>(mod).snowOwl = true;
			bool petProjectileNotSpawned = player.ownedProjectileCounts[mod.ProjectileType("SnowOwl")] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
			{
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("SnowOwl"), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}