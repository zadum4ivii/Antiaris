using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Vanity
{
    [AutoloadEquip(EquipType.Head)]
    public class AntlionQueenMask : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 32;
            item.rare = 1;
            item.vanity = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Antlion Queen Mask");
            DisplayName.AddTranslation(GameCulture.Chinese, "蚁狮女王面具");
            DisplayName.AddTranslation(GameCulture.Russian, "Маска Королевы муравьиных львов");
        }
    }
}