using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Miscellaneous
{
	public class RubyEssence : ModBuff
	{
	    public override void SetDefaults()
		{
            DisplayName.SetDefault("Ruby Essence");
            Description.SetDefault("Melee damage is increased by 10%");
            DisplayName.AddTranslation(GameCulture.Russian, "Рубиновая эссенция");
            Description.AddTranslation(GameCulture.Russian, "Ближний урон увеличен на 10%");
            DisplayName.AddTranslation(GameCulture.Chinese, "红宝石精华");
            Description.AddTranslation(GameCulture.Chinese, "增加 10% 近战伤害");
        }

	    public override void Update(Player player, ref int buffIndex)
        {
            player.meleeDamage += 0.1f;
        }
	}
}
