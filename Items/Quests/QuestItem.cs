using Terraria.ModLoader;

namespace Antiaris.Items.Quests
{
    public abstract class QuestItem : ModItem
    {
        protected int maxStack = 0;
        protected bool questItem = false;
        protected int rare = 0;
        protected bool uniqueStack = false;

        public override void SetDefaults()
        {
            item.maxStack = maxStack;
            item.uniqueStack = uniqueStack;
            item.rare = rare;
			item.questItem = questItem;
        }
    }
}
