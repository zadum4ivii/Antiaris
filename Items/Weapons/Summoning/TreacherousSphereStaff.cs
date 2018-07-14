using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Antiaris.Items.Weapons.Summoning
{
    public class TreacherousSphereStaff : ModItem
    {
        public override void HoldItem(Player player) { AntiarisGlowMask2.AddGlowMask(mod.ItemType(GetType().Name), "Antiaris/Glow/" + GetType().Name + "_GlowMask"); }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI) { AntiarisUtils.DrawItemGlowMaskWorld(spriteBatch, item, mod.GetTexture("Glow/" + GetType().Name + "_GlowMask"), rotation, scale); }

        public override void SetDefaults()
        {
            item.damage = 16;
            item.summon = true;
            item.mana = 14;
            item.width = 58;
            item.height = 62;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = 1;
            item.noMelee = true;
            item.knockBack = 3.4f;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = 3;
            item.UseSound = SoundID.Item44;
            item.autoReuse = false;
            item.shoot = mod.ProjectileType("TrueTreacherousSphere");
            item.shootSpeed = 2.0f;
            item.sentry = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Treacherous Sphere Staff");
            Tooltip.SetDefault("Summons a treacherous sphere\nSphere shoots energy bolts at your enemies");
            DisplayName.AddTranslation(GameCulture.Russian, "Посох коварной сферы");
			DisplayName.AddTranslation(GameCulture.Chinese, "千瞬光球法杖");
			Tooltip.AddTranslation(GameCulture.Chinese, "1、召唤一个千瞬光球\n2、光球会对你的敌人发射闪电");
            Tooltip.AddTranslation(GameCulture.Russian, "Призывает коварную сферу\nСфера стреляет энергетическими снарядами в ваших противников");
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse != 2)
            {
                List<Projectile> projectileList = new List<Projectile>();
                for (int k = 0; k < 1000; k++)
                {
                    if (Main.projectile[k].WipableTurret)
                        projectileList.Add(Main.projectile[k]);
                }
                int projectiles = 0;
                while (projectileList.Count >= player.maxTurrets && ++projectiles < 1000)
                {
                    Projectile projectile = projectileList[0];
                    for (int k = 1; k < projectileList.Count; k++)
                    {
                        if (projectileList[k].timeLeft < projectile.timeLeft)
                            projectile = projectileList[k];
                    }
                    projectile.Kill();
                    projectileList.Remove(projectile);
                }
            }
            return true;
        }

        public override bool AltFunctionUse(Player player) { return true; }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) { return player.altFunctionUse != 2; }

        public override bool UseItem(Player player)
        {
            if (player.altFunctionUse == 2) player.MinionNPCTargetAim();
            return base.UseItem(player);
        }
    }
}
