using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace Antiaris.VEffects
{
	//it's hard code, i've worked on this a long
	public class LightningBolt
	{
	    public static Texture2D SegmentTexture;
	    public static Texture2D EndTexture;
	    List<Line> Segments = new List<Line>();
	    Vector2 Source;
	    public float Thickness = 1f;
	    public int Ticks = 0;

	    public LightningBolt(Vector2 source, Vector2 dest, int ticks, float thickness = 1f)
		{
			this.Source = source;
			this.Ticks = ticks;
			this.Thickness = thickness;
			this.Segments = this.CreateBolt(source, dest);
		}

	    public LightningBolt(Vector2 source, int ticks, float thickness = 1f)
		{
			this.Source = source;
			this.Ticks = ticks;
			this.Thickness = thickness;
		}

	    List<Line> CreateBolt(Vector2 source, Vector2 dest)
		{
			var results = new List<Line>();
			Vector2 tangent = dest - source;
			Vector2 normal = Vector2.Normalize(new Vector2(tangent.Y, -tangent.X));
			float length = tangent.Length();
			int positionCount = Math.Min(100, (int)(length / 4));		
			var positions = new List<float>(positionCount + 50);
			positions.Add(0);		
			for (int i = 0; i < positionCount; i++) positions.Add(Main.rand.NextFloat(0, 1));	
			positions.Sort();		
			const float sway = 80;
			const float jaggedness = 1 / sway;		
			Vector2 prevPoint = source;
			float prevDisplacement = 0;
			for (int i = 1; i < positions.Count; i++)
			{
				float pos = positions[i];
				float scale = (length * jaggedness) * (pos - positions[i - 1]);
				float envelope = pos > 0.95f ? 20 * (1 - pos) : 1;		
				float displacement = Main.rand.NextFloat(-sway, sway);
				displacement -= (displacement - prevDisplacement) * (1 - scale);
				displacement *= envelope;			
				var point = source + pos * tangent + displacement * normal;
				results.Add(new Line(SegmentTexture, EndTexture, prevPoint, point, this.Thickness));
				prevPoint = point;
				prevDisplacement = displacement;
			}		
			results.Add(new Line(SegmentTexture, EndTexture, prevPoint, dest, this.Thickness));		
			return results;
		}

	    public void Extend(Vector2 dest)
		{
			if (this.Segments.Count == 0) this.Segments = this.CreateBolt(this.Source, dest);
			else this.Segments.AddRange(this.CreateBolt(this.Segments[this.Segments.Count - 1].B, dest));
		}

	    public void Draw(SpriteBatch spriteBatch, Color color = default(Color))
		{
			foreach (var segment in this.Segments) segment.Draw(spriteBatch, color);
		}

	    public void moveTo(Vector2 source)
		{
			var move = source - this.Source;
			foreach(var segment in this.Segments)
			{
				segment.A += move;
				segment.B += move;
			}
			this.Source = source;
		}

	    public void moveTo(Vector2 source, Vector2 destination)
		{
			this.moveTo(source);
			if (this.Segments.Count > 0) this.Segments[this.Segments.Count - 1].B = destination;
		}
	}
}
