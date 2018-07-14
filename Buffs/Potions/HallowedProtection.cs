using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Potions
{
    public class HallowedProtection : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Hallowed Protection");
            Description.SetDefault("Reduces damage taken");
            DisplayName.AddTranslation(GameCulture.Chinese, "神圣护佑");
            Description.AddTranslation(GameCulture.Chinese, "减少所承受的伤害");
            DisplayName.AddTranslation(GameCulture.Russian, "Святая защита");
            Description.AddTranslation(GameCulture.Russian, "Снижает получаемый урон");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.endurance += 0.35f;
        }
    }
}
