using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Antiaris
{
    public class ItemStop : GlobalItem
    {
        private bool gravity;

        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }

        public override bool CloneNewInstances 
		{ 
			get 
			{ 
				return true; 
			}
		}

        public override void SetDefaults(Item item)
		{
			gravity = ItemID.Sets.ItemNoGravity[item.type];
		}

        public override void PostUpdate(Item item)
        {            
            if (AntiarisWorld.frozenTime)
            {
                if (!gravity)
                    ItemID.Sets.ItemNoGravity[item.type] = true;
            }
            else
            {
                ItemID.Sets.ItemNoGravity[item.type] = gravity;
            }
        }
    }
}