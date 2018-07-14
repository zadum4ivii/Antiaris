using Terraria.Localization;

namespace Antiaris.Items.Quests
{
    public class EmeraldShard : QuestItem
    {
        public EmeraldShard()
        {
            questItem = true;
            //uniqueStack = true;
            maxStack = 999;
            rare = -11;
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 28;
            base.SetDefaults();
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Emerald Shard");
            DisplayName.AddTranslation(GameCulture.Chinese, "翡绿碎片");
            DisplayName.AddTranslation(GameCulture.Russian, "Изумрудный осколок");
        }
    }
}
