using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Weapons
{
	public class TerraRage : ModBuff
	{
		public override void SetDefaults()
		{
            DisplayName.SetDefault("Terra Rage");
            Description.SetDefault("35% increased ranged damage");
            DisplayName.AddTranslation(GameCulture.Russian, "Ярость Терры");
            Description.AddTranslation(GameCulture.Russian, "Увеличивает дальний урон на 35%");
			DisplayName.AddTranslation(GameCulture.Chinese, "泰拉之怒");
            Description.AddTranslation(GameCulture.Chinese, "增加 35% 远程伤害");
			Main.pvpBuff[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
            player.rangedDamage += 0.35f;
		}
	}
}
