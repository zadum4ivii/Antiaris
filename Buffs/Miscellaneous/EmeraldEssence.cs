using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Miscellaneous
{
	public class EmeraldEssence : ModBuff
	{
	    public override void SetDefaults()
		{
            DisplayName.SetDefault("Emerald Essence");
            Description.SetDefault("Ranged damage is increased by 10%");
            DisplayName.AddTranslation(GameCulture.Russian, "Изумрудная эссенция");
            Description.AddTranslation(GameCulture.Russian, "Дальний урон увеличен на 10%");
            DisplayName.AddTranslation(GameCulture.Chinese, "翡翠精华");
            Description.AddTranslation(GameCulture.Chinese, "增加 10% 远程伤害");
        }

	    public override void Update(Player player, ref int buffIndex)
        {
            player.rangedDamage += 0.1f;
        }
	}
}
