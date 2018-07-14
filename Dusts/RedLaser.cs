using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Antiaris.Dusts
{
	public class RedLaser : ModDust
	{
	    public override void OnSpawn(Dust dust)
		{
            dust.velocity *= 0.8f;
            dust.noGravity = true;
            dust.noLight = true;
            dust.scale = 1.6f;
        }

	    public override Color? GetAlpha(Dust dust, Color lightColor)
        {
            return Color.White;
        }

	    public override bool Update(Dust dust)
        {
            dust.position += dust.velocity;
            dust.rotation += dust.velocity.X * 0.5f;
            dust.scale *= 0.9f;
            var scale = (double)dust.scale;
            Lighting.AddLight(dust.position, 0.8f, 0.1f, 0.8f);
            if ((double)dust.scale < 0.174999997019768)
            {
                dust.active = false;
            }
            return false;
        }
	}
}