using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Antiaris.Dusts
{
	public class Order : ModDust
	{
	    public override Color? GetAlpha(Dust dust, Color lightColor) { return Color.White; }

	    public override void OnSpawn(Dust dust)
		{
            updateType = 228;
        }
	}
}