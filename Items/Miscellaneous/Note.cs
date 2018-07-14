using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Miscellaneous
{
    public class Note : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Note");
            Tooltip.SetDefault("'Somebody has written something on it.'\nUse to read");
            DisplayName.AddTranslation(GameCulture.Chinese, "纸条");
            Tooltip.AddTranslation(GameCulture.Chinese, "有人在上面写了些东西\n鼠标 <左> 键阅读");
            DisplayName.AddTranslation(GameCulture.Russian, "Записка");
            Tooltip.AddTranslation(GameCulture.Russian, "'Кто-то на ней что-то написал.'\nИспользуйте для прочтения");
        }

        public override void SetDefaults()
        {
            item.maxStack = 1;
            item.width = 32;
            item.height = 32;
            item.rare = 0;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = 3;
            item.useTurn = true;
        }

        public override bool UseItem(Player player)
        {
            var aPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
            aPlayer.OpenWindow = !aPlayer.OpenWindow;
            return true;
        }
    }
}
