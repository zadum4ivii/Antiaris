using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Antiaris.Tiles.Decorations 
{
    public class WallClock : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 36;
			TileObjectData.newTile.CoordinateHeights = new int[]
            {
                16,
                16
            };
			TileObjectData.newTile.Width = 2; 
			TileObjectData.newTile.Height = 2;
            TileObjectData.addTile(Type);
        }

        public override void RightClick(int x, int y)
        {
            int style = Main.tile[x, y].frameX / 18;
            if (style >= 12 && style <= 17)
            {
                string text = "AM";
                double time = Main.time;
                if (!Main.dayTime)
                {
                    time += 54000.0;
                }
                time = time / 86400.0 * 24.0;
                time = time - 7.5 - 12.0;
                if (time < 0.0)
                {
                    time += 24.0;
                }
                if (time >= 12.0)
                {
                    text = "PM";
                }
                int intTime = (int)time;
                double deltaTime = time - intTime;
                deltaTime = ((int)(deltaTime * 60.0));
                string text2 = string.Concat(deltaTime);
                if (deltaTime < 10.0)
                {
                    text2 = "0" + text2;
                }
                if (intTime > 12)
                {
                    intTime -= 12;
                }
                if (intTime == 0)
                {
                    intTime = 12;
                }
                var newText = string.Concat("Time: ", intTime, ":", text2, " ", text);
                Main.NewText(newText, 255, 240, 20);
            }
        }

        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if(Main.tile[i, j].frameX == 0 && Main.tile[i, j].frameY == 0)
            {
                Item.NewItem(i * 16, j * 16, 48, 48, mod.ItemType("WallClock"), 1, false, 0, false, false);
            }
        }
    }
}
