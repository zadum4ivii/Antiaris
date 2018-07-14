using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Miscellaneous
{
	public class FrozenTime : ModBuff
	{
	    public override void SetDefaults()
		{
            DisplayName.SetDefault("Frozen Time");
            Description.SetDefault("One second has passed!");
            DisplayName.AddTranslation(GameCulture.Russian, "Остановленное время");
            Description.AddTranslation(GameCulture.Russian, "Прошла одна секунда!");
            DisplayName.AddTranslation(GameCulture.Chinese, "时间冻结");
            Description.AddTranslation(GameCulture.Chinese, "一秒钟过去了！");
			Main.buffNoSave[Type] = true;
			Main.debuff[Type] = true;
            canBeCleared = false;
		}

	    public override void Update(Player player, ref int buffIndex)
        {
            string TimeStop2 = Language.GetTextValue("Mods.Antiaris.TimeStop2", player.name);
            if (player != Main.player[Main.myPlayer]) Main.player[Main.myPlayer].AddBuff(mod.BuffType("FrozenTime2"), 20);
            if (player.buffTime[buffIndex] == 0)
            {
                AntiarisWorld.frozenTime = false;
                Main.NewText(TimeStop2, 255, 255, 255);
                Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Items/TimeParadoxCrystal2"), player.position);
				if (player.name != "zadum4ivii")
				{
					player.AddBuff(mod.BuffType("CrystalRecharge"), 18000);
				}
            }
            else AntiarisWorld.frozenTime = true;
        }
	}
}
