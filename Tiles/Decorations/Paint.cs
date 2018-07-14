using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Antiaris.Tiles.Decorations
{
    public class Paint : ModTile
    {
        public override void SetDefaults()
        {
			Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 36;
            TileObjectData.newTile.DrawYOffset = 2;
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Paint");
            name.AddTranslation(GameCulture.Russian, "Краска");
			name.AddTranslation(GameCulture.Chinese, "颜料");
            AddMapEntry(new Color(210, 210, 210), name);
        }

        //public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        public override bool Drop(int i, int j)
        {
			int style = Main.tile[i, j].frameX / 18;
            int item = 0;
			switch (style)
			{
				case 0:
				item = ItemID.RedPaint;
				break;
				case 1:
				item = ItemID.OrangePaint;
				break;
				case 2:
				item = ItemID.YellowPaint;
				break;
				case 3:
				item = ItemID.LimePaint;
				break;
				case 4:
				item = ItemID.GreenPaint;
				break;
				case 5:
				item = ItemID.TealPaint;
				break;
				case 6:
				item = ItemID.CyanPaint;
				break;
				case 7:
				item = ItemID.SkyBluePaint;
				break;
				case 8:
				item = ItemID.BluePaint;
				break;
				case 9:
				item = ItemID.PurplePaint;
				break;
				case 10:
				item = ItemID.VioletPaint;
				break;
				case 11:
				item = ItemID.PinkPaint;
				break;
				case 12:
				item = ItemID.DeepRedPaint;
				break;
				case 13:
				item = ItemID.DeepOrangePaint;
				break;
				case 14:
				item = ItemID.DeepYellowPaint;
				break;
				case 15:
				item = ItemID.DeepLimePaint;
				break;
				case 16:
				item = ItemID.DeepGreenPaint;
				break;
				case 17:
				item = ItemID.DeepTealPaint;
				break;
				case 18:
				item = ItemID.DeepCyanPaint;
				break;
				case 19:
				item = ItemID.DeepSkyBluePaint;
				break;
				case 20:
				item = ItemID.DeepBluePaint;
				break;
				case 21:
				item = ItemID.DeepPurplePaint;
				break;
				case 22:
				item = ItemID.DeepVioletPaint;
				break;
				case 23:
				item = ItemID.DeepPinkPaint;
				break;
				case 24:
				item = ItemID.BlackPaint;
				break;
				case 25:
				item = ItemID.GrayPaint;
				break;
				case 26:
				item = ItemID.WhitePaint;
				break;
				case 27:
				item = ItemID.BrownPaint;
				break;
				case 28:
				item = ItemID.ShadowPaint;
				break;
				case 29:
				item = ItemID.NegativePaint;
				break;
			}
			Item.NewItem(i * 16, j * 16, 16, 16, item, 1, false, 0, false, false);
			return false;
        }
    }
}
