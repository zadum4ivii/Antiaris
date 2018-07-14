using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Vanity
{
    [AutoloadEquip(EquipType.Head)]
    public class MinerMask : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 18;
            item.rare = 1;
            item.vanity = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Miner Mask");
            DisplayName.AddTranslation(GameCulture.Chinese, "矿工面具");
            DisplayName.AddTranslation(GameCulture.Russian, "Маска шахтёра");
        }
    }
}
