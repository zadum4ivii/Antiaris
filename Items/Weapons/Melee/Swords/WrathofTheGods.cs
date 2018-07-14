using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.Items.Weapons.Melee.Swords
{
    public class WrathofTheGods : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 57;
            item.melee = true;
            item.width = 60;
            item.height = 60;
            item.useTime = 24;
            item.useAnimation = 24;
            item.useStyle = 1;
            item.knockBack = 4.5f;
            item.value = Item.sellPrice(0, 8, 0, 0);
            item.rare = 5;
            item.UseSound = SoundID.Item71;
            item.autoReuse = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wrath of The Gods");
            DisplayName.AddTranslation(GameCulture.Russian, "Ярость богов");
            DisplayName.AddTranslation(GameCulture.Chinese, "诸神之怒");
        }

        public void OverhaulInit()
        {
            this.SetTag("broadsword");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            if (Antiaris.Thorium != null)
            {
                recipe.AddIngredient(Antiaris.Thorium.ItemType("BloodThirster"));
                recipe.AddIngredient(ItemID.SoulofNight, 26);
                recipe.AddIngredient(null, "WrathElement", 10);
                recipe.AddIngredient(ItemID.Ichor, 12);
                recipe.SetResult(this);
                recipe.AddTile(134);
                recipe.AddRecipe();
            }
        }
    }
}