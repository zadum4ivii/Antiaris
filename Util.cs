using Terraria;

namespace Antiaris
{
	public static class Util
	{
	    public static bool ConsumeAmmo(ref Player player, short ammo)
        {
            for (int i = 0; i < player.inventory.Length; i++)
            {
                Item item = player.inventory[i];
                if (item.type == ammo && item.stack > 0)
                {
                    item.stack--;
                    if (item.stack <= 0)
                    {
                        item = new Item();
                    }
                    return true;
                }
            }
            return false;
        }
	}
}