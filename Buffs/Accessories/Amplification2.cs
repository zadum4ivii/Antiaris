using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Accessories
{
    public class Amplification2 : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Amplification");
            Description.SetDefault("Increases all stats");
            DisplayName.AddTranslation(GameCulture.Russian, "Усиление");
            Description.AddTranslation(GameCulture.Russian, "Увеличивает все характеристики");
			DisplayName.AddTranslation(GameCulture.Chinese, "放大");
			Description.AddTranslation(GameCulture.Chinese, "增加所有属性");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.lifeRegen += 2;
            player.statLifeMax2 += 15;
            player.meleeDamage += 0.08f;
            player.magicDamage += 0.08f;
            player.rangedDamage += 0.08f;
            player.thrownDamage += 0.08f;
            player.minionDamage += 0.08f;
            player.meleeSpeed += 0.08f;
            player.moveSpeed += 0.08f;
            player.statDefense += 2;
            player.moveSpeed += 0.1f;
            player.statManaMax2 += 35;
            player.manaRegen += 2;
        }
    }
}
