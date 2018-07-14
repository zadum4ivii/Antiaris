using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Antiaris.Tiles.Decorations
{
    public class Accessories1 : ModTile
    {
        public override void SetDefaults()
        {
			Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.Table | AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.DrawYOffset = 2;
            TileObjectData.newTile.StyleWrapLimit = 36;
            TileObjectData.addTile(Type);
        }

        public override void RightClick(int x, int y)
		{
			int style = Main.tile[x, y].frameX / 18;
			if(style >= 12 && style <= 17)
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

        public override bool Drop(int i, int j)
        {
			int style = Main.tile[i, j].frameX / 18;
            int item = 0;
			switch (style)
			{
				case 0:
				item = ItemID.Aglet;
				break;
				case 1:
				item = ItemID.AnkletoftheWind;
				break;
				case 2:
				item = ItemID.BandofRegeneration;
				break;
				case 3:
				item = ItemID.BandofStarpower;
				break;
				case 4:
				item = ItemID.CelestialMagnet;
				break;
				case 5:
				item = ItemID.CharmofMyths;
				break;
				case 6:
				item = ItemID.ManaRegenerationBand;
				break;
				case 7:
				item = ItemID.PhilosophersStone;
				break;
				case 8:
				item = ItemID.BlizzardinaBottle;
				break;
				case 9:
				item = ItemID.CloudinaBottle;
				break;
				case 10:
				item = ItemID.SandstorminaBottle;
				break;
				case 11:
				item = ItemID.FartinaJar;
				break;
				case 12:
				item = ItemID.CopperWatch;
				break;
				case 13:
				item = ItemID.TinWatch;
				break;
				case 14:
				item = ItemID.SilverWatch;
				break;
				case 15:
				item = ItemID.TungstenWatch;
				break;
				case 16:
				item = ItemID.GoldWatch;
				break;
				case 17:
				item = ItemID.PlatinumWatch;
				break;
				case 18:
				item = ItemID.LaserRuler;
				break;
				case 19:
				item = ItemID.TallyCounter;
				break;
				case 20:
				item = ItemID.FishFinder;
				break;
				case 21:
				item = ItemID.DepthMeter;
				break;
				case 22:
				item = ItemID.FishermansGuide;
				break;
				case 23:
				item = ItemID.LuckyCoin;
				break;
				case 24:
				item = ItemID.LuckyHorseshoe;
				break;
				case 25:
				item = ItemID.BlackCounterweight;
				break;
				case 26:
				item = ItemID.BlueCounterweight;
				break;
				case 27:
				item = ItemID.GreenCounterweight;
				break;
				case 28:
				item = ItemID.PurpleCounterweight;
				break;
				case 29:
				item = ItemID.RedCounterweight;
				break;
				case 30:
				item = ItemID.YellowCounterweight;
				break;
				case 31:
				item = ItemID.CrossNecklace;
				break;
				case 32:
				item = ItemID.Bezoar;
				break;
				case 33:
				item = ItemID.Vitamins;
				break;
				case 34:
				item = ItemID.GravityGlobe;
				break;
				case 35:
				item = ItemID.ShinyStone;
				break;
			}
			Item.NewItem(i * 16, j * 16, 16, 16, item, 1, false, 0, false, false);
			return false;
        }
    }
}