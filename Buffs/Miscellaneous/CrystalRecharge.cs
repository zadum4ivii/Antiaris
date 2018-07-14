using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Miscellaneous
{
	public class CrystalRecharge : ModBuff
	{
	    public override void SetDefaults()
		{
            DisplayName.SetDefault("Crystal Recharge");
            Description.SetDefault("The crystal must regain control over the powers of time");
            DisplayName.AddTranslation(GameCulture.Chinese, "水晶蓄能");
            Description.AddTranslation(GameCulture.Chinese, "水晶必须再次掌控时间的力量");
            DisplayName.AddTranslation(GameCulture.Russian, "Перезарядка кристалла");
            Description.AddTranslation(GameCulture.Russian, "Кристалл должен восстановить контроль над силами времени");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = false;
			canBeCleared = false;
			Main.persistentBuff[Type] = true;
		}
	}
}
