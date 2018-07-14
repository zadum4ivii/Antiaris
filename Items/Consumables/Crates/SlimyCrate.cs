using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Crates
{
	public class SlimyCrate : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 32;
			item.rare = 2;
			item.maxStack = 99;
			item.createTile = mod.TileType("SlimyCrate");
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Slimy Crate");
			Tooltip.SetDefault("<right> to open");
            DisplayName.AddTranslation(GameCulture.Chinese, "粘液板条箱");
            Tooltip.AddTranslation(GameCulture.Chinese, "<right>来打开");
			DisplayName.AddTranslation(GameCulture.Russian, "Слизневый ящик");
			Tooltip.AddTranslation(GameCulture.Russian, "<right>, чтобы открыть");
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void RightClick(Player player)
		{
			player.QuickSpawnItem(ItemID.Gel, Main.rand.Next(45,70));
			player.QuickSpawnItem(ItemID.PinkGel, Main.rand.Next(10,20));
			player.QuickSpawnItem(ItemID.GoldCoin, Main.rand.Next(5,10));
			if(Main.rand.Next(6) == 0)
			{
				player.QuickSpawnItem(ItemID.SlimeCrown);
			}
		}

        public override void PostUpdate()
        {
            if (item.wet || item.lavaWet)
            {
                if (item.velocity.Y > 0.86f)
                {
                    item.velocity.Y = item.velocity.Y * 0.9f;
                }
                item.velocity.Y = item.velocity.Y - 0.6f;
                if (item.velocity.Y < -2f)
                {
                    item.velocity.Y = -2f;
                }
            }
        }
    }
}