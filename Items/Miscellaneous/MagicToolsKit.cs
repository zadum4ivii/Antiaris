using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Miscellaneous
{
    public class MagicToolsKit : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 32;
            item.rare = 0;
            item.useAnimation = 45;
            item.useTime = 45;
			item.maxStack = 1;
			item.UseSound = SoundID.Item122;
            item.useStyle = 4;
			item.shootSpeed = 15f;
            item.consumable = true;
        }

        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magic Tools Kit");
			Tooltip.SetDefault("Used to repair Guide's house");
			DisplayName.AddTranslation(GameCulture.Russian, "Набор магических инструментов");
			Tooltip.AddTranslation(GameCulture.Russian, "Используется для починки дома Гида");
			DisplayName.AddTranslation(GameCulture.Chinese, "神奇工具包");
			Tooltip.AddTranslation(GameCulture.Chinese, "用于修复向导的房子");
		}

        public override bool UseItem(Player player)
        {
			var aPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
			aPlayer.building = true;
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "MagicalHammer");
            recipe.AddIngredient(ItemID.IronBar, 6);
            recipe.anyIronBar = true;
            recipe.AddIngredient(ItemID.Wood, 25);
			recipe.AddIngredient(ItemID.Leather, 4);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}