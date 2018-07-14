using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Weapons
{
	public class Electrified : ModBuff
	{
	    public override void SetDefaults()
		{
            DisplayName.SetDefault("Electrified");
			DisplayName.AddTranslation(GameCulture.Chinese, "带电");
            DisplayName.AddTranslation(GameCulture.Russian, "Электризованность");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
		}

	    public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<AntiarisPlayer>(mod).electrified = true;;
		}

	    public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<AntiarisNPC>(mod).electrified = true;
		}
	}
}
