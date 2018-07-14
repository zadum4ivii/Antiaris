using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Weapons
{
	public class LightRage : ModBuff
	{
	    public override void SetDefaults()
		{
            DisplayName.SetDefault("Rage of Light");
            Description.SetDefault("The holy light consumes your enemies");
			DisplayName.AddTranslation(GameCulture.Chinese, "光之怒");
            Description.AddTranslation(GameCulture.Chinese, "圣光会吞噬你的敌人");
            DisplayName.AddTranslation(GameCulture.Russian, "Ярость света");
            Description.AddTranslation(GameCulture.Russian, "Святой свет пожирает ваших противников");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
		}

	    public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<AntiarisNPC>(mod).lRage = true;
		}
	}
}
