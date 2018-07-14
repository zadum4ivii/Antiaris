using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Accessories
{
    public class WarbannerAura : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Warbanner Aura");
            Description.SetDefault("Increases your stats");
            DisplayName.AddTranslation(GameCulture.Russian, "Аура боевого флага");
            Description.AddTranslation(GameCulture.Russian, "Повышает ваши характеристики");
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.meleeDamage += 0.05f;
            player.magicDamage += 0.05f;
            player.minionDamage += 0.05f;
            player.thrownDamage += 0.05f;
            player.rangedDamage += 0.05f;
            player.meleeSpeed += 0.05f;
            player.moveSpeed += 0.05f;
        }
    }
}
