using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Miscellaneous
{
	public class DiamondEssence : ModBuff
	{
	    public override void SetDefaults()
		{
            DisplayName.SetDefault("Diamond Essence");
            Description.SetDefault("All damage is increased by 5%");
            DisplayName.AddTranslation(GameCulture.Russian, "Алмазная эссенция");
            Description.AddTranslation(GameCulture.Russian, "Весь урон увеличен на 5%");
            DisplayName.AddTranslation(GameCulture.Chinese, "钻石精华");
            Description.AddTranslation(GameCulture.Chinese, "增加 5% 所有伤害");
        }

	    public override void Update(Player player, ref int buffIndex)
        {
            player.minionDamage += 0.05f;
            player.meleeDamage += 0.05f;
            player.magicDamage += 0.05f;
            player.thrownDamage += 0.05f;
            player.rangedDamage += 0.05f;
        }
	}
}
