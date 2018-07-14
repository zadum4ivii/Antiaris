using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.Items.Weapons.Melee.Swords
{
	public class TheClaymoreOfRedCrystal : ModItem
	{
	    public override void HoldItem(Player player) { AntiarisGlowMask2.AddGlowMask(mod.ItemType(GetType().Name), "Antiaris/Glow/" + GetType().Name + "_GlowMask"); }
	    public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI) { AntiarisUtils.DrawItemGlowMaskWorld(spriteBatch, item, mod.GetTexture("Glow/" + GetType().Name + "_GlowMask"), rotation, scale); }

	    public override void SetDefaults()
		{
            item.damage = 36;
            item.melee = true;
            item.width = 56;
            item.height = 56;
            item.useTime = 26;
            item.useAnimation = 26;
            item.useStyle = 1;
            item.knockBack = 6.2f;
            item.value = Item.sellPrice(0, 9, 25, 0);
            item.rare = 5;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("TheRedShard");
			item.shootSpeed = 4.4f;
		}

	    public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Claymore of Red Crystal");
            DisplayName.AddTranslation(GameCulture.Chinese, "红水晶之刃");
            DisplayName.AddTranslation(GameCulture.Russian, "Клеймор красного кристалла");
            Tooltip.SetDefault("Shoots crystal blades\n<right> to control direction of the blades");
            Tooltip.AddTranslation(GameCulture.Russian, "Стреляет кристальными клинками\n<right>, чтобы управлять их направлением");
            Tooltip.AddTranslation(GameCulture.Chinese, "发射水晶之刃\n<right> 控制水晶之刃移动方向");
        }

	    public void OverhaulInit()
        {
            this.SetTag("broadsword");
        }

	    public override bool AltFunctionUse(Player player)
        {
            return true;
        }

	    public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (player.altFunctionUse == 2)
                foreach (Projectile projectile in Main.projectile)
                    if (Main.myPlayer == projectile.owner && projectile.active && projectile.type == item.shoot)
                    {
                        Vector2 mouse = Main.MouseWorld;
                        Vector2 vector2_1 = mouse;
                        float speed = 10f;
                        Vector2 vector2_2 = vector2_1 - projectile.Center;
                        float distance = (float)Math.Sqrt((double)vector2_2.X * (double)vector2_2.X + (double)vector2_2.Y * (double)vector2_2.Y);
                        vector2_2 *= speed / distance;
                        projectile.velocity = vector2_2;
                    }
            return player.altFunctionUse != 2;
        }

	    public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.EnchantedSword, 1);
            recipe.AddIngredient(null, "RedBigCrystal", 15);
            recipe.AddIngredient(null, "RedCrystalPixieDust", 15);
            recipe.SetResult(this);
            recipe.AddTile(134);
            recipe.AddRecipe();
        }
	}
}
