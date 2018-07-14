using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
	[AutoloadEquip(EquipType.Waist)]
	public class RoguesBelt : ModItem
	{
	    public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.value = Item.sellPrice(0, 0, 50, 0);
			item.rare = 1;
			item.accessory = true;
		}

	    public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rogue's Belt");
			Tooltip.SetDefault("Decreases thrown weapons consumption by 15%");
			DisplayName.AddTranslation(GameCulture.Chinese, "恶棍腰带");
			Tooltip.AddTranslation(GameCulture.Chinese, "减少投掷武器 15% 的消耗");
            DisplayName.AddTranslation(GameCulture.Russian, "Пояс жулика");
            Tooltip.AddTranslation(GameCulture.Russian, "Уменьшает потребляемость метательных оружий на 15%");
        }

	    public override void UpdateAccessory(Player player, bool hideVisual)
		{
            player.GetModPlayer<AntiarisPlayer>(mod).thrownCost += 15;
            player.GetModPlayer<AntiarisPlayer>(mod).roguesBelt = true;
        }

	    public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ThrowingKnife, 999);
			recipe.AddIngredient(ItemID.Leather, 4);
			recipe.AddIngredient(ItemID.IronBar, 2);
            recipe.anyIronBar = true;
            recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
