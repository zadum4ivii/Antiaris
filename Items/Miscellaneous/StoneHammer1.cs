using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace Antiaris.Items.Miscellaneous
{
    public class StoneHammer1 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stone Hammer");
            Tooltip.SetDefault("Strong and sharp enough to break mirrors");
			DisplayName.AddTranslation(GameCulture.Chinese, "入魔石锤");
			Tooltip.AddTranslation(GameCulture.Chinese, "强大和锐利到足以摧毁魔镜");
            DisplayName.AddTranslation(GameCulture.Russian, "Каменный молот");
            Tooltip.AddTranslation(GameCulture.Russian, "Достаточно сильный и острый, чтобы разбивать зеркала");
        }

        public override void SetDefaults()
        {
            item.width = 48;
            item.height = 48;
            item.rare = 4;
            item.maxStack = 20;
            item.useAnimation = 25;
            item.useTime = 25;
            item.useStyle = 1;
            item.UseSound = SoundID.Item1;
        }
    }
}