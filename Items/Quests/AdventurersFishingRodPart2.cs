using Terraria.Localization;

namespace Antiaris.Items.Quests
{
    public class AdventurersFishingRodPart2 : QuestItem
    {
        public AdventurersFishingRodPart2()
        {
            questItem = true;
            uniqueStack = true;
            maxStack = 1;
            rare = -11;
        }

        public override void SetDefaults()
        {
            item.width = 36;
            item.height = 22;
			base.SetDefaults();
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Adventurer's Fishing Rod Part");
            DisplayName.AddTranslation(GameCulture.Chinese, "冒险家鱼竿的部件");
            DisplayName.AddTranslation(GameCulture.Russian, "Часть удочки Путешественника");
        }
    }
}
