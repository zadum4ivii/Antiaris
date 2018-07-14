using Terraria.Localization;

namespace Antiaris.Items.Quests
{
    public class DemonWingPiece : QuestItem
    {
        public DemonWingPiece()
        {
            questItem = true;
            maxStack = 999;
            rare = -11;
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 32;
			base.SetDefaults();
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Demon's Wing Piece");
            DisplayName.AddTranslation(GameCulture.Chinese, "恶魔翅膀碎片");
            DisplayName.AddTranslation(GameCulture.Russian, "Часть крыла Демона");
        }
    }
}
