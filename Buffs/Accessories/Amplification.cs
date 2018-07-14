using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Accessories
{
    public class Amplification : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Amplification");
            Description.SetDefault("Increases life regeneration and increases maximum health by 75");
            DisplayName.AddTranslation(GameCulture.Russian, "Усиление");
            Description.AddTranslation(GameCulture.Russian, "Увеличивает регенерацию здоровья и увеличивает максимальное количество жизней на 75");
			DisplayName.AddTranslation(GameCulture.Chinese, "放大");
			Description.AddTranslation(GameCulture.Chinese, "增加生命恢复速度，增加 75 点最大生命值");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.lifeRegen += 7;
            player.statLifeMax2 += 75;
        }
    }
}
