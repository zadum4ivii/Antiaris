using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Potions
{
    public class PatchedUp : ModBuff
    {
        private int timer = 0;

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Patched Up");
            Description.SetDefault("Slowly recovering from injuries");
            DisplayName.AddTranslation(GameCulture.Chinese, "治疗");
            Description.AddTranslation(GameCulture.Chinese, "从伤病中慢慢恢复");
            DisplayName.AddTranslation(GameCulture.Russian, "Излечение");
            Description.AddTranslation(GameCulture.Russian, "Медленное выздоровление");
        }

        public override void Update(Player player, ref int buffIndex)
        {
			timer++;
			if(timer == 60)
			{
				player.statLife += 1;
                player.HealEffect(1);
				timer = 0;
			}
        }
    }
}
