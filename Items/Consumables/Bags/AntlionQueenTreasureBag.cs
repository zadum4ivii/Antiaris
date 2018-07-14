using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Bags
{
    public class AntlionQueenTreasureBag : ModItem
    {
        public override void SetDefaults()
        {
            item.maxStack = 999;
            item.consumable = true;
            item.width = 36;
            item.height = 32;
            item.rare = 9;
			item.expert = true;
			bossBagNPC = mod.NPCType("AntlionQueen");
        }
		
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Treasure Bag");
            Tooltip.SetDefault("<right> to open");
            DisplayName.AddTranslation(GameCulture.Chinese, "宝藏袋");
            Tooltip.AddTranslation(GameCulture.Chinese, "<right>来打开");
            DisplayName.AddTranslation(GameCulture.Russian, "Мешок с сокровищами");
            Tooltip.AddTranslation(GameCulture.Russian, "<right>, чтобы открыть");
        }
		
		public override void OpenBossBag(Player player)
        {
            player.QuickSpawnItem(mod.ItemType("AntlionQueenClaw"));
            player.QuickSpawnItem(ItemID.GoldCoin, 6);
			player.QuickSpawnItem(ItemID.HealingPotion, Main.rand.Next(4,12));
            player.QuickSpawnItem(mod.ItemType("SandstormScroll"), Main.rand.Next(2, 4));
            player.QuickSpawnItem(mod.ItemType("AntlionCarapace"), Main.rand.Next(30,50));
			
            if (Main.rand.Next(7) == 0)
            {
                player.QuickSpawnItem(mod.ItemType("AntlionQueenMask"));
            }
            switch(Main.rand.Next(4))
			{
				case 0:
					player.QuickSpawnItem(mod.ItemType("DesertRage"));
					break;
				case 1:
					player.QuickSpawnItem(mod.ItemType("ThousandNeedles"));
					break;
				case 2:
					player.QuickSpawnItem(mod.ItemType("AntlionLongbow"));
					break;
				case 3:
					player.QuickSpawnItem(mod.ItemType("AntlionStave"));
					break;
			}
			if (Main.rand.Next(20) == 0)
			{
				player.QuickSpawnItem(mod.ItemType("AntlionQueenEgg"));
			}				
        }
	}
}