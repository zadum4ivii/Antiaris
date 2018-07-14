using Terraria.Graphics.Shaders;

namespace Antiaris
{
	public class Data : ScreenShaderData
	{
	    private int k;

	    public Data(string passName) : base(passName)
		{ }

	    private void UpdatePuritySpiritIndex()
        {
            return;
            k = -1;
        }

	    public override void Apply()
        {
            UpdatePuritySpiritIndex();
            base.Apply();
        }
	}
}