using Terraria.Localization;

namespace Antiaris.Items.Quests
{
    public class Necronomicon : QuestItem
    {
        public Necronomicon()
        {
            questItem = true;
            uniqueStack = true;
            maxStack = 1;
            rare = -11;
        }

        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 36;
			base.SetDefaults();
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Necronomicon");
            DisplayName.AddTranslation(GameCulture.Chinese, "死灵之书");
            DisplayName.AddTranslation(GameCulture.Russian, "Некрономикон");
        }
    }
}
