using Terraria.Localization;

namespace Antiaris.Items.Quests
{
    public class AmuletPiece3 : QuestItem
    {
        public AmuletPiece3()
        {
            questItem = true;
            uniqueStack = true;
            maxStack = 1;
            rare = -11;
        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 26;
			base.SetDefaults();
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Amulet Piece");
            DisplayName.AddTranslation(GameCulture.Chinese, "护身符碎片");
            DisplayName.AddTranslation(GameCulture.Russian, "Часть амулета");
        }
    }
}
