using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Pets
{
	public class Snowflake : ModBuff
	{
	    public override void SetDefaults()
		{
			DisplayName.SetDefault("Snowflake");
            Description.SetDefault("Looks pretty cold!");
            DisplayName.AddTranslation(GameCulture.Chinese, "雪花");
            Description.AddTranslation(GameCulture.Chinese, "看起来非常冷！");
            DisplayName.AddTranslation(GameCulture.Russian, "Снежинка");
            Description.AddTranslation(GameCulture.Russian, "Выглядит достаточно холодной!");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

	    public override void Update(Player player, ref int buffIndex)
		{
			player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<AntiarisPlayer>(mod).snowflake = true;
			bool petProjectileNotSpawned = player.ownedProjectileCounts[mod.ProjectileType("Snowflake")] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
			{
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("Snowflake"), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}