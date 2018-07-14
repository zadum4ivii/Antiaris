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
    public class DesertRage : ModItem
    {
        byte Uses = 0;

        public override bool CloneNewInstances
        {
            get
            {
                return true;
            }
        }

        public override void SetDefaults()
        {
            item.damage = 21;
            item.melee = true;
            item.width = 62;
            item.height = 58;
            item.useTime = 25;
            item.useAnimation = 25;
            item.useStyle = 1;
            item.knockBack = 7;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = 3;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shootSpeed = 25f;
            item.shoot = 10;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Desert Rage");
            DisplayName.AddTranslation(GameCulture.Russian, "Ярость пустыни");
            DisplayName.AddTranslation(GameCulture.Chinese, "风沙之怒");
            Tooltip.SetDefault("Shoots out splinters that stick to enemies dealing damage\nAlso shoots out piercing splinters");
            Tooltip.AddTranslation(GameCulture.Chinese, "发射锋利且可以刺入敌人体内的尖刺");
            Tooltip.AddTranslation(GameCulture.Russian, "Выстреливает занозами, которые застряют во врагах, нанося урон\nТакже выстреливает проникающей занозой");
        }

        public void OverhaulInit()
        {
            this.SetTag("broadsword");
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Confused, 120);
        }

        public override bool CanUseItem(Player player)
        {
            Uses++;
            return true;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (Uses == 1)
            {
                int numberProjectiles = 2;
                type = mod.ProjectileType("Splinter2");
                for (int i = 0; i < numberProjectiles; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(20));
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
                }
            }
            else if (Uses == 2)
            {
                int numberProjectiles = 3;
                type = mod.ProjectileType("Splinter2");
                for (int i = 0; i < numberProjectiles; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(20));
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
                }
            }
            else if (Uses == 3)
            {
                int numberProjectiles = 2;
                type = mod.ProjectileType("BigSplinter2");
                for (int i = 0; i < numberProjectiles; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(20));
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
                }
            }
            else
            {
                Uses = 0;
            }
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
    }
}
