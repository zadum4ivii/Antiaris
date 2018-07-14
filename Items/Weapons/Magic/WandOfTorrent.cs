using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.Items.Weapons.Magic
{
    public class WandOfTorrent : ModItem
    {
        public override void HoldItem(Player player) { AntiarisGlowMask2.AddGlowMask(mod.ItemType(GetType().Name), "Antiaris/Glow/" + GetType().Name + "_GlowMask"); }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI) { AntiarisUtils.DrawItemGlowMaskWorld(spriteBatch, item, mod.GetTexture("Glow/" + GetType().Name + "_GlowMask"), rotation, scale); }

        public override void SetDefaults()
        {
            item.damage = 26;
            item.magic = true;
            item.mana = 11;
            item.width = 36;
            item.height = 36;
            item.useTime = 26;
            item.useAnimation = 26;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 5.5f;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = 3;
            item.UseSound = SoundID.Item87;
            item.autoReuse = false;
            item.shoot = mod.ProjectileType("Torrent");
            item.shootSpeed = 6.0f;
            Item.staff[item.type] = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wand of Torrent");
            Tooltip.SetDefault("Casts a water spit which splits into two when hits enemies\n'Forged with Aqua'");
			DisplayName.AddTranslation(GameCulture.Chinese, "湍流之杖");
			Tooltip.AddTranslation(GameCulture.Chinese, "发射一个击中物体会一分为二的水珠\n“大海之造物”");
            DisplayName.AddTranslation(GameCulture.Russian, "Посох потока");
            Tooltip.AddTranslation(GameCulture.Russian, "Выпускает водную струю, которая распадается на две при попадании по мобу\n'Сковано из Аквы'");
        }

        public void OverhaulInit()
        {
            this.SetTag("waterDamage");
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 40f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
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
            recipe.AddIngredient(ItemID.Waterleaf, 10);
            recipe.AddIngredient(ItemID.Sapphire, 10);
            recipe.AddIngredient(ItemID.ManaCrystal);
            recipe.SetResult(this);
            recipe.AddTile(TileID.DemonAltar);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "WandCore");
            recipe.AddIngredient(ItemID.Bone, 3);
            recipe.AddIngredient(ItemID.PlatinumBar, 5);
            recipe.AddIngredient(ItemID.Lens, 3);
            recipe.AddIngredient(ItemID.Waterleaf, 10);
            recipe.AddIngredient(ItemID.Sapphire, 10);
            recipe.AddIngredient(ItemID.ManaCrystal);
            recipe.SetResult(this);
            recipe.AddTile(TileID.DemonAltar);
            recipe.AddRecipe();
        }
    }
}
