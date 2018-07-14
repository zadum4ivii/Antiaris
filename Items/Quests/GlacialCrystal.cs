using Terraria.Localization;

namespace Antiaris.Items.Quests
{
    public class GlacialCrystal : QuestItem
    {
        public GlacialCrystal()
        {
            questItem = true;
            uniqueStack = true;
            maxStack = 1;
            rare = -11;
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 32;
			base.SetDefaults();
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Glacial Crystal");
            DisplayName.AddTranslation(GameCulture.Chinese, "冰晶体");
            DisplayName.AddTranslation(GameCulture.Russian, "Ледяной кристалл");
        }
    }
}
