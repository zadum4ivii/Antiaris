using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Potions
{
    public class SteelFeetPotion : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Steel Feet Potion");
            Description.SetDefault("Increases height at which you take damage from falling and reduces fall damage");
            DisplayName.AddTranslation(GameCulture.Chinese, "钢踵药水");
            Description.AddTranslation(GameCulture.Chinese, "1、坠落伤害所需要的高度上升\n2、减少你承受的坠落伤害");
            DisplayName.AddTranslation(GameCulture.Russian, "Зелье стальных ног");
            Description.AddTranslation(GameCulture.Russian, "Увеличивает высоту, с которой вы получаете урон от падения и уменьшает урон от падения");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.extraFall += 50;
            player.fallStart2 += 50;
        }
    }
}
