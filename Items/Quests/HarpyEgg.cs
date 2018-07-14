using Terraria.Localization;

namespace Antiaris.Items.Quests
{
    public class HarpyEgg : QuestItem
    {
        public HarpyEgg()
        {
            questItem = true;
            uniqueStack = true;
            maxStack = 1;
            rare = -11;
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 28;
			base.SetDefaults();
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Harpy Egg");
            DisplayName.AddTranslation(GameCulture.Chinese, "鹰身女妖的蛋");
            DisplayName.AddTranslation(GameCulture.Russian, "Яйцо гарпии");
        }
    }
}
