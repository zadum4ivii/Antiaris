using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.Items.Materials
{
    public class GreenGoo : ModItem
    {
        public override void SetDefaults()
        {
            item.useStyle = 1;
            item.useTurn = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.autoReuse = true;
            item.width = 22;
            item.height = 24;
            item.rare = 2;
            item.maxStack = 999;
            item.value = Item.sellPrice(0, 0, 0, 75);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Green Goo");
            DisplayName.AddTranslation(GameCulture.Chinese, "绿色凝胶");
            DisplayName.AddTranslation(GameCulture.Russian, "Зеленая слизь");
        }

        public void OverhaulInit()
        {
            this.SetTag("flammable");
            this.SetTag("floatsInWater");
        }
    }
}
