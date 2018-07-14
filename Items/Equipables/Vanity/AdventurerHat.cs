using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Vanity
{
    [AutoloadEquip(EquipType.Head)]
    public class AdventurerHat : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 12;
            item.rare = 1;
            item.vanity = true;
            item.value = Item.sellPrice(0, 0, 1, 0);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Adventurer's Hat");
            DisplayName.AddTranslation(GameCulture.Chinese, "冒险家的帽子");
            DisplayName.AddTranslation(GameCulture.Russian, "Шляпа путешественника");
        }

        public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
		{
			drawAltHair = true;
		}
    }
}

