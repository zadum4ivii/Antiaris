using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
	[AutoloadEquip(EquipType.Back)]
	public class DeepDivingGear : ModItem
	{
	    public override void SetDefaults()
		{
			item.width = 28;
			item.height = 36;
			item.value = Item.sellPrice(0, 10, 0, 0);
			item.rare = 5;
			item.accessory = true;
            item.defense = 4;
		}

	    public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Deep Diving Gear");
            Tooltip.SetDefault("Grants the ability to swim\nAutomatically uses oxygen tanks when needed\nProvides light when worn");
            DisplayName.AddTranslation(GameCulture.Chinese, "深潜水装置");
            Tooltip.AddTranslation(GameCulture.Chinese, "1、赋予游泳的能力2、\n必要时自动使用氧气罐3、\n佩戴时照亮周围");
            DisplayName.AddTranslation(GameCulture.Russian, "Глубоководное снаряжение акваланга");
            Tooltip.AddTranslation(GameCulture.Russian, "Позволяет плавать в воде\nАвтоматически использует баки с кислородом, когда необходимо\nОсвещает территорию вокруг игрока");
        }

	    public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.accDivingHelm = true;
			player.accFlipper = true;
            var aPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
            aPlayer.scuba = true;
			Lighting.AddLight(player.Top, Color.Blue.ToVector3() * 0.7f);
		}

	    public override void AddRecipes()
		{
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DivingGear);
			recipe.AddIngredient(null, "ScubaGear");
			recipe.AddIngredient(ItemID.MiningHelmet);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
