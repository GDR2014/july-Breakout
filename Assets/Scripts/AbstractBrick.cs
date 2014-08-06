using UnityEngine;

namespace Breakout.Bricks
{
	/// <summary>
	/// The simplest of bricks. Destroy these to get points and complete the level.
	/// </summary>
	public abstract class AbstractBrick : LevelGenerator.AbstractLevelGeneratorAsset
	{
		public delegate void OnBrickDestroyed(AbstractBrick aDestroyedBrick);

		public static event OnBrickDestroyed DestroyedEvent;

		/// <summary>
		/// Called when the brick enters collision with another object.
		/// </summary>
		/// <param name="aCollison">Details about the collision.</param>
		private void OnCollisionEnter2D(Collision2D aCollison)
		{
			GameObject other = aCollison.gameObject;
			if (other.layer == 8) // Layer 8 = Balls
			{
				destroyBrick();
			}
		}

		private void destroyBrick()
		{
			OnThisBrickDestroyed();
			if(DestroyedEvent != null ) DestroyedEvent(this);
			Destroy(this.gameObject);
		}

		public abstract void OnThisBrickDestroyed();
	}
}