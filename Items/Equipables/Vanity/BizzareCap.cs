using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Vanity
{
    [AutoloadEquip(EquipType.Head)]
    public class BizzareCap : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 20;
            item.rare = 1;
            item.vanity = true;
			item.value = Item.buyPrice(0, 10, 0, 0);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bizzare Cap");
			Tooltip.SetDefault("'Good grief...'");
            DisplayName.AddTranslation(GameCulture.Chinese, "怪异的帽子");
			Tooltip.AddTranslation(GameCulture.Chinese, "“我的天哪...”");
            DisplayName.AddTranslation(GameCulture.Russian, "Волшебная кепка");
			Tooltip.AddTranslation(GameCulture.Russian, "'Ну и ну...'");
        }

        public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
		{
			drawAltHair = true;
		}

        public override void UpdateEquip(Player player)
        {
			player.yoraiz0rDarkness = true;
			var aPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
            aPlayer.bizzare = true;
		}

        public override void UpdateVanity(Player player, EquipType type)
		{
			player.yoraiz0rDarkness = true;
			var aPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
            aPlayer.bizzare = true;
		}
    }
}
