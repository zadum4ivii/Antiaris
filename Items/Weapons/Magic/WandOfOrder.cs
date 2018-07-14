using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Magic
{
    public class WandOfOrder : ModItem
    {
        public override void HoldItem(Player player) { AntiarisGlowMask2.AddGlowMask(mod.ItemType(GetType().Name), "Antiaris/Glow/" + GetType().Name + "_GlowMask"); }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI) { AntiarisUtils.DrawItemGlowMaskWorld(spriteBatch, item, mod.GetTexture("Glow/" + GetType().Name + "_GlowMask"), rotation, scale); }

        public override void SetDefaults()
        {
            item.damage = 47;
            item.magic = true;
            item.mana = 17;
            item.width = 36;
            item.height = 36;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 2.5f;
            item.value = Item.sellPrice(0, 6, 50, 0);
            item.rare = 5;
            item.UseSound = SoundID.DD2_BetsysWrathShot;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("OrderEnergy");
            item.shootSpeed = 11.5f;
            Item.staff[item.type] = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wand of Order");
            Tooltip.SetDefault("Creates a spliting energy bolt\n'The powers of Aer and Aqua pulse within this wand'");
			DisplayName.AddTranslation(GameCulture.Chinese, "秩序权杖");
			Tooltip.AddTranslation(GameCulture.Chinese, "召唤一个可以分裂的闪电能量\n“这个法杖蕴含了空气与湍流的力量”");
            DisplayName.AddTranslation(GameCulture.Russian, "Посох порядка");
            Tooltip.AddTranslation(GameCulture.Russian, "Создает \n'Силы Аэра и Аквы пульсируют в этом посохе'");
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 40f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			position += Vector2.Normalize(new Vector2(speedX, speedY)) * 50.0f;
			return true;
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "WandOfLightRage");
            recipe.AddIngredient(null, "WandOfTorrent");
            recipe.AddIngredient(ItemID.HallowedBar, 10);
            recipe.AddIngredient(ItemID.GoldDust, 10);
            recipe.AddIngredient(ItemID.SoulofLight, 5);
            recipe.SetResult(this);
            recipe.AddTile(TileID.DemonAltar);
            recipe.AddRecipe();
        }
    }
}
