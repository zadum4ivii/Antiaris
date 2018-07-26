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
            Tooltip.SetDefault("'It's very fragile, hopefully nobody smashes it'");
            DisplayName.AddTranslation(GameCulture.Chinese, "鹰身女妖的蛋");
            Tooltip.AddTranslation(GameCulture.Chinese, "“它非常脆弱，希望没有人把它弄碎”");
            DisplayName.AddTranslation(GameCulture.Russian, "Яйцо гарпии");
            Tooltip.AddTranslation(GameCulture.Russian, "'Оно очень хрупкое, надеюсь, никто его не разобьёт'");
        }
    }
}
