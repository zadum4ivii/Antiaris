using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Melee.Yoyos
{
	public class DarkSpin : ModItem
	{
	    public override void SetDefaults()
		{
			item.width = 30;
			item.height = 26;
			item.noUseGraphic = true;
			item.UseSound = SoundID.Item1;
			item.melee = true;
			item.channel = true;
			item.noMelee = true;
			item.shoot = mod.ProjectileType("DarkSpin");
			item.useAnimation = 25;
			item.useTime = 25;
			item.shootSpeed = 16f;
			item.knockBack = 1f;
			item.damage = 32;
			item.value = Item.sellPrice(0, 2, 0, 0);
			item.rare = 4;
			item.useStyle = 5;
		}

	    public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dark Spin");
            DisplayName.AddTranslation(GameCulture.Chinese, "暗旋");
            DisplayName.AddTranslation(GameCulture.Russian, "Тёмное вращение");
			ItemID.Sets.Yoyo[item.type] = true;
			ItemID.Sets.GamepadExtraRange[item.type] = 15;
			ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
		}

	    public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.WoodYoyo);
			recipe.AddIngredient(ItemID.SoulofNight, 10);
			recipe.AddIngredient(null, "Shadowflame", 15);
            recipe.SetResult(this);
            recipe.AddTile(134);
            recipe.AddRecipe();
        }
	}
}
