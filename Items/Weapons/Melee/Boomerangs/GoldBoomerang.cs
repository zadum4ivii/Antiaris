using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.Items.Weapons.Melee.Boomerangs
{
    public class GoldBoomerang : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 17;
            item.melee = true;
            item.width = 24;
            item.height = 46;
            item.useTime = 20;
            item.shootSpeed = 14f;
            item.useAnimation = 20;
            item.useStyle = 1;
            item.knockBack = 3f;
            item.shoot = mod.ProjectileType("GoldBoomerang");
            item.value = Item.sellPrice(0, 0, 16, 0);
            item.rare = 2;
            item.noUseGraphic = true;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gold Boomerang");
            Tooltip.SetDefault("Shoots magical sparks at nearby enemies");
            DisplayName.AddTranslation(GameCulture.Chinese, "金回旋镖");
            Tooltip.AddTranslation(GameCulture.Chinese, "对附近的敌人发射魔法火花");
            DisplayName.AddTranslation(GameCulture.Russian, "Золотой бумеранг");
            Tooltip.AddTranslation(GameCulture.Russian, "Выстреливает магическими искрами в ближайших врагов");
        }

        public void OverhaulInit()
        {
            this.SetTag("boomerang");
        }

        public override bool CanUseItem(Player player)
        {
            for (int i = 0; i < 1000; ++i)
            {
                if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == item.shoot)
                {
                    return false;
                }
            }
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.WoodenBoomerang, 1);
            recipe.AddIngredient(ItemID.GoldBar, 12);
            recipe.AddIngredient(ItemID.Ruby, 5);
            recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.AddRecipe();
        }
    }
}
