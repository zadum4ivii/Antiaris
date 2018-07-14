using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.Items.Tools.Mixed
{
    public class GolemPickaxe : ModItem
    {
        public override void HoldItem(Player player) { AntiarisGlowMask2.AddGlowMask(mod.ItemType(GetType().Name), "Antiaris/Glow/" + GetType().Name + "_GlowMask"); }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI) { AntiarisUtils.DrawItemGlowMaskWorld(spriteBatch, item, mod.GetTexture("Glow/" + GetType().Name + "_GlowMask"), rotation, scale); }

        public override void SetDefaults()
        {
            item.damage = 21;
            item.melee = true;
            item.width = 54;
            item.height = 64;
            item.useTime = 18;
            item.useAnimation = 22;
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = 4;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useTurn = true;
			item.pick = 105;
			item.axe = 30;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Golem Pickaxe");
            DisplayName.AddTranslation(GameCulture.Chinese, "魔像镐斧");
            DisplayName.AddTranslation(GameCulture.Russian, "Кирка голема");
        }

        public void OverhaulInit()
        {
            this.SetTag("tool");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CrimtaneBar, 8);
            recipe.AddIngredient(null, "BloodyChargedCrystal", 10);
			recipe.AddIngredient(ItemID.SoulofNight, 6);
			recipe.AddIngredient(null, "WrathElement", 5);
            recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.AddRecipe();
        }
    }
}