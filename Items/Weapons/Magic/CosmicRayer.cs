using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Magic
{
    public class CosmicRayer : ModItem
    {
        public override void HoldItem(Player player) { AntiarisGlowMask2.AddGlowMask(mod.ItemType(GetType().Name), "Antiaris/Glow/" + GetType().Name + "_GlowMask"); }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI) { AntiarisUtils.DrawItemGlowMaskWorld(spriteBatch, item, mod.GetTexture("Glow/" + GetType().Name + "_GlowMask"), rotation, scale); }

        public override void SetDefaults()
        {
            item.damage = 24;
            item.magic = true;
            item.width = 60;
            item.height = 32;
            item.useTime = 16;
            item.useAnimation = 16;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 3;
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = 3;
            item.UseSound = SoundID.Item12;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("CosmicRay");
            item.shootSpeed = 6f;
            item.mana = 6;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cosmic Rayer");
            Tooltip.SetDefault("Shoots red piercing beam");
            DisplayName.AddTranslation(GameCulture.Chinese, "宇宙辐射");
            Tooltip.AddTranslation(GameCulture.Chinese, "发射红色穿透性镭射");
            DisplayName.AddTranslation(GameCulture.Russian, "Космический лучевик");
            Tooltip.AddTranslation(GameCulture.Russian, "Стреляет красным проникающим лучом");
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-6, 0);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SpaceGun);
            recipe.AddIngredient(ItemID.MeteoriteBar, 12);
            recipe.AddIngredient(ItemID.Ruby, 3);
			recipe.AddIngredient(ItemID.Amethyst, 3);
			recipe.AddIngredient(ItemID.FallenStar, 7);
            recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.AddRecipe();
        }
    }
}
