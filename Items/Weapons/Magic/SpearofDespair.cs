using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Magic
{
	public class SpearofDespair : ModItem
	{
	    public override void SetDefaults()
		{
			item.useStyle = 1;
			item.useAnimation = 18;
			item.useTime = 18;
			item.autoReuse = true;
			item.rare = 4;
			item.width = 52;
			item.height = 52;
			item.UseSound = SoundID.Item8;
			item.damage = 25;
			item.knockBack = 3;
			item.mana = 10;
			item.shoot = mod.ProjectileType("SpearofDespair");
			item.shootSpeed = 16f;
			item.noMelee = true; 
			item.noUseGraphic = true;
			item.magic = true;
            item.value = Item.sellPrice(0, 15, 0, 0);
        }

	    public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spear of Despair");
			DisplayName.AddTranslation(GameCulture.Russian, "Копье отчаяния");
            DisplayName.AddTranslation(GameCulture.Chinese, "绝望");
            Tooltip.AddTranslation(GameCulture.Chinese, "发射一把可穿透敌人的魔法长枪，撞击物块后变成魔法球返回到自身手里");
            Tooltip.SetDefault("Shoots out a magical spear\nThe spear summons a sphere on hit that pierces through enemies dealing damage and returns to the player");
			Tooltip.AddTranslation(GameCulture.Russian, "Выстреливает магическим копьём\nКопьё при попадании призывает сферу, которая пролетает сквозь врагов, нанося урон, и возвращается к игроку");
		}
	}
}
