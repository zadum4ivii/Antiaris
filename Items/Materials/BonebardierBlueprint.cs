using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.Items.Materials
{
    public class BonebardierBlueprint : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 44;
            item.height = 38;
            item.maxStack = 1;
            item.value = Item.buyPrice(0, 12, 0, 0);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bonebardier Blueprint");
            DisplayName.AddTranslation(GameCulture.Chinese, "骸骨炮兵蓝图");
            DisplayName.AddTranslation(GameCulture.Russian, "Чертёж Костардира");
        }

        public void OverhaulInit()
        {
            this.SetTag("flammable");
        }
    }
}
