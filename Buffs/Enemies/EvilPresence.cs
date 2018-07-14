using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Enemies
{
	public class EvilPresence : ModBuff
	{
	    public override void SetDefaults()
		{
            DisplayName.SetDefault("Evil Presence");
            Description.SetDefault("5% increased all attacks fail chance");
            DisplayName.AddTranslation(GameCulture.Chinese, "邪恶存在");
            Description.AddTranslation(GameCulture.Chinese, "增加 5% 所有攻击失效的概率");
            DisplayName.AddTranslation(GameCulture.Russian, "Злое присутствие");
            Description.AddTranslation(GameCulture.Russian, "На 5% повышает вероятность провала всех атак");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = false;
            Main.buffNoTimeDisplay[Type] = true;
		}

	    public override void Update(Player player, ref int buffIndex)
		{
			AntiarisPlayer.spellFail += 5;
		}
	}
}
