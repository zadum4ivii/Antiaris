using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.Items.Weapons.Magic
{
    public class GigaVolt : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 30;
            item.magic = true;
            item.width = 54;
            item.height = 54;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 3f;
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = 4;
            item.UseSound = SoundID.Item20;
            item.autoReuse = true;
			item.consumable = false;
			item.noUseGraphic = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Giga Volt");
            Tooltip.SetDefault("<right> to charge the battery\nChanges attacks according to battery charge:\n[c/1F262E:0 - shoots three electric charges]\n[c/CD1417:1 - shoots one piecring big electric charge]\n[c/E89417:2 - shoots one piercing fast moving big electric charge]\n[c/00FF00:3 - shoots three piercing fast moving big electric charges]\n[c/15A2E9:4 - shoots a giant lighting]");
            DisplayName.AddTranslation(GameCulture.Chinese, "游戏硬币");
            Tooltip.AddTranslation(GameCulture.Chinese, "<right> 蓄积电能\n“这只是个开过光的游戏硬币，你甚至可以用它玩游戏”");
            DisplayName.AddTranslation(GameCulture.Russian, "Гигавольт");
            Tooltip.AddTranslation(GameCulture.Russian, "<right>, чтобы зарядить батарейку\nИзменяет атаку в соответствии c зарядом батарейки:\n[c/1F262E:0 - выстреливает тремя электрическими зарядами]\n[c/CD1417:1 - выстреливает одним большим проникающим электрическим зарядом]\n[c/E89417:2 - выстреливает одним проникающим быстрым большим электрическим зарядом]\n[c/00FF00:3 - выстреливает треями проникающими быстрыми большими электрическими зарядами]\n[c/15A2E9:4 - выстреливает большой молнией]");
        }

        public void OverhaulInit()
        {
            this.SetTag("magicWeapon", false);
        }

        public override bool AltFunctionUse(Player player)
		{
			return true;
		}

        public override bool CanUseItem(Player player)
		{
			var aPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
			if (player.altFunctionUse == 2)
			{
				aPlayer.VoltCharge++;
				if(aPlayer.VoltCharge >= 4)
				{
					aPlayer.VoltCharge = 4;
				}
				item.shoot = 0;
				item.shootSpeed = 0f;
				item.UseSound = SoundID.Item93;
				item.autoReuse = true;
				item.useAnimation = 30;
				item.useTime = 30;
			}
			else if (player.altFunctionUse != 2)
			{
				if(aPlayer.VoltCharge == 0)
				{
					item.damage = 30;
					item.shoot = mod.ProjectileType("SmallElectricCharge");
					item.shootSpeed = 8f;
					item.useAnimation = 12;
					item.useTime = 4;
					item.reuseDelay = 14;
					item.autoReuse = true;
					item.UseSound = SoundID.Item92;
				}
				if(aPlayer.VoltCharge == 1)
				{
					item.damage = 60;
					aPlayer.VoltCharge = 0;
					item.shoot = mod.ProjectileType("ElectricCharge");
					item.shootSpeed = 8f;
					item.useAnimation = 15;
					item.autoReuse = true;
					item.useTime = 15;
					item.UseSound = SoundID.Item92;
				}
				if(aPlayer.VoltCharge == 2)
				{
					item.damage = 60;
					aPlayer.VoltCharge = 0;
					item.shoot = mod.ProjectileType("ElectricCharge");
					item.shootSpeed = 10f;
					item.useAnimation = 15;
					item.autoReuse = true;
					item.useTime = 15;
					item.UseSound = SoundID.Item92;
				}
				if(aPlayer.VoltCharge == 3)
				{
					item.damage = 60;
					aPlayer.VoltCharge = 0;
					item.shoot = mod.ProjectileType("ElectricCharge");
					item.shootSpeed = 8f;
					item.useAnimation = 12;
					item.useTime = 4;
					item.autoReuse = true;
					item.reuseDelay = 14;
					item.UseSound = SoundID.Item92;
				}
				if(aPlayer.VoltCharge == 4)
				{
					item.damage = 80;
					item.channel = true;
					aPlayer.VoltCharge = 0;
					item.shoot = mod.ProjectileType("Lightning1");
					item.shootSpeed = 4f;
					item.autoReuse = true;
					item.useAnimation = 15;
					item.useTime = 15;
					item.UseSound = SoundID.Item92;
				}
			}
			return base.CanUseItem(player);
		}

        /*public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			var aPlayer = player.GetModPlayer<AntiarisPlayer>(mod);
			if (aPlayer.VoltCharge != 4)
				 break;
			if(aPlayer.VoltCharge == 4)
			{
				Vector2 vector82 = -Main.player[Main.myPlayer].Center + Main.MouseWorld;
				float ai = Main.rand.Next(100);
				Vector2 vector83 = Vector2.Normalize(vector82) * item.shootSpeed;
				Projectile.NewProjectile(player.Center.X, player.Center.Y, vector83.X, vector83.Y, type, damage, .490f, player.whoAmI, vector82.ToRotation(), ai);
				return false;
			}
			return true;
        }*/
    }
}
