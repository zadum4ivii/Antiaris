using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Miscellaneous
{
	public class TopazEssence : ModBuff
	{
	    public override void SetDefaults()
		{
            DisplayName.SetDefault("Topaz Essence");
            Description.SetDefault("Throwing damage is increased by 10%");
            DisplayName.AddTranslation(GameCulture.Russian, "Топазовая эссенция");
            Description.AddTranslation(GameCulture.Russian, "Метательный урон увеличен на 10%");
            DisplayName.AddTranslation(GameCulture.Chinese, "黄玉精华");
            Description.AddTranslation(GameCulture.Chinese, "增加 10% 投掷伤害");
        }

	    public override void Update(Player player, ref int buffIndex)
        {
            player.thrownDamage += 0.1f;
        }
	}
}
