using Terraria.Localization;
using Terraria;
using Terraria.ID;

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
            Tooltip.SetDefault("'Be careful not to step into cold water while it is in your pockets'");
            DisplayName.AddTranslation(GameCulture.Chinese, "冰晶体");
            Tooltip.AddTranslation(GameCulture.Chinese, "");
            DisplayName.AddTranslation(GameCulture.Russian, "Ледяной кристалл");
            Tooltip.AddTranslation(GameCulture.Italian, "'Постарайтесь не вступать в холодную воду, пока он у вас в кармане'");
        }
    }
}
