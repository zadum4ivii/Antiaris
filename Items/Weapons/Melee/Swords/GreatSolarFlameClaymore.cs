using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TerrariaOverhaul;

namespace Antiaris.Items.Weapons.Melee.Swords
{
    public class GreatSolarFlameClaymore : ModItem
    {
        public override void HoldItem(Player player) { AntiarisGlowMask2.AddGlowMask(mod.ItemType(GetType().Name), "Antiaris/Glow/" + GetType().Name + "_GlowMask"); }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI) { AntiarisUtils.DrawItemGlowMaskWorld(spriteBatch, item, mod.GetTexture("Glow/" + GetType().Name + "_GlowMask"), rotation, scale); }

        public override void SetDefaults()
        {
            item.damage = 207;
            item.melee = true;
            item.width = 122;
            item.height = 116;
            item.useTime = 17;
            item.useAnimation = 17;
            item.useStyle = 1;
            item.knockBack = 7;
            item.value = Item.sellPrice(0, 22, 0, 0);
            item.rare = 10;
            item.UseSound = SoundID.Item71;
            item.autoReuse = true;
            item.useTurn = true;
			item.shoot = mod.ProjectileType("SolarFlameSkull");
            item.shootSpeed = 15f;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Great Solar Flame Claymore");
            DisplayName.AddTranslation(GameCulture.Russian, "Великий клеймор солнечной вспышки");
            DisplayName.AddTranslation(GameCulture.Chinese, "蛮荒大剑");
            Tooltip.AddTranslation(GameCulture.Chinese, "1、挥动时抛射出会反弹的日曜魔首\n2、日曜魔首因为伤害敌人或接触物块而消失时会爆炸\n3、被爆炸波及到的敌人会被灼烧");
            Tooltip.SetDefault("Shoots out solar flame skulls that bounce off blocks\nSkulls leave damaging explosions when they hit an enemy or block\nExplosions set enemies on fire");
            Tooltip.AddTranslation(GameCulture.Russian, "Выстреливает черепами солнечной вспышки, которые отпрыгивают от блоков\nКогда черепа попадают по блоку или врагу, то они оставляют наносящие урон взрывы\nВзрывы поджигают врагов");
        }

        public void OverhaulInit()
        {
            this.SetTag("broadsword");
            this.SetTag("fireDamage");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Meowmere);
            recipe.AddIngredient(ItemID.SolarEruption);
			recipe.AddIngredient(3458, 14);
			recipe.AddIngredient(3467, 12);
			recipe.AddIngredient(null, "WrathElement", 12);
            recipe.SetResult(this);
            recipe.AddTile(412);
            recipe.AddRecipe();
        }
    }
}
