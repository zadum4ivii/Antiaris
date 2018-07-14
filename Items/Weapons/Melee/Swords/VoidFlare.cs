using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using TerrariaOverhaul;

namespace Antiaris.Items.Weapons.Melee.Swords
{
    public class VoidFlare : ModItem
    {
        byte Uses = 0;
        public override void HoldItem(Player player) { AntiarisGlowMask2.AddGlowMask(mod.ItemType(GetType().Name), "Antiaris/Glow/" + GetType().Name + "_GlowMask"); }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI) { AntiarisUtils.DrawItemGlowMaskWorld(spriteBatch, item, mod.GetTexture("Glow/" + GetType().Name + "_GlowMask"), rotation, scale); }

        public override void SetDefaults()
        {
            item.damage = 73;
            item.melee = true;
            item.width = 58;
            item.height = 58;
            item.useTime = 24;
            item.useAnimation = 24;
            item.useStyle = 1;
            item.knockBack = 7.5f;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = 8;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("TrueCelestialMagicCentral");
            item.shootSpeed = 22f;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Void Flare");
            DisplayName.AddTranslation(GameCulture.Russian, "Огонь бездны");
            DisplayName.AddTranslation(GameCulture.Chinese, "至黑之日");
            Tooltip.AddTranslation(GameCulture.Chinese, "在光标周围召唤一圈神圣火焰\n“晃眼的光，表象，毫无意识的强合力”");
            Tooltip.SetDefault("Summons a circle of celestial flames around the cursor");
            Tooltip.AddTranslation(GameCulture.Russian, "Призывает кольцо из небесного пламени вокруг курсора");
        }

        public void OverhaulInit()
        {
            this.SetTag("broadsword");
        }

        public override bool CanUseItem(Player player)
        {
            Uses++;
            return true;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (Uses == 1)
                return true;
            else if (Uses == 2)
                return true;
            else if (Uses > 2)
                Uses = 0;
            else
                return false;
            return false;
        }

        public override void NetSend(BinaryWriter writer)
        {
            writer.Write(Uses);
        }

        public override void NetRecieve(BinaryReader reader)
        {
            Uses = reader.ReadByte();
        }

        public override TagCompound Save()
        {
            return new TagCompound
            {
                {
                    "U", Uses
                }
            };
        }

        public override void Load(TagCompound tag)
        {
            Uses = tag.GetByte("U");
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(4) == 0)
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 57);
            if (Main.rand.Next(5) == 0)
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 73);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Radiance", 1);
            recipe.AddIngredient(ItemID.BrokenHeroSword, 1);
            recipe.SetResult(this);
            recipe.AddTile(134);
            recipe.AddRecipe();
        }
    }
}
