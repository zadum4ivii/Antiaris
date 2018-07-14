using Terraria.Localization;

namespace Antiaris.Items.Quests
{
    public class OldCompass : QuestItem
    {
        public OldCompass()
        {
            questItem = true;
            uniqueStack = true;
            maxStack = 1;
            rare = -11;
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 28;
			base.SetDefaults();
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Old Compass");
            DisplayName.AddTranslation(GameCulture.Chinese, "旧罗盘");
            DisplayName.AddTranslation(GameCulture.Russian, "Старый компас");
        }
    }
}
