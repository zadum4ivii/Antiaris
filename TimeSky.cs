using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics.Effects;

namespace Antiaris
{
	public class TimeSky : CustomSky
	{
	    public static Color color;
	    private bool _isActive;
	    private Random _random = new Random();

	    public override void OnLoad()
		{
		}

	    public override void Update(GameTime gameTime)
		{
		}

	    private float GetIntensity()
		{
			return 1f - Utils.SmoothStep(1000f, 1000f, 1000f);
		}

	    /*public override Color OnTileColor(Color inColor)
		{
			float intensity = this.GetIntensity();
			return new Color(Vector4.Lerp(new Vector4(0.5f, 1f, 1f, 1f), inColor.ToVector4(), 1f - intensity));
		}*/

	    public override void Draw(SpriteBatch spriteBatch, float minDepth, float maxDepth)
		{
			if (maxDepth >= 0f && minDepth < 20f)
			{
				//float intensity = this.GetIntensity();
				//spriteBatch.Draw(Main.blackTileTexture, new Rectangle(0, 0, Main.screenWidth, Main.screenHeight), Color.Gray * intensity);
				var rect = new Rectangle(0, (int)Math.Ceiling(Main.screenHeight / 50f), Main.screenWidth, (int)Math.Ceiling(Main.screenHeight / 50f));
                    spriteBatch.Draw(Main.blackTileTexture, rect, color);
			}
		}

	    public override float GetCloudAlpha()
		{
			return 1f;
		}

	    public override void Activate(Vector2 position, params object[] args)
		{
			this._isActive = true;
		}

	    public override void Deactivate(params object[] args)
		{
			this._isActive = false;
		}

	    public override void Reset()
		{
			this._isActive = false;
		}

	    public override bool IsActive()
		{
			return this._isActive;
		}
	}
}
