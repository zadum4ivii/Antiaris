using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Materials
{
    public class MirrorShard : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 30;
            item.rare = 4;
            item.maxStack = 999;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mirror Shard");
            DisplayName.AddTranslation(GameCulture.Chinese, "魔镜碎片");
            DisplayName.AddTranslation(GameCulture.Russian, "Осколок зеркала");
        }
    }
}
