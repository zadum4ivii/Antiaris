using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Ranged.Blunderbusses
{
    public class PlatinumHuntingBlunderbuss : ModItem
    {
        public override void HoldItem(Player player) { AntiarisGlowMask2.AddGlowMask(mod.ItemType(GetType().Name), "Antiaris/Glow/HuntingBlunderbuss_GlowMask"); }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI) { AntiarisUtils.DrawItemGlowMaskWorld(spriteBatch, item, mod.GetTexture("Glow/HuntingBlunderbuss_GlowMask"), rotation, scale); }

        public override void SetDefaults()
        {
            item.damage = 17;
            item.width = 60;
            item.height = 24;
            item.useTime = 25;
            item.useAnimation = 25;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 4f;
            item.ranged = true;
            item.value = Item.sellPrice(0, 0, 20, 0);
            item.rare = 0;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.shoot = 10;
            item.holdStyle = 3;
            item.shootSpeed = 12f;
			item.useAmmo = mod.ItemType("Buckshot");
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Platinum Hunting Blunderbuss");
            Tooltip.SetDefault("Uses buckshots as ammo\nRight click to zoom out");
            DisplayName.AddTranslation(GameCulture.Chinese, "铂金火铳");
            Tooltip.AddTranslation(GameCulture.Chinese, "1、使用火铳弹作为弹药\n2、按住鼠标 <右> 键拉远镜头");
            DisplayName.AddTranslation(GameCulture.Russian, "Платиновый охотничий мушкетон");
            Tooltip.AddTranslation(GameCulture.Russian, "Использует картечь в качестве патронов\nНажмите правую кнопку мыши, чтобы прицелиться");
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-6, 0);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BlunderbussBase", 1);
            recipe.AddIngredient(ItemID.PlatinumBar, 14);
            recipe.AddIngredient(ItemID.Ruby, 2);
            recipe.AddIngredient(ItemID.Lens, 3);
            recipe.AddIngredient(ItemID.StoneBlock, 15);
            recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.AddRecipe();
        }
    }
}
