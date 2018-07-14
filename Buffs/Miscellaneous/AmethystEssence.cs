using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Miscellaneous
{
	public class AmethystEssence : ModBuff
	{
	    public override void SetDefaults()
		{
            DisplayName.SetDefault("Amethyst Essence");
            Description.SetDefault("Minion damage is increased by 10%");
            DisplayName.AddTranslation(GameCulture.Russian, "Аметистовая эссенция");
            Description.AddTranslation(GameCulture.Russian, "Урон миньонов увеличен на 10%");
            DisplayName.AddTranslation(GameCulture.Chinese, "紫水晶精华");
            Description.AddTranslation(GameCulture.Chinese, "增加 10% 召唤物伤害");
        }

	    public override void Update(Player player, ref int buffIndex)
        {
            player.minionDamage += 0.1f;
        }
	}
}
