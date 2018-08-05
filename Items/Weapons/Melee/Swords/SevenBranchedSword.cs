using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.Items.Weapons.Melee.Swords
{
    public class SevenBranchedSword : ModItem
    {
        public override void HoldItem(Player player) { AntiarisGlowMask2.AddGlowMask(mod.ItemType(GetType().Name), "Antiaris/Glow/" + GetType().Name + "_GlowMask"); }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI) { AntiarisUtils.DrawItemGlowMaskWorld(spriteBatch, item, mod.GetTexture("Glow/" + GetType().Name + "_GlowMask"), rotation, scale); }

        public override void SetDefaults()
        {
            item.damage = 41;
            item.melee = true;
            item.width = 58;
            item.height = 58;
            item.useTime = 22;
            item.useAnimation = 22;
            item.useStyle = 1;
            item.knockBack = 8f;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = 4;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
			item.useTurn = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Seven Branched Sword");
            DisplayName.AddTranslation(GameCulture.Russian, "Меч семи ответвлений");
            DisplayName.AddTranslation(GameCulture.Chinese, "七枝剑");
            Tooltip.AddTranslation(GameCulture.Chinese, "击中敌人时有概率使所有敌人受到该武器伤害数值25%的伤害");
            Tooltip.SetDefault("Has a chance to strike all enemies on hit dealing 25% of weapon damage");
            Tooltip.AddTranslation(GameCulture.Russian, "Имеет шанс ударить всех врагов при ударе, нанося 25% урона оружия");
        }

        public void OverhaulInit()
        {
            this.SetTag("broadsword");
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(4) == 0 && Main.netMode != 2)
            {
                for (var k = 0; k < 200; k++)
                {
                    if (Main.npc[k].lifeMax > 0 && Main.npc[k].active && !Main.npc[k].friendly && Main.npc[k].damage > 0 && !Main.npc[k].dontTakeDamage)
                    {
                        int DealDamage = item.damage / 4;
                        var direction = Main.npc[k].direction;
                        if (Main.npc[k].velocity.X < 0f)
                        {
                            direction = -1;
                        }
                        if (Main.npc[k].velocity.X > 0f)
                        {
                            direction = 1;
                        }
                        Main.npc[k].StrikeNPC(DealDamage, knockback / 2.0f, direction, crit, false, false);
						if (Main.netMode != 0)
							NetMessage.SendData(28, -1, -1, NetworkText.FromLiteral(""), Main.npc[k].whoAmI, (float)1, knockback / 2, (float)direction, DealDamage);
					}
                }
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CrimtaneBar, 12);
            recipe.AddIngredient(null, "BloodyChargedCrystal", 14);
			recipe.AddIngredient(ItemID.SoulofNight, 8);
			recipe.AddIngredient(null, "WrathElement", 6);
            recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.AddRecipe();
        }
    }
}
