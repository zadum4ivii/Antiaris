using Terraria;
using Terraria.ModLoader;

namespace Antiaris.Dusts
{
	public class Sandstorm : ModDust
	{
	    public override void OnSpawn(Dust dust)
		{
            updateType = 106;
        }
	}
}