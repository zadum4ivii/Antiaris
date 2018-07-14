using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.Items.Weapons.Melee.Swords
{
    public class ForestClaymore : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 14;
            item.melee = true;
            item.width = 54;
            item.height = 66;
            item.useTime = 22;
            item.useAnimation = 22;
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = Item.sellPrice(0, 0, 16, 0);
            item.rare = 1;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useTurn = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Forest Claymore");
            DisplayName.AddTranslation(GameCulture.Russian, "Лесной клеймор");
            DisplayName.AddTranslation(GameCulture.Chinese, "森林大砍刀");
            Tooltip.AddTranslation(GameCulture.Chinese, "若击中敌人将在原地召唤一个可以伤害敌人的灌木丛");
            Tooltip.SetDefault("Hitting enemies will spawn a bush that damages enemies");
            Tooltip.AddTranslation(GameCulture.Russian, "Удар по врагам призывает куст, наносящий урон врагам");
        }

        public void OverhaulInit()
        {
            this.SetTag("broadsword");
            this.SetTag("flammable");
            this.SetTag("bluntHit");
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            int k = Projectile.NewProjectile(target.Center.X, target.Center.Y, 0f, 0f, mod.ProjectileType("LeafBush"), damage, knockback, player.whoAmI, 0.0f, 0.0f);
            Main.projectile[k].ranged = false; Main.projectile[k].melee = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "NatureEssence", 17);
            recipe.AddIngredient(null, "Leaf", 28);
            recipe.AddIngredient(ItemID.Wood, 35);
            recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.AddRecipe();
        }
    }
}
