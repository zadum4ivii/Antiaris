using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Antiaris.Items.Weapons.Ranged.Guns
{
    public class CrystalGun : ModItem
    {
        public override void HoldItem(Player player) { AntiarisGlowMask2.AddGlowMask(mod.ItemType(GetType().Name), "Antiaris/Glow/" + GetType().Name + "_GlowMask"); }
		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI) { AntiarisUtils.DrawItemGlowMaskWorld(spriteBatch, item, mod.GetTexture("Glow/" + GetType().Name + "_GlowMask"), rotation, scale); }
        public override void SetDefaults()
        {
            item.useStyle = 5;
            item.useAnimation = 13;
            item.useTime = 13;
            item.width = 54;
            item.height = 32;
            item.shoot = 10;
            item.useAmmo = AmmoID.Bullet;
            item.UseSound = SoundID.Item11;
            item.damage = 32;
            item.ranged = true;
            item.autoReuse = true;
            item.knockBack = 2.5f;
            item.shootSpeed = 7.0f;
            item.noMelee = true;
            item.value = Item.sellPrice(0, 7, 35, 0);
            item.rare = 5;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystal Gun");
            Tooltip.SetDefault("Every second shot creates an additional bullet\n10% chance not to consume ammo");
			DisplayName.AddTranslation(GameCulture.Chinese, "水晶枪");
            Tooltip.AddTranslation(GameCulture.Chinese, "1、开火时每秒都会额外发射一枚子弹\n2、10% 的概率不消耗弹药");
            DisplayName.AddTranslation(GameCulture.Russian, "Кристальная пушка");
            Tooltip.AddTranslation(GameCulture.Russian, "Каждый второй выстрел создает дополнительную пулю\n10% шанс не потратить пулю");
        }

        public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.NextFloat() >= .10f;
        }

        private byte uses = 0;
        public override bool CanUseItem(Player player)
        {
            this.uses++;
            if (this.uses > 2) this.uses = 1;
            return true;
        }

        public override void NetSend(BinaryWriter writer) { writer.Write(this.uses); }
        public override void NetRecieve(BinaryReader reader) { this.uses = reader.ReadByte(); }
        public override TagCompound Save() { return new TagCompound { { "u", this.uses } }; }
        public override void Load(TagCompound tag) { this.uses = tag.GetByte("u"); }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (this.uses == 1) Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("CrystalBullet"), damage - 5, knockBack, player.whoAmI, (float)type, 0.0f);
            else Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage + 5, knockBack, player.whoAmI);
            return false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PhoenixBlaster);
            recipe.AddIngredient(null, "BlueBigCrystal", 5);
            recipe.AddIngredient(null, "GreenCrystalPixieDust", 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
