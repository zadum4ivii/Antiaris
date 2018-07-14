using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Placeables.MusicBoxes
{
	public class TowerKeeperMusicBox1 : ModItem
	{
	    public override void SetDefaults()
		{
			item.useStyle = 1;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = mod.TileType("TowerKeeperMusicBox1");
			item.width = 28;
			item.height = 32;
			item.rare = 4;
			item.value = 100000;
			item.accessory = true;
		}

	    public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Music Box (Tower Keeper)");
            DisplayName.AddTranslation(GameCulture.Chinese, "音乐盒（守塔魔像）");
            DisplayName.AddTranslation(GameCulture.Russian, "Музыкальная шкатулка (Хранитель башни)");
        }
	}
}
