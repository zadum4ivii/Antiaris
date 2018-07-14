using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Consumables.Flasks
{
    public class FlaskofShadowflame : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 34;
            item.useTurn = true;
            item.maxStack = 30;
            item.rare = 5;
            item.useAnimation = 16;
            item.useTime = 16;
            item.useStyle = 2;
            item.buffType = mod.BuffType("WeaponImbueShadowflame");
            item.buffTime = 72000;
            item.UseSound = SoundID.Item3;
            item.consumable = true;
            item.value = Item.sellPrice(0, 0, 6, 0);
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flask of Shadowflame");
            Tooltip.SetDefault("Melee attacks inflict shadowflame on enemies");
            DisplayName.AddTranslation(GameCulture.Chinese, "暗影火药水");
            Tooltip.AddTranslation(GameCulture.Chinese, "近战攻击使敌人被暗影火点燃");
            DisplayName.AddTranslation(GameCulture.Russian, "Флакон теневого пламени");
            Tooltip.AddTranslation(GameCulture.Russian, "Ближние атаки накладывают на врагов теневое пламя");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(null, "Shadowflame", 2);
            recipe.SetResult(this);
            recipe.AddTile(243);
            recipe.AddRecipe();
        }
    }
}
