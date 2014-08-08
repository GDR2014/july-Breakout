using UnityEngine;

namespace Breakout.Bricks
{
	/// <summary>
	/// The simplest of bricks.
	/// </summary>
	[RequireComponent(typeof(BoxCollider2D))]
	public class SimpleBrick : AbstractBrick
	{
		public override int AssetHeightInCells
		{
            get { return Mathf.RoundToInt(myBoxCollider.size.y ); }
		}

		public override int AssetWidthInCells
		{
			get { return Mathf.RoundToInt( myBoxCollider.size.x ); }
		}

	    public override int ScoreValue
	    {
	        get { return 1; }
	    }

	    private BoxCollider2D myBoxCollider;

	    void Awake()
	    {
	        myBoxCollider = GetComponent<BoxCollider2D>();
	    }

	    public override void OnThisBrickDestroyed()
		{
			// TODO: Play sound, spawn particles, etc.
		}
	}
}