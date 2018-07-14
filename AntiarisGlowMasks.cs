using System;
using Terraria;
using Terraria.ModLoader;

namespace Antiaris
{
    public static class AntiarisGlowMasks
    {
        const short Count = 10;
        public static short EnchantedBreastplate;
        public static short EnchantedHelmet;
        public static short SorcererRobe;
        public static short GooHelmet;
        public static short GooGreaves;
        public static short GooBreastplate;
        public static short GooBreastplateF;
        public static short GooSpear;
        public static short GooYoyo;
        public static short ShadowflameArrow;
        static short End;
        static bool Loaded;

        public static void Load()
        {
            Array.Resize(ref Main.glowMaskTexture, Main.glowMaskTexture.Length + AntiarisGlowMasks.Count);
            short i = (short)(Main.glowMaskTexture.Length - AntiarisGlowMasks.Count);
			
            Main.glowMaskTexture[i] = ModLoader.GetTexture("Antiaris/Glow/EnchantedBreastplate_GlowMask");
            AntiarisGlowMasks.EnchantedBreastplate = i;
            i++;
            Main.glowMaskTexture[i] = ModLoader.GetTexture("Antiaris/Glow/EnchantedHelmet_GlowMask");
            AntiarisGlowMasks.EnchantedHelmet = i;
            i++; 
			Main.glowMaskTexture[i] = ModLoader.GetTexture("Antiaris/Glow/SorcererRobe_GlowMask");
            AntiarisGlowMasks.SorcererRobe = i;
            i++;
			Main.glowMaskTexture[i] = ModLoader.GetTexture("Antiaris/Glow/GooHelmet_GlowMask");
            AntiarisGlowMasks.GooHelmet = i;
            i++;
			Main.glowMaskTexture[i] = ModLoader.GetTexture("Antiaris/Glow/GooGreaves_GlowMask");
            AntiarisGlowMasks.GooGreaves = i;
            i++;
			Main.glowMaskTexture[i] = ModLoader.GetTexture("Antiaris/Glow/GooBreastplate_GlowMask");
            AntiarisGlowMasks.GooBreastplate = i;
            i++;
			Main.glowMaskTexture[i] = ModLoader.GetTexture("Antiaris/Glow/GooBreastplateF_GlowMask");
            AntiarisGlowMasks.GooBreastplateF = i;
            i++;
			Main.glowMaskTexture[i] = ModLoader.GetTexture("Antiaris/Glow/GooSpear_GlowMask");
            AntiarisGlowMasks.GooSpear = i;
            i++;
			Main.glowMaskTexture[i] = ModLoader.GetTexture("Antiaris/Glow/GooYoyo_GlowMask");
            AntiarisGlowMasks.GooYoyo = i;
            i++;
			Main.glowMaskTexture[i] = ModLoader.GetTexture("Antiaris/Glow/ShadowflameArrow_GlowMask");
            AntiarisGlowMasks.ShadowflameArrow = i;
            i++;
            AntiarisGlowMasks.End = i;
            AntiarisGlowMasks.Loaded = true;
        }

        public static void Unload()
        {
            if (Main.glowMaskTexture.Length == AntiarisGlowMasks.End)
            {
                Array.Resize(ref Main.glowMaskTexture, Main.glowMaskTexture.Length - AntiarisGlowMasks.Count);
            }
            else if (Main.glowMaskTexture.Length > AntiarisGlowMasks.End && Main.glowMaskTexture.Length > AntiarisGlowMasks.Count)
            {
                for (int i = AntiarisGlowMasks.End - AntiarisGlowMasks.Count; i < AntiarisGlowMasks.End; i++)
                {
                    Main.glowMaskTexture[i] = ModLoader.GetTexture("Terraria/Item_0");
                }
            }
			
            AntiarisGlowMasks.Loaded = false;
            AntiarisGlowMasks.EnchantedBreastplate = 0;
            AntiarisGlowMasks.EnchantedHelmet = 0;
			AntiarisGlowMasks.SorcererRobe = 0;
			AntiarisGlowMasks.GooHelmet = 0;
			AntiarisGlowMasks.GooGreaves = 0;
			AntiarisGlowMasks.GooBreastplate = 0;
			AntiarisGlowMasks.GooBreastplateF = 0;
			AntiarisGlowMasks.GooSpear = 0;
			AntiarisGlowMasks.GooYoyo = 0;
			AntiarisGlowMasks.ShadowflameArrow = 0;
            AntiarisGlowMasks.End = 0;
        }
    }
}
