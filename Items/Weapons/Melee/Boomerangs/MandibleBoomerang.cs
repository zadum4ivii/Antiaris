using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.Items.Weapons.Melee.Boomerangs
{
    public class MandibleBoomerang : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 28;
            item.melee = true;
            item.width = 24;
            item.height = 40;
            item.useTime = 20;
            item.shootSpeed = 12f;
            item.useAnimation = 20;
            item.useStyle = 1;
            item.knockBack = 3f;
            item.shoot = mod.ProjectileType("MandibleBoomerang");
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = 3;
            item.noUseGraphic = true;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mandible Boomerang");
            DisplayName.AddTranslation(GameCulture.Chinese, "蚁狮下颚回旋镖");
            DisplayName.AddTranslation(GameCulture.Russian, "Челюстный бумеранг");
        }

        public void OverhaulInit()
        {
            this.SetTag("boomerang");
        }

        public override bool CanUseItem(Player player)
		{
		    const int WheelMax = 1;
		    int Count = 0;
		    foreach (Projectile projectile in Main.projectile)
		    if (projectile.type == item.shoot && projectile.owner == item.owner && projectile.active)
			{	
		        Count++;
			}
		    return (Count > WheelMax) ? false : true;
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.WoodenBoomerang, 1);
            recipe.AddIngredient(ItemID.AntlionMandible, 6);
            recipe.AddIngredient(ItemID.SandBlock, 5);
			recipe.AddIngredient(null, "AntlionCarapace", 6);
            recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.AddRecipe();
        }
    }
}
