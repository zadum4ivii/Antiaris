using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Miscellaneous
{
	public class CursedBlocks : ModBuff
	{
	    public override void SetDefaults()
		{
            DisplayName.SetDefault("Cursed Blocks");
            Description.SetDefault("Blocks around you look unbreakable!");
            DisplayName.AddTranslation(GameCulture.Chinese, "咒怨方块");
            Description.AddTranslation(GameCulture.Chinese, "你周围的方块看起来牢不可破！");
            DisplayName.AddTranslation(GameCulture.Russian, "Проклятые блоки");
            Description.AddTranslation(GameCulture.Russian, "Блоки вокруг вас выглядят неразрушимыми!");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = false;
			canBeCleared = false;
			Main.buffNoTimeDisplay[Type] = true;
		}

	    public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<AntiarisPlayer>(mod).mirrorZone = true;
		}
	}
}
