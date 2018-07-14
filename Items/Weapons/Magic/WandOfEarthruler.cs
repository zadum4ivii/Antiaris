using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Magic
{
    public class WandOfEarthruler : ModItem
    {
        public override void HoldItem(Player player) { AntiarisGlowMask2.AddGlowMask(mod.ItemType(GetType().Name), "Antiaris/Glow/" + GetType().Name + "_GlowMask"); }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI) { AntiarisUtils.DrawItemGlowMaskWorld(spriteBatch, item, mod.GetTexture("Glow/" + GetType().Name + "_GlowMask"), rotation, scale); }

        public override void SetDefaults()
        {
            item.damage = 21;
			item.channel = true;
            item.magic = true;
            item.mana = 4;
            item.width = 36;
            item.height = 36;
            item.useTime = 34;
            item.useAnimation = 34;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 0.0f;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = 3;
            item.UseSound = SoundID.Item69;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("NatureBeam");
            item.shootSpeed = 10.0f;
            Item.staff[item.type] = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wand of Earthruler");
            Tooltip.SetDefault("Casts a damaging beam of earth energy\n'Forged with Terra'");
			DisplayName.AddTranslation(GameCulture.Chinese, "自然统领之杖");
			Tooltip.AddTranslation(GameCulture.Chinese, "发射具有破坏性的自然能量射线\n“大地之造物”");
            DisplayName.AddTranslation(GameCulture.Russian, "Посох природы");
            Tooltip.AddTranslation(GameCulture.Russian, "Выпускает наносящий урон луч земной энергии\n'Сковано из Терры'");
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			position += Vector2.Normalize(new Vector2(speedX, speedY)) * 40.0f;
			return true;
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "WandCore");
            recipe.AddIngredient(ItemID.Bone, 3);
            recipe.AddIngredient(ItemID.GoldBar, 5);
            recipe.AddIngredient(ItemID.Lens, 3);
            recipe.AddIngredient(ItemID.JungleSpores, 10);
            recipe.AddIngredient(ItemID.Emerald, 10);
			recipe.AddIngredient(ItemID.ManaCrystal);
            recipe.SetResult(this);
            recipe.AddTile(TileID.DemonAltar);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "WandCore");
            recipe.AddIngredient(ItemID.Bone, 3);
            recipe.AddIngredient(ItemID.PlatinumBar, 5);
            recipe.AddIngredient(ItemID.Lens, 3);
            recipe.AddIngredient(ItemID.JungleSpores, 10);
            recipe.AddIngredient(ItemID.Emerald, 10);
			recipe.AddIngredient(ItemID.ManaCrystal);
            recipe.SetResult(this);
            recipe.AddTile(TileID.DemonAltar);
            recipe.AddRecipe();
        }
    }
}
