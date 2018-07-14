using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.Items.Weapons.Ranged.Bows
{
    public class LigneousBow : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 10;
            item.ranged = true;
            item.width = 24;
            item.height = 50;
            item.useTime = 40;
            item.useAnimation = 40;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 2;
            item.rare = 1;
            item.UseSound = SoundID.Item5;
            item.autoReuse = false;
            item.shoot = mod.ProjectileType("LigneousArrow");
            item.shootSpeed = 7f;
            item.value = Item.sellPrice(0, 0, 14, 0);
            item.useAmmo = AmmoID.Arrow;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ligneous Bow");
            Tooltip.SetDefault("Uses arrows as ammo\nTransforms arrows into lingeous arrows\nLingeous arrows explode into magic bushes that damage enemies");
            DisplayName.AddTranslation(GameCulture.Chinese, "木本植物");
            Tooltip.AddTranslation(GameCulture.Chinese, "1、将所有的箭变成木本植物\n2、木本植物箭接触物体爆炸后会出现魔法灌木丛伤害敌人");
            DisplayName.AddTranslation(GameCulture.Russian, "Древесный лук");
            Tooltip.AddTranslation(GameCulture.Russian, "Использует стрелы в качестве патронов\nПревращает стрелы в древесные стрелы\nДревесные стрелы взрываются в магические кусты, наносящие урон врагам");
        }

        public void OverhaulInit()
        {
            this.SetTag("bow");
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
            type = mod.ProjectileType("LigneousArrow");
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "NatureEssence", 15);
            recipe.AddIngredient(null, "Leaf", 22);
            recipe.AddIngredient(ItemID.Wood, 30);
            recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.AddRecipe();
        }
    }
}
