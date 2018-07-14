using Terraria;
using Terraria.ID;
using Terraria.Localization;

namespace Antiaris.Items.Quests
{
    public class Charcoal : QuestItem
    {
        private bool onFire = false;
        private int timer = 0;

        public Charcoal()
        {
            questItem = true;
            //uniqueStack = true;
            maxStack = 999;
            rare = -11;
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            base.SetDefaults();
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Charcoal");
            DisplayName.AddTranslation(GameCulture.Chinese, "木炭");
            DisplayName.AddTranslation(GameCulture.Russian, "Древесный уголь");
        }

        public override void PostUpdate()
        {
            Player owner = null;
            if (item.owner != -1)
            {
                owner = Main.player[item.owner];
            }
            else if (item.owner == 255)
            {
                owner = Main.LocalPlayer;
            }
            var player = owner;
            if (item.lavaWet)
            {
                if (item.velocity.Y > 0.86f)
                {
                    item.velocity.Y = item.velocity.Y * 0.9f;
                }
                item.velocity.Y = item.velocity.Y - 1.3f;
                if (item.velocity.Y < -2f)
                {
                    item.velocity.Y = -2f;
                }
                onFire = true;
            }
            ++timer;
            if (timer % 180 == 0)
            {
                onFire = false;
            }
            if (item.Hitbox.Intersects(player.Hitbox) && onFire)
            {
                player.AddBuff(BuffID.OnFire, 180);
            }
        }
    }
}
