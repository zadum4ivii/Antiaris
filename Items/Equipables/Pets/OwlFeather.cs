using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Pets
{
	public class OwlFeather : ModItem
	{
	    public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.ZephyrFish);
			item.rare = 3;
			item.width = 22;
			item.height = 36;
			item.value = Item.sellPrice(0, 3, 0, 0);
			item.shoot = mod.ProjectileType("SnowOwl");
			item.buffType = mod.BuffType("SnowOwl");
		}

	    public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Owl Feather");
            Tooltip.SetDefault("Summons a pet snow owl");
            DisplayName.AddTranslation(GameCulture.Chinese, "鹰羽");
            Tooltip.AddTranslation(GameCulture.Chinese, "召唤一个雪鹰宠物");
            DisplayName.AddTranslation(GameCulture.Russian, "Перо совы");
            Tooltip.AddTranslation(GameCulture.Russian, "Призывает ручную снежную сову");
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