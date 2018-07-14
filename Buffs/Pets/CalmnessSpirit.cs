using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Pets
{
	public class CalmnessSpirit : ModBuff
	{
	    public override void SetDefaults()
		{
			DisplayName.SetDefault("Calmness Spirit");
			Description.SetDefault("A calmness spirit is following you");
			DisplayName.AddTranslation(GameCulture.Chinese, "宁静灵魂");
			Description.AddTranslation(GameCulture.Chinese, "宁静灵魂在追随着你");
            DisplayName.AddTranslation(GameCulture.Russian, "Дух спокойствия");
            Description.AddTranslation(GameCulture.Russian, "Дух спокойствия следует за вами");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

	    public override void Update(Player player, ref int buffIndex)
		{
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<AntiarisPlayer>(mod).calmnessSpirit = true;
            bool spawned = true;
            if (player.ownedProjectileCounts[mod.ProjectileType("CalmnessSpirit")] > 0)
                spawned = false;
            if (!spawned || player.whoAmI != Main.myPlayer)
                return;
            Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0.0f, 0.0f, mod.ProjectileType("CalmnessSpirit"), 0, 0.0f, player.whoAmI, 0.0f, 0.0f);
        }
	}
}