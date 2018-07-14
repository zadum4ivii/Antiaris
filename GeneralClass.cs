using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ModLoader;

namespace Antiaris
{
    public class GeneralClass : GlobalItem
    {
        public override bool UseItem(Item item, Player player)
		{
			if (item.type == mod.ItemType("BlazingHeart") && player.itemAnimation > 0 && player.statLifeMax >= 300 && player.statLifeMax < 400 && player.itemTime == 0)
			{		
				player.itemTime = (int)((float)item.useTime / PlayerHooks.TotalUseTimeMultiplier(player, item));
				player.statLifeMax += 10;
				player.statLifeMax2 += 10;
				player.statLife += 10;
				if (Main.myPlayer == player.whoAmI)
				{
					player.HealEffect(10, true);
				}
				AchievementsHelper.HandleSpecialEvent(player, 2);
			}
			if (item.type == mod.ItemType("DazzlingHeart") && player.itemAnimation > 0 && player.statLifeMax >= 400 && player.statLifeMax < 450 && player.itemTime == 0)
			{		
				player.itemTime = (int)((float)item.useTime / PlayerHooks.TotalUseTimeMultiplier(player, item));
				player.statLifeMax += 5;
				player.statLifeMax2 += 5;
				player.statLife += 5;
				if (Main.myPlayer == player.whoAmI)
				{
					player.HealEffect(5, true);
				}
				AchievementsHelper.HandleSpecialEvent(player, 2);
			}
			if (item.type == 1291 && player.itemAnimation > 0 && player.statLifeMax >= 450 && player.statLifeMax < 500 && player.itemTime == 0)
			{		
				player.itemTime = (int)((float)item.useTime / PlayerHooks.TotalUseTimeMultiplier(player, item));
				player.statLifeMax += 5;
				player.statLifeMax2 += 5;
				player.statLife += 5;
				if (Main.myPlayer == player.whoAmI)
				{
					player.HealEffect(5, true);
				}
				AchievementsHelper.HandleSpecialEvent(player, 2);
			}
			return base.UseItem(item, player);
		}

        public override bool CanUseItem(Item item, Player player)
		{
			if (item.type == 29)
		    {
				if (player.statLifeMax2 < 300)
					return true;
			    else
					return false;
			}
			if (item.type == mod.ItemType("BlazingHeart"))
			{
				if (player.statLifeMax2 >= 300 && player.statLifeMax2 < 400)
					return true;
			    else
					return false;
			}
			if (item.type == mod.ItemType("DazzlingHeart"))
			{
				if (player.statLifeMax2 >= 400 && player.statLifeMax2 < 450)
					return true;
			    else
					return false;
			}
			if (item.type == 1291)
			{
				if (player.statLifeMax2 >= 450 && player.statLifeMax2 < 500)
					return true;
			    else
					return false;
			}
			return base.CanUseItem(item, player);
		}
    }
}
