using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.Items.Weapons.Melee.Swords
{
    public class DarkMoon : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 76;
            item.melee = true;
            item.width = 54;
            item.height = 60;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = 1;
            item.knockBack = 9f;
            item.value = Item.sellPrice(0, 12, 0, 0);
            item.rare = 8;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("TrueNightmareMagicCentral");
            item.shootSpeed = 22f;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dark Moon");
            DisplayName.AddTranslation(GameCulture.Russian, "Тёмная луна");
            DisplayName.AddTranslation(GameCulture.Chinese, "至白之夜");
            Tooltip.AddTranslation(GameCulture.Chinese, "在光标周围召唤一圈梦魇火焰\n“黑暗面，真相，无法逃脱的悲剧”");
            Tooltip.SetDefault("Summons a circle of nightmare flames around the cursor");
            Tooltip.AddTranslation(GameCulture.Russian, "Призывает кольцо из кошмарного пламени вокруг курсора");
        }

        public void OverhaulInit()
        {
            this.SetTag("broadsword");
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(4) == 0)
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 27);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Nightfall", 1);
            recipe.AddIngredient(ItemID.BrokenHeroSword, 1);
            recipe.SetResult(this);
            recipe.AddTile(134);
            recipe.AddRecipe();
        }
    }
}
