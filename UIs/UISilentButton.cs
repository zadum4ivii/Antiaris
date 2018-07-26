using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria.GameContent.UI.Elements;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Antiaris;
using Terraria.Localization;
using Antiaris.NPCs.Town;
using Terraria.GameInput;
namespace Antiaris.UIs
{
    class UISilentButton : UIElement
    {
        public Texture2D _texture;

        public UISilentButton(Texture2D texture)
        {
            _texture = texture;
            base.Width.Set((float)_texture.Width, 0f);
            base.Height.Set((float)_texture.Height, 0f);
        }

        public void SetImage(Texture2D texture)
        {
            _texture = texture;
            base.Width.Set((float)_texture.Width, 0f);
            base.Height.Set((float)_texture.Height, 0f);
        }

        private int currentState = 0;
        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            Player player = Main.LocalPlayer;
            CalculatedStyle dimensions = base.GetDimensions();
            Rectangle rectangle = _texture.Frame(3, 1, 0, 0);
            rectangle.X = rectangle.Width * currentState;
            spriteBatch.Draw(_texture, dimensions.Position(), new Rectangle?(rectangle), Color.White * 1.0f, 0.0f, Vector2.Zero, Vector2.One, SpriteEffects.None, 0.0f);
            if (IsMouseHovering) currentState = 2;
            else currentState = CurrentQuestUI.visible ? 0 : 1;
            if (IsMouseHovering)
            {
                List<string> justPressed = Antiaris.hideTracker.GetAssignedKeys(InputMode.Keyboard);
                string button = justPressed.Count > 0 ? justPressed[0] : "?";
                string TrackerButton = Language.GetTextValue("Mods.Antiaris.TrackerButton", button);
                Main.hoverItemName = TrackerButton;
            }
        }

        public override void MouseOver(UIMouseEvent evt)
        {
            base.MouseOver(evt);
        }
    }
}
