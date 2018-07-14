using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Pets
{
	public class CalmnessRing : ModItem
	{
	    public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.ZephyrFish);
			item.rare = 1;
			item.width = 24;
			item.height = 30;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.shoot = mod.ProjectileType("CalmnessSpirit");
			item.buffType = mod.BuffType("CalmnessSpirit");
		}

	    public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Calmness Ring");
            Tooltip.SetDefault("Summons a friendly calmness spirit");
            DisplayName.AddTranslation(GameCulture.Chinese, "宁静之戒");
            Tooltip.AddTranslation(GameCulture.Chinese, "召唤一个友好的宁静灵魂");
            DisplayName.AddTranslation(GameCulture.Russian, "Кольцо спокойствия");
            Tooltip.AddTranslation(GameCulture.Russian, "Призывает ручного духа спокойствия");
        }

	    public override void UseStyle(Player player)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(item.buffType, 3600, true);
			}
		}
	}
}