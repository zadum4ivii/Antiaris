using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Mounts
{
    public class EmeraldKey : ModItem
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
            item.mountType = mod.MountType("EmeraldSlime");
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Emerald Key");
            Tooltip.SetDefault("Summons a rideable Emerald Slime mount");
            DisplayName.AddTranslation(GameCulture.Chinese, "翡绿之匙");
            Tooltip.AddTranslation(GameCulture.Chinese, "召唤翡绿史莱姆坐骑");
            DisplayName.AddTranslation(GameCulture.Russian, "Изумрудный ключ");
            Tooltip.AddTranslation(GameCulture.Russian, "Призывает наездного изумрудного слизня");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "LiquifiedGoo", 3);
            recipe.AddIngredient(ItemID.GoldenKey, 1);
            recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.AddRecipe();
        }
    }
}
