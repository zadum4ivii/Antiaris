using Terraria;
using Terraria.ModLoader;

namespace Antiaris.Dusts
{
    public class SVDMG : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
			dust.scale = 0.75f;
        }

        public override bool Update(Dust dust)
        {
            dust.scale -= 0.1f;
            if (dust.scale < 0.3f)
            {
                dust.active = false;
            }
            else
            {
                float strength = dust.scale * 1.4f;
                if (strength > 1f)
                {
                    strength = 2f;
                }
                Lighting.AddLight(dust.position, 0.6f * strength, 1.0f * strength, 1.8f * strength);
            }
            return false;
        }
    }
}