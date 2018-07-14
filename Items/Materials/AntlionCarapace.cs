using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Materials
{
    public class AntlionCarapace : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 30;
			item.value = Item.sellPrice(0, 0, 2, 0);
            item.rare = 3;
            item.maxStack = 999;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Antlion Carapace");
            DisplayName.AddTranslation(GameCulture.Chinese, "蚁狮甲壳");
            DisplayName.AddTranslation(GameCulture.Russian, "Панцирь муравьиного льва");
        }
    }
}
