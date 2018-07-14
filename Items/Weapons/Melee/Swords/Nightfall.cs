using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.Items.Weapons.Melee.Swords
{
    public class Nightfall : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 54;
            item.melee = true;
            item.width = 50;
            item.height = 54;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = 1;
            item.knockBack = 4.5f;
            item.value = Item.sellPrice(0, 8, 0, 0);
            item.rare = 5;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("NightmareMagicCentral");
            item.shootSpeed = 0f;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nightfall");
            DisplayName.AddTranslation(GameCulture.Russian, "Сумерки");
            DisplayName.AddTranslation(GameCulture.Chinese, "虚伪恶行");
            Tooltip.AddTranslation(GameCulture.Chinese, "召唤一圈围绕着玩家旋转的梦魇之火\n“我听到了....像是孩子的悲鸣声...”");
            Tooltip.SetDefault("Summons a circle of nightmare flames around the player on swing");
            Tooltip.AddTranslation(GameCulture.Russian, "При взмахе призывает кольцо из кошмарного пламени вокруг игрока");
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
            recipe.AddIngredient(ItemID.NightsEdge, 1);
            recipe.AddIngredient(ItemID.SoulofNight, 26);
			recipe.AddIngredient(null, "WrathElement", 10);
			recipe.AddIngredient(ItemID.CursedFlame, 12);
            recipe.SetResult(this);
            recipe.AddTile(134);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.NightsEdge, 1);
            recipe.AddIngredient(ItemID.SoulofNight, 26);
			recipe.AddIngredient(null, "WrathElement", 10);
			recipe.AddIngredient(ItemID.Ichor, 12);
            recipe.SetResult(this);
            recipe.AddTile(134);
            recipe.AddRecipe();
        }
    }
}
