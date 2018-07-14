using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Summoning
{
    public class TreeBranchStaff : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 12;
            item.summon = true;
            item.mana = 10;
            item.width = 54;
            item.height = 72;
            item.useTime = 36;
            item.channel = true;
            item.useAnimation = 36;
            item.useStyle = 1;
            item.noMelee = true;
            item.knockBack = 3;
            item.value = Item.buyPrice(0, 0, 24, 0);
            item.rare = 1;
            item.UseSound = SoundID.Item44;
            item.shoot = mod.ProjectileType("ForestGuardianJunior");
            item.shootSpeed = 2f;
            item.buffType = mod.BuffType("ForestGuardianJunior");
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tree Branch Staff");
            Tooltip.SetDefault("Summons a forest guardian junior to fight for you.");
            DisplayName.AddTranslation(GameCulture.Chinese, "树枝法杖");
            Tooltip.AddTranslation(GameCulture.Chinese, "召唤一个森林守护者幼体为你而战");
            DisplayName.AddTranslation(GameCulture.Russian, "Посох из ветви дерева");
            Tooltip.AddTranslation(GameCulture.Russian, "Призывает младшего стража леса, который сражается за вас");
        }

        public override void UseStyle(Player player)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(item.buffType, 3600, true);
			}
		}

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            return player.altFunctionUse != 2;
        }

        public override bool UseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                player.MinionNPCTargetAim();
            }
            return base.UseItem(player);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 15);
            recipe.AddIngredient(null, "Leaf", 20);
            recipe.AddIngredient(null, "NatureEssence", 6);
            recipe.AddTile(16);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
