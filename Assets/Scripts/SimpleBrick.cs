namespace Breakout.Bricks
{
	/// <summary>
	/// The simplest of bricks.
	/// </summary>
	public class SimpleBrick : AbstractBrick
	{
		public override int AssetHeightInCells
		{
			get { return 1; }
		}

		public override int AssetWidthInCells
		{
			get { return 2; }
		}

	    public override int ScoreValue
	    {
	        get { return 1; }
	    }

	    public override void OnThisBrickDestroyed()
		{
			// TODO: Play sound, spawn particles, etc.
		}
	}
}