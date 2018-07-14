using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Accessories
{
    public class Wrath : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Wrath");
            Description.SetDefault("Increases all damage by 25%");
            DisplayName.AddTranslation(GameCulture.Russian, "Гнев");
            Description.AddTranslation(GameCulture.Russian, "Увеличивает весь урон на 25%");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.meleeDamage += 0.25f;
            player.magicDamage += 0.25f;
            player.rangedDamage += 0.25f;
            player.minionDamage += 0.25f;
            player.thrownDamage += 0.25f;
        }
    }
}
