using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.Items.Weapons.Melee.Swords
{
	public class SwordOfBlackWhite : ModItem
	{
	    public override Color? GetAlpha(Color lightColor) { return Color.White; }

	    public override void SetDefaults()
		{
            item.damage = 56;
            item.melee = true;
            item.width = 60;
            item.height = 60;
            item.useTime = 26;
            item.useAnimation = 26;
            item.useStyle = 1;
            item.knockBack = 4.4f;
            item.value = Item.sellPrice(0, 11, 25, 0);
            item.rare = 5;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("YinYang");
			item.shootSpeed = 4.4f;
		}

	    public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sword of Black & White");
            DisplayName.AddTranslation(GameCulture.Chinese, "阴阳长剑");
			Tooltip.AddTranslation(GameCulture.Chinese, "“汇阳合阴 心安觉天静”——《随缘》");
            DisplayName.AddTranslation(GameCulture.Russian, "Меч чёрного и белого");
        }

	    public void OverhaulInit()
        {
            this.SetTag("broadsword");
        }

	    public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.NightsEdge);
            recipe.AddIngredient(ItemID.LightShard, 4);
            recipe.AddIngredient(ItemID.DarkShard, 4);
            recipe.AddIngredient(ItemID.SoulofNight, 7);
            recipe.AddIngredient(ItemID.SoulofLight, 7);
            recipe.SetResult(this);
            recipe.AddTile(134);
            recipe.AddRecipe();
        }
	}
}
