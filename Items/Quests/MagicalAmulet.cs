using Terraria;
using Terraria.DataStructures;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Quests
{
    public class MagicalAmulet : QuestItem
    {
        private int timer = 0;

        public MagicalAmulet()
        {
            questItem = true;
            uniqueStack = true;
            maxStack = 1;
            rare = -11;
        }

        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 30;
            item.accessory = true;
			base.SetDefaults();
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Magical Amulet");
            Tooltip.SetDefault("'This strange amulet belongs to the Pirate'\nGrants Immortality for bearer");
            DisplayName.AddTranslation(GameCulture.Chinese, "神奇的护身符");
            Tooltip.AddTranslation(GameCulture.Chinese, "这个奇怪的护身符是船长的\n可以使持有者不朽");
            DisplayName.AddTranslation(GameCulture.Russian, "Магический амулет");
            Tooltip.AddTranslation(GameCulture.Russian, "'Этот странный амулет принадлежит Пирату'\nДает неуявзимость носителю");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            string AmuletDeath = Language.GetTextValue("Mods.Antiaris.AmuletDeath", Main.LocalPlayer.name);
			string AmuletDeathF = Language.GetTextValue("Mods.Antiaris.AmuletDeathF", Main.LocalPlayer.name);
            ++timer;
			if(timer % 350 == 0 && !player.dead)
			{
				if(player.Male)
				{
					player.KillMe(PlayerDeathReason.ByCustomReason(AmuletDeath), 1, 1);
				}
				else
				{
					player.KillMe(PlayerDeathReason.ByCustomReason(AmuletDeathF), 1, 1);
				}
			}
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "AmuletPiece1", 1);
			recipe.AddIngredient(null, "AmuletPiece2", 1);
			recipe.AddIngredient(null, "AmuletPiece3", 1);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
