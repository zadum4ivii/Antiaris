using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Tiles.Miscellaneous
{
    public class EnchantedStone : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSpelunker[Type] = true;
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileMerge[TileID.Stone][Type] = true;
            Main.tileMerge[Type][TileID.Stone] = true;
            Main.tileMerge[TileID.Mud][Type] = true;
            Main.tileMerge[Type][TileID.Mud] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            drop = mod.ItemType("EnchantedShard");
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Enchanted Stone");
            name.AddTranslation(GameCulture.Russian, "Зачарованный камень");
            name.AddTranslation(GameCulture.Chinese, "附魔石");
			name.AddTranslation(GameCulture.Italian, "Pietra incantata");
            AddMapEntry(new Color(226, 58, 92), name);
            dustType = DustID.Stone;
            soundType = 21;
            minPick = 35;
            mineResist = 5f;
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = AntiarisPlayer.red / 255f;
            g = AntiarisPlayer.green / 255f;
            b = AntiarisPlayer.blue / 255f;
        }
    }
}