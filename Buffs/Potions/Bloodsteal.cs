using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Potions
{
    public class Bloodsteal : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Bloodsteal");
            Description.SetDefault("Attacks have a chance to restore health");
            DisplayName.AddTranslation(GameCulture.Chinese, "嗜血");
            Description.AddTranslation(GameCulture.Chinese, "攻击时有概率恢复体力");
            DisplayName.AddTranslation(GameCulture.Russian, "Воровство крови");
            Description.AddTranslation(GameCulture.Russian, "Атаки имеют шанс восстановить здоровье");
        }

        public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<AntiarisPlayer>(mod).bloodsteal = true;
		}
    }
}
