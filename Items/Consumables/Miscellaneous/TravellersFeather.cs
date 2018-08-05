using Antiaris.Items.Placeables.Decorations;
using Antiaris.NPCs.Town;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Miscellaneous
{
    public class TravellersFeather : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 32;
            item.maxStack = 99;
            item.rare = 1;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 4;
            item.UseSound = SoundID.Item1.WithPitchVariance(0.8f);
            item.consumable = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Traveller's Feather");
            Tooltip.SetDefault("Switches Adventurer's quest");
            DisplayName.AddTranslation(GameCulture.Russian, "Перо путешественника");
            Tooltip.AddTranslation(GameCulture.Russian, "Изменяет задание Путешественника");
			DisplayName.AddTranslation(GameCulture.Chinese, "荼毒女王鸟的羽毛");
			Tooltip.AddTranslation(GameCulture.Chinese, "改变冒险家的任务");
        }

        public override bool CanUseItem(Player player)
        {
            bool noQuest = false;
            if (player.GetModPlayer<QuestSystem>(mod).CurrentQuest == -1)
                noQuest = true;
            return !noQuest;
        }

        public override bool UseItem(Player player)
        {
            if (!player.GetModPlayer<QuestSystem>(mod).CompletedToday && player.GetModPlayer<QuestSystem>(mod).CurrentQuest >= 0 && player.GetModPlayer<QuestSystem>(mod).CurrentQuest != -1)
            { 
                int quest = Main.rand.Next(19);
                if (quest != 6 && quest != 12 && quest != 17 && quest != 19)
                {
                    player.GetModPlayer<QuestSystem>(mod).CurrentQuest = quest;
                }
                else
                {
                    player.GetModPlayer<QuestSystem>(mod).CurrentQuest = 5;
                }
            }
            return true;
        }
    }
}
