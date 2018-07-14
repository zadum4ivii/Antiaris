using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Weapons
{
	public class TrueRage : ModBuff
	{
	    public override void SetDefaults()
		{
            DisplayName.SetDefault("True Rage");
            Description.SetDefault("Ranged damage is increased by 20%");
			DisplayName.AddTranslation(GameCulture.Chinese, "怒火觉醒");
            Description.AddTranslation(GameCulture.Chinese, "增加 20% 远程伤害");
            DisplayName.AddTranslation(GameCulture.Russian, "Истинная ярость");
            Description.AddTranslation(GameCulture.Russian, "Дальний урон увеличен на 20%");
			Main.pvpBuff[Type] = true;
		}

	    public override void Update(Player player, ref int buffIndex)
		{
            player.rangedDamage += 0.2f;
		}
	}
}
