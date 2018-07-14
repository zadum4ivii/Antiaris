using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
	[AutoloadEquip(EquipType.Back)]
	public class ScubaGear : ModItem
	{
	    public override void SetDefaults()
		{
			item.width = 32;
			item.height = 42;
			item.value = Item.sellPrice(0, 2, 0, 0);
			item.rare = 5;
			item.accessory = true;
            item.defense = 2;
		}

	    public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Scuba Gear");
			Tooltip.SetDefault("Automatically uses oxygen tanks when necessary");
            DisplayName.AddTranslation(GameCulture.Chinese, "水下呼吸器");
            Tooltip.AddTranslation(GameCulture.Chinese, "必要时自动使用氧气罐");
            DisplayName.AddTranslation(GameCulture.Russian, "Акваланг");
            Tooltip.AddTranslation(GameCulture.Russian, "Автоматически использует баки с кислородом, когда необходимо");
        }

	    public override void UpdateAccessory(Player player, bool hideVisual)
		{
            var aPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
            aPlayer.scuba = true;
		}
	}
}
