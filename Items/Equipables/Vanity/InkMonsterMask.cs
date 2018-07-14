using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Vanity
{
    [AutoloadEquip(EquipType.Head)]
    public class InkMonsterMask : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 42;
            item.height = 40;
            item.rare = 1;
            item.vanity = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ink Monster Mask");
            DisplayName.AddTranslation(GameCulture.Chinese, "墨水怪兽的面具");
            DisplayName.AddTranslation(GameCulture.Russian, "Маска чернильного монстра");
        }
    }
}
