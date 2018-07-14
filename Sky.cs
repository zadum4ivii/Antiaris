using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics.Effects;

namespace Antiaris
{
	public class Sky : CustomSky
	{
	    public static Color color;
	    bool Active = false;
	    float Intensity = 0f;

	    public override void Update(GameTime gameTime)
        {
            if (Active && Intensity < 1f)
            {
                Intensity += 0.01f;
            }
            else if (!Active && Intensity > 0f)
            {
                Intensity -= 0.01f;
            }
        }

	    public override void Draw(SpriteBatch spriteBatch, float minDepth, float maxDepth)
        {
            if (maxDepth >= 3.40282347E+38f && minDepth < 3.40282347E+38f)
            {
                for (int i = 0; i < 200; i++)
                {
                    var rect = new Rectangle(0, (int)Math.Ceiling(Main.screenHeight / 200f) * i, Main.screenWidth, (int)Math.Ceiling(Main.screenHeight / 200f));
                    spriteBatch.Draw(Main.blackTileTexture, rect, color);
                }
            }

        }

	    public override float GetCloudAlpha()
        {
            return 1f - Intensity;
        }

	    public override void Activate(Vector2 position, params object[] args)
        {
            Active = true;
        }

	    public override void Deactivate(params object[] args)
        {
            Active = false;
        }

	    public override void Reset()
        {
            Active = false;
        }

	    public override bool IsActive()
        {
            return Active || Intensity > 0f;
        }
	}
}