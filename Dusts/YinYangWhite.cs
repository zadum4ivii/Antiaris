using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Antiaris.Dusts
{
	public class YinYangWhite : ModDust
	{
	    public override Color? GetAlpha(Dust dust, Color lightColor) { return Color.White; }

	    public override void OnSpawn(Dust dust)
		{
            dust.noLight = true;
            updateType = 63;
        }
	}
}