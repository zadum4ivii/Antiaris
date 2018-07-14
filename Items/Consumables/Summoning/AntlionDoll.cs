using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Summoning
{
    public class AntlionDoll : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.maxStack = 20;
            item.rare = 0;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 4;
            item.consumable = true;
        }

        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Antlion Doll");
			Tooltip.SetDefault("Summons Antlion Queen");
			DisplayName.AddTranslation(GameCulture.Russian, "Кукла муравьиного льва");
			Tooltip.AddTranslation(GameCulture.Russian, "Призывает Королеву муравьиных львов");
			DisplayName.AddTranslation(GameCulture.Chinese, "蚁狮玩偶");
			Tooltip.AddTranslation(GameCulture.Chinese, "召唤蚁后\n[c/C35377:只能在击败蜂后之后才能召唤！]");
		}


        public override bool CanUseItem(Player player)
		{
			return player.ZoneDesert && !NPC.AnyNPCs(mod.NPCType("AntlionQueen"));
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Silk, 15);
            recipe.AddIngredient(ItemID.AntlionMandible, 10);
            recipe.AddIngredient(ItemID.ShadowScale, 12);
            recipe.AddIngredient(null,"WrathElement", 6);
			recipe.AddIngredient(null,"BloodDroplet", 4);
            recipe.SetResult(this);
            recipe.AddTile(86);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Silk, 15);
            recipe.AddIngredient(ItemID.AntlionMandible, 10);
            recipe.AddIngredient(ItemID.TissueSample, 12);
            recipe.AddIngredient(null,"WrathElement", 6);
			recipe.AddIngredient(null,"BloodDroplet", 4);
            recipe.SetResult(this);
            recipe.AddTile(86);
            recipe.AddRecipe();
        }

        public override bool UseItem(Player player)
        {
			Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
            if (Main.netMode != 1)
            {
                NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("AntlionQueen"));
            }
            return true;
        }
    }
}
