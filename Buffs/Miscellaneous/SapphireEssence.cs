using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Miscellaneous
{
	public class SapphireEssence : ModBuff
	{
	    public override void SetDefaults()
		{
            DisplayName.SetDefault("Sapphire Essence");
            Description.SetDefault("Magic damage is increased by 10%");
            DisplayName.AddTranslation(GameCulture.Russian, "Сапфировая эссенция");
            Description.AddTranslation(GameCulture.Russian, "Магический урон увеличен на 10%");
            DisplayName.AddTranslation(GameCulture.Chinese, "蓝宝石精华");
            Description.AddTranslation(GameCulture.Chinese, "增加 10% 魔法伤害");
        }

	    public override void Update(Player player, ref int buffIndex)
        {
            player.magicDamage += 0.1f;
        }
	}
}
