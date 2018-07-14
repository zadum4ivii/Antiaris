using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Pets
{
	public class ShadowflameCandle : ModItem
	{
	    public override void SetDefaults()
		{
            item.width = 12;
            item.height = 34;
            item.useTime = 22;
            item.useAnimation = 22;
            item.useStyle = 1;
            item.value = Item.sellPrice(0, 0, 64, 60);
            item.rare = 5;
            item.UseSound = SoundID.Item8;
            item.autoReuse = false;
            item.buffType = mod.BuffType("ShadowflameCandle");
            item.shoot = mod.ProjectileType("ShadowflameCandle");
            item.shootSpeed = 3.5f;
        }

	    public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shadowflame Candle");
            Tooltip.SetDefault("Summons a shadow candle");
			DisplayName.AddTranslation(GameCulture.Chinese, "暗影火蜡烛");
			Tooltip.AddTranslation(GameCulture.Chinese, "召唤一个暗影火蜡烛");
            DisplayName.AddTranslation(GameCulture.Russian, "Свеча теневого пламени");
            Tooltip.AddTranslation(GameCulture.Russian, "Призывает теневую свечу");
        }

	    public override void UseStyle(Player player) 
		{ 
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0) 
			{
				player.AddBuff(item.buffType, 3600, true); 
			}
		}

	    public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Candle);
			recipe.AddIngredient(ItemID.SoulofNight, 12);
            recipe.AddIngredient(null, "Shadowflame", 15);
            recipe.SetResult(this);
            recipe.AddTile(134);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.PlatinumCandle);
			recipe.AddIngredient(ItemID.SoulofNight, 12);
            recipe.AddIngredient(null, "Shadowflame", 15);
            recipe.SetResult(this);
            recipe.AddTile(134);
            recipe.AddRecipe();
        }
	}
}