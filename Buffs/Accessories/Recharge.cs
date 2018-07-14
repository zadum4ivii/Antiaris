using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Accessories
{
    public class Recharge : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("[c/FFCC33:Recharge]");
            Description.SetDefault("The Adventurer's item is recharging it's power");
            DisplayName.AddTranslation(GameCulture.Russian, "[c/FFCC33:Перезарядка]");
            Description.AddTranslation(GameCulture.Russian, "Предмет Путешественника перезаряжает свою силу");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
			canBeCleared = false;
        }
    }
}