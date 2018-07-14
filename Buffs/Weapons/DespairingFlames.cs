using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Weapons
{
	public class DespairingFlames : ModBuff
	{
	    public override void SetDefaults()
		{
            DisplayName.SetDefault("Despairing Flames");
            Description.SetDefault("Great, you're on fire AND you're depressed");
            DisplayName.AddTranslation(GameCulture.Chinese, "绝望烈焰");
            Description.AddTranslation(GameCulture.Chinese, "真棒，你着火了并且很绝望");
            DisplayName.AddTranslation(GameCulture.Russian, "Пламя безысходности");
            Description.AddTranslation(GameCulture.Russian, "Прекрасно, вы горите и ещё подавлены");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
		}

	    public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<AntiarisPlayer>(mod).despairingFlamesB = true;
		}

	    public override void Update(NPC npc, ref int buffIndex)
		{
			if (!npc.boss) npc.GetGlobalNPC<AntiarisNPC>(mod).despairingFlamesB = true;
		}
	}
}
