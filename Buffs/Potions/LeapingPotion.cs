using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Potions
{
    public class LeapingPotion : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Leaping Potion");
            Description.SetDefault("Increases jump height and allows auto-jump");
            DisplayName.AddTranslation(GameCulture.Chinese, "跃进药水");
            Description.AddTranslation(GameCulture.Chinese, "1、自身可以跳得更高\n2、按住空格键允许进行连续跳跃");
            DisplayName.AddTranslation(GameCulture.Russian, "Зелье прыгучести");
            Description.AddTranslation(GameCulture.Russian, "Увеличивает высоту прыжка и позволяет автоматически прыгать");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.autoJump = true;
			player.jumpBoost = true;
        }
    }
}
