using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.Items.Weapons.Ranged.Bows
{
    public class SteelBow : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 7;
            item.ranged = true;
            item.width = 26;
            item.height = 52;
            item.useTime = 27;
            item.useAnimation = 27;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 2;
            item.rare = 1;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shoot = 1;
            item.shootSpeed = 11f;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.useAmmo = AmmoID.Arrow;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Steel Bow");
            DisplayName.AddTranslation(GameCulture.Chinese, "钢弓");
            DisplayName.AddTranslation(GameCulture.Russian, "Стальной лук");
        }

        public void OverhaulInit()
        {
            this.SetTag("bow");
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-2, 0);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			return true;
		}
    }
}
