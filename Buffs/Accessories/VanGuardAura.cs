using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Accessories
{
	public class VanGuardAura : ModBuff
	{
	    public override void SetDefaults()
		{
			Main.buffNoTimeDisplay[Type] = true;
			DisplayName.SetDefault("Van Guard Aura");
            Description.SetDefault("Increases your stats");
            DisplayName.AddTranslation(GameCulture.Russian, "Аура Защитника");
            Description.AddTranslation(GameCulture.Russian, "Повышает ваши характеристики");
		}

	    public override void Update(Player player, ref int buffIndex)
		{
            player.meleeDamage += 0.14f;
			player.magicDamage += 0.14f;
			player.rangedDamage += 0.14f;
			player.thrownDamage += 0.14f;
			player.minionDamage += 0.14f;
			player.meleeSpeed += 0.14f;
			player.moveSpeed += 0.14f;
		}
	}
}