using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Summoning
{
    public class PixieStaff : ModItem
    {
        public override void HoldItem(Player player) { AntiarisGlowMask2.AddGlowMask(mod.ItemType(GetType().Name), "Antiaris/Glow/" + GetType().Name + "_GlowMask"); }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI) { AntiarisUtils.DrawItemGlowMaskWorld(spriteBatch, item, mod.GetTexture("Glow/" + GetType().Name + "_GlowMask"), rotation, scale); }

        public override void SetDefaults()
        {
            item.damage = 42;
            item.summon = true;
            item.mana = 14;
            item.width = 52;
            item.height = 52;
            item.useTime = 22;
            item.useAnimation = 22;
            item.useStyle = 1;
            item.noMelee = true;
            item.knockBack = 4.0f;
            item.value = Item.buyPrice(0, 9, 0, 0);
            item.rare = 5;
            item.UseSound = SoundID.Item44;
            item.shoot = mod.ProjectileType("Pixie");
            item.shootSpeed = 6f;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Staff of Pixie");
            Tooltip.SetDefault("Summons petite pixies that follow your cursor");
            DisplayName.AddTranslation(GameCulture.Chinese, "精灵法杖");
            Tooltip.AddTranslation(GameCulture.Chinese, "召唤一个跟随你光标移动的精灵\n“其实这个小精灵想吃了你的光标”");
            DisplayName.AddTranslation(GameCulture.Russian, "Посох пикси");
            Tooltip.AddTranslation(GameCulture.Russian, "Призывает маленьких пикси, который преследуют курсор игрока");
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (Main.rand.Next(2) == 0) Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("Pixie"), damage + 10, knockBack, player.whoAmI, 0.0f, 0.0f);
            else Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("Pixie2"), damage - 10, knockBack, player.whoAmI, 0.0f, 0.0f);
            return false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "GreenBigCrystal", 10);
            recipe.AddIngredient(null, "PurpleBigCrystal", 10);
            recipe.AddIngredient(ItemID.SoulofNight, 3);
            recipe.AddIngredient(null, "GreenCrystalPixieDust", 3);
            recipe.AddIngredient(null, "PurpleCrystalPixieDust", 3);
            recipe.SetResult(this);
            recipe.AddTile(134);
            recipe.AddRecipe();
        }
    }
}
