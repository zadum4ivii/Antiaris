using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.Items.Materials
{
    public class WandCore : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 28;
			item.value = Item.sellPrice(0, 1, 15, 35);
            item.rare = 2;
            item.maxStack = 99;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wand Core");
            Tooltip.SetDefault("'Filled with energy'");
			DisplayName.AddTranslation(GameCulture.Chinese, "法杖核心");
            Tooltip.AddTranslation(GameCulture.Chinese, "“充满能量”");
            DisplayName.AddTranslation(GameCulture.Russian, "Стержень для посоха");
            Tooltip.AddTranslation(GameCulture.Russian, "'Наполнен энергией'");
        }

        public void OverhaulInit()
        {
            this.SetTag("flammable");
        }
    }
}
