using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Mounts
{
    public class AntlionQueenEgg : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 36;
            item.height = 34;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = Item.sellPrice(0, 0, 15, 0);
            item.rare = 8;
            item.UseSound = SoundID.Item81;
            item.noMelee = true;
            item.mountType = mod.MountType("LilSwarmer");
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Antlion Queen Egg");
            Tooltip.SetDefault("Summons a rideable Lil' Swarmer mount");
            DisplayName.AddTranslation(GameCulture.Chinese, "蚁狮女王之卵");
            Tooltip.AddTranslation(GameCulture.Chinese, "召唤一个可骑乘的蚁狮蜂");
            DisplayName.AddTranslation(GameCulture.Russian, "Яйцо Королевы муравьиных львов");
            Tooltip.AddTranslation(GameCulture.Russian, "Призывает наездного маленького муравьиного льва");
        }
    }
}
