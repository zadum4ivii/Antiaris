using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Melee.Spears
{
	public class TrueGungnir : ModItem
	{
	    public override void SetDefaults()
		{
            item.useStyle = 5;
            item.useAnimation = 18;
            item.useTime = 18;
            item.shootSpeed = 5.6f;
            item.knockBack = 7.4f;
            item.width = 60;
            item.height = 60;
            item.damage = 71;
            item.scale = 1.1f;
            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType("TrueGungnir");
            item.rare = 8;
            item.value = Item.sellPrice(0, 12, 34, 30);
            item.noMelee = true;
            item.noUseGraphic = true;
            item.melee = true;
        }

	    public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Gungnir");
			DisplayName.AddTranslation(GameCulture.Chinese, "真·永恒之枪");
            DisplayName.AddTranslation(GameCulture.Russian, "Истинный Экскалибур");
        }

	    public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Gungnir);
            recipe.AddIngredient(ItemID.BrokenHeroSword);
            recipe.SetResult(this);
            recipe.AddTile(134);
            recipe.AddRecipe();
        }
	}
}
