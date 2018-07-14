using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Potions
{
    public class Concentration : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Concentration");
            Description.SetDefault("10% reduced spell fail chance");
            DisplayName.AddTranslation(GameCulture.Chinese, "聚精会神");
            Description.AddTranslation(GameCulture.Chinese, "减少 10% 咒语失效概率");
            DisplayName.AddTranslation(GameCulture.Russian, "Концентрация");
            Description.AddTranslation(GameCulture.Russian, "На 10% снижает шанс неудачного произнесения заклинания");
        }

        public override void Update(Player player, ref int buffIndex)
		{
			AntiarisPlayer.spellFail -= 10;
		}
    }
}
