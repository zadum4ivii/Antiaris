using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Tools
{
    public class EmeraldNet : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 44;
            item.height = 50;
            item.useTime = 18;
            item.useAnimation = 18;
            item.useStyle = 1;
            item.value = Item.sellPrice(0, 25, 0, 0);
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useTurn = true;
            item.rare = 4;
            item.scale = 1.2f;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Emerald Net");
            Tooltip.SetDefault("Allows to catch slimes and get green goo\nOnly works if player has Royal Gel equipped");
            DisplayName.AddTranslation(GameCulture.Chinese, "翡绿捕虫网");
            Tooltip.AddTranslation(GameCulture.Chinese, "当装备皇家凝胶时可以捕获史莱姆和获取绿色凝胶");
            DisplayName.AddTranslation(GameCulture.Russian, "Изумрудный сачок");
            Tooltip.AddTranslation(GameCulture.Russian, "Позволяет ловить слизней и получать зеленую слизь\nРаботает только если на игроке надет Королевский Гель");
        }
    }
}
