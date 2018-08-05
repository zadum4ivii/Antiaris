using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Equipables.Accessories
{
    [AutoloadEquip(EquipType.Shoes)]
    public class JumperBoots : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 30;
            item.rare = 3;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.accessory = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jumper's Boots");
            Tooltip.SetDefault("Increases jump height and allows auto-jump\nNegates fall damage\nAllows to jump on enemies dealing damage");
            DisplayName.AddTranslation(GameCulture.Chinese, "跃进者之靴");
            Tooltip.AddTranslation(GameCulture.Chinese, "1、自身可以跳得更高\n2、按住空格键允许进行连续跳跃\n3、免疫坠落伤害\n4、跳起来踩踏敌人可造成伤害");
			DisplayName.AddTranslation(GameCulture.Russian, "Ботинки прыгуна");
            Tooltip.AddTranslation(GameCulture.Russian, "Увеличивают высоту прыжка и позволяют автоматически прыгать\nУстраняют урон от падения\nПозволяют прыгать по врагам, нанося урон");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
			player.jumpBoost = true;
			player.autoJump = true;
			player.noFallDmg = true;

            if (!player.mount.Active && player.velocity.Y > 0f)
            {
                var checkDamagePlayer = player.getRect();
                checkDamagePlayer.Offset(0, player.height - 1);
                checkDamagePlayer.Height = 2;
                checkDamagePlayer.Inflate(12, 6);
                for (var i = 0; i < 200; i++)
                {
                    var npc = Main.npc[i];
                    if (npc.active && !npc.dontTakeDamage && !npc.friendly && npc.immune[player.whoAmI] == 0)
                    {
                        var checkDamageNPC = npc.getRect();
                        if (checkDamagePlayer.Intersects(checkDamageNPC) && (npc.noTileCollide || Collision.CanHit(player.position, player.width, player.height, npc.position, npc.width, npc.height)))
                        {
                            var damage = 20f * player.meleeDamage;
                            var knockBack = 5f;
                            var direction = npc.direction;
                            if (npc.velocity.X < 0f)
                            {
                                direction = -1;
                            }
                            if (npc.velocity.X > 0f)
                            {
                                direction = 1;
                            }
                            npc.StrikeNPC((int)damage, knockBack, direction, Main.rand.Next(2) == 0 ? true : false, false, false);
							if (Main.netMode != 0)
								NetMessage.SendData(28, -1, -1, NetworkText.FromLiteral(""), npc.whoAmI, (float)1, knockBack, (float)direction, (int)damage);
							npc.immune[player.whoAmI] = 10;
                            player.velocity.Y = -10f;
                            player.immune = true;
                            break;
                        }
                    }
                }
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "LeatherBoots");
			recipe.AddIngredient(ItemID.FrogLeg);
			recipe.AddIngredient(ItemID.LuckyHorseshoe);
            recipe.SetResult(this);
            recipe.AddTile(114);
            recipe.AddRecipe();
        }
    }
}