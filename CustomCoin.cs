using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.UI;
using Terraria.Localization;

namespace Antiaris
{
	public class CustomCoin : CustomCurrencySingleCoin
	{
	    public Color coinColor = new Color(170, 141, 121);
	    public CustomCoin(int coinItemID, long currencyCap) : base(coinItemID, currencyCap) { }

	    public override void GetPriceText(string[] lines, ref int currentLine, int price)
        {
            string IronCoin = Language.GetTextValue("Mods.Antiaris.IronCoin");
            var color = coinColor * ((float)Main.mouseTextColor / 255f);
            lines[currentLine++] = string.Format("[c/{0:X2}{1:X2}{2:X2}:{3} {4} {5}]", new object[]
                {
                    color.R,
                    color.G,
                    color.B,
                    Language.GetTextValue("LegacyTooltip.50"),
                    price,
                    IronCoin
                });
        }
	}
}
