using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace Antiaris.VEffects
{
	//it's hard code, i've worked on this a long
	public class Line
	{
	    public Vector2 A;
	    public Vector2 B;
	    public Texture2D EndTexture;
	    public Texture2D SegmentTexture;
	    public float Thickness;

	    public Line(Texture2D segmentTexture, Texture2D endTexture, Vector2 a, Vector2 b, float thickness = 1)
		{
			this.SegmentTexture = segmentTexture;
			this.EndTexture = endTexture;
			this.A = a;
			this.B = b;
			this.Thickness = thickness;
		}

	    public void Draw(SpriteBatch spriteBatch, Color color = default(Color))
		{
			float rotation = (this.B - this.A).ToRotation();
			float thicknessScale = this.Thickness / this.SegmentTexture.Height;
			Vector2 capOrigin = new Vector2(this.EndTexture.Width, this.EndTexture.Height / 2f);
			Vector2 middleOrigin = new Vector2(0, this.SegmentTexture.Height / 2f);
			Vector2 middleScale = new Vector2((this.B - this.A).Length(), thicknessScale);	
			spriteBatch.Draw(this.SegmentTexture, this.A - Main.screenPosition, null, color, rotation, middleOrigin, middleScale, SpriteEffects.None, 0f);
			spriteBatch.Draw(this.EndTexture, this.A - Main.screenPosition, null, color, rotation, capOrigin, thicknessScale, SpriteEffects.None, 0f);
			spriteBatch.Draw(this.EndTexture, this.B - Main.screenPosition, null, color, rotation + MathHelper.Pi, capOrigin, thicknessScale, SpriteEffects.None, 0f);
		}
	}
}
