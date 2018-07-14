using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.Items.Tools.Pickaxes
{
    public class SteelShovel : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 2;
            item.melee = true;
            item.width = 34;
            item.height = 34;
            item.useTime = 16;
            item.useAnimation = 24;
            item.useStyle = 1;
            item.knockBack = 2;
            item.value = Item.sellPrice(0, 0, 2, 0);
            item.rare = 1;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useTurn = true;
            item.pick = 60;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Steel Shovel");
			Tooltip.SetDefault("Can dig only soils");
            DisplayName.AddTranslation(GameCulture.Chinese, "铁铲");
			Tooltip.AddTranslation(GameCulture.Chinese, "只能挖掘沙土");
            DisplayName.AddTranslation(GameCulture.Russian, "Стальная лопата");
			Tooltip.AddTranslation(GameCulture.Russian, "Может копать только почвы");
        }

        public void OverhaulInit()
        {
            this.SetTag("tool");
        }
    }
}