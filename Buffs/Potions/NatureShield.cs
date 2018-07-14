using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Buffs.Potions
{
    public class NatureShield : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Nature Shield");
            Description.SetDefault("Grants immunity to some debuffs");
            DisplayName.AddTranslation(GameCulture.Chinese, "自然之盾");
            Description.AddTranslation(GameCulture.Chinese, "免疫部分Debuff");
            DisplayName.AddTranslation(GameCulture.Russian, "Щит природы");
            Description.AddTranslation(GameCulture.Russian, "Даёт иммунитет к некоторым дебаффам");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffImmune[BuffID.Poisoned] = true;
			player.buffImmune[BuffID.Cursed] = true;
			player.buffImmune[BuffID.Darkness] = true;
			player.buffImmune[BuffID.Bleeding] = true;
			player.buffImmune[BuffID.Confused] = true;
			player.buffImmune[BuffID.Silenced] = true;
        }
    }
}
