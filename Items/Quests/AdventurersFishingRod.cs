using Antiaris.NPCs.Town;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace Antiaris.Items.Quests
{
    public class AdventurersFishingRod : QuestItem
    {
        public AdventurersFishingRod()
        {
            questItem = true;
            uniqueStack = true;
            maxStack = 1;
            rare = -11;
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.GoldenFishingRod);
            item.width = 40;
            item.height = 34;
            item.fishingPole = 100;
            item.shoot = 0;
            item.useAnimation = 30;
            item.useTime = 30;
            base.SetDefaults();
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Adventurer's Fishing Rod");
			Tooltip.SetDefault("'It doesn't look too strong...'");
            DisplayName.AddTranslation(GameCulture.Chinese, "冒险家鱼竿");
			Tooltip.AddTranslation(GameCulture.Chinese, "“看起来不太强...”");
            DisplayName.AddTranslation(GameCulture.Russian, "Удочка Путешественника");
			Tooltip.AddTranslation(GameCulture.Russian, "'Не выглядит слишком крепкой...'");
        }

        public override bool UseItem(Player player)
        {
            string RodBroken = Language.GetTextValue("Mods.Antiaris.RodBroken", Main.LocalPlayer.name);
            if (player.itemAnimation >= 20)
            {
                QuestSystem.BrokenRod = true;
                item.stack = 0;
                Item.NewItem((int)player.position.X - 64, (int)player.position.Y, player.width, player.height, mod.ItemType("AdventurersFishingRodPart1"), 1, false, 0, false, false);
                Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, mod.ItemType("AdventurersFishingRodPart2"), 1, false, 0, false, false);
                Item.NewItem((int)player.position.X + 60, (int)player.position.Y, player.width, player.height, mod.ItemType("AdventurersFishingRodPart3"), 1, false, 0, false, false);
                Main.NewText(RodBroken, 255, 255, 255);
                Main.PlaySound(3, (int)player.position.X, (int)player.position.Y, 4);
            }
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "AdventurersFishingRodPart1");
			recipe.AddIngredient(null, "AdventurersFishingRodPart2");
			recipe.AddIngredient(null, "AdventurersFishingRodPart3");
            recipe.AddTile(18);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
