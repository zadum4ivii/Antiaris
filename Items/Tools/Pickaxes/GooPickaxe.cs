using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.Items.Tools.Pickaxes
{
    public class GooPickaxe : ModItem
    {
        public override void HoldItem(Player player) { AntiarisGlowMask2.AddGlowMask(mod.ItemType(GetType().Name), "Antiaris/Glow/" + GetType().Name + "_GlowMask"); }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI) { AntiarisUtils.DrawItemGlowMaskWorld(spriteBatch, item, mod.GetTexture("Glow/" + GetType().Name + "_GlowMask"), rotation, scale); }

        public override void SetDefaults()
        {
            item.damage = 7;
            item.melee = true;
            item.width = 32;
            item.height = 32;
            item.useTime = 16;
            item.useAnimation = 25;
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = Item.sellPrice(0, 0, 20, 0);
            item.rare = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useTurn = true;
			item.pick = 60;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Goo Pickaxe");
            DisplayName.AddTranslation(GameCulture.Chinese, "凝胶镐");
            DisplayName.AddTranslation(GameCulture.Russian, "Кирка из слизи");
        }

        public void OverhaulInit()
        {
            this.SetTag("tool");
            this.SetTag("bluntHit");
            this.SetTag("flammable");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "LiquifiedGoo", 1);
            recipe.AddRecipeGroup("Antiaris:WoodenPickaxe");
            recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.AddRecipe();
        }
    }
}