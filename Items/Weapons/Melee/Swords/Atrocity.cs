using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using TerrariaOverhaul;

namespace Antiaris.Items.Weapons.Melee.Swords
{
    public class Atrocity : ModItem
    {
        byte Uses = 0;

        public override void SetDefaults()
        {
            item.damage = 94;
            item.melee = true;
            item.width = 48;
            item.height = 56;
            item.useTime = 26;
            item.useAnimation = 26;
            item.useStyle = 1;
            item.knockBack = 8f;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = 8;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("TerriCentral");
            item.shootSpeed = 22f;
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Atrocity");
            DisplayName.AddTranslation(GameCulture.Russian, "Зверство");
            DisplayName.AddTranslation(GameCulture.Chinese, "狂世界");
            Tooltip.AddTranslation(GameCulture.Chinese, "挥动时在光标周围召唤一圈骷髅\n骷髅可以变成可控剑气\n“Terri Blade....TERRI BLadE....”");
            Tooltip.SetDefault("Summons a circle of skulls around the cursor on swing\nSkulls transform into controllable blades");
            Tooltip.AddTranslation(GameCulture.Russian, "При взмахе призывает кольцо черепов вокруг курсора\nЧерепа превращаются в управляемые лезвия");
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
            else if (Uses == 3)
                return true;
            else if (Uses > 3)
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
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 59);
            if (Main.rand.Next(4) == 0)
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 62);
            if (Main.rand.Next(4) == 0)
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 65);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("DarkMoon"));
            recipe.AddIngredient(mod.ItemType("VoidFlare"));
            recipe.AddIngredient(ItemID.BrokenHeroSword, 1);
            recipe.SetResult(this);
            recipe.AddTile(134);
            recipe.AddRecipe();
        }
    }
}
