using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Tiles
{
    public class MirrorBlessing : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Mirror's Blessing");
            Description.SetDefault("8% increased damage");
            DisplayName.AddTranslation(GameCulture.Chinese, "镜之祝福");
            Description.AddTranslation(GameCulture.Chinese, "增加 8% 伤害");
            DisplayName.AddTranslation(GameCulture.Russian, "Благословение зеркала");
            Description.AddTranslation(GameCulture.Russian, "На 8% увеличивает урон");
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.meleeDamage += 0.08f;
            player.rangedDamage += 0.08f;
            player.thrownDamage += 0.08f;
            player.minionDamage += 0.08f;
            player.magicDamage += 0.08f;
        }
    }
}
