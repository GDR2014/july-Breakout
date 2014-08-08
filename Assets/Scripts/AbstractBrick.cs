﻿using UnityEngine;

namespace Breakout.Bricks
{
	/// <summary>
	/// The simplest of bricks. Destroy these to get points and complete the level.
	/// </summary>
	[RequireComponent(typeof(Collider2D))]
	public abstract class AbstractBrick : LevelGenerator.AbstractLevelGeneratorAsset
	{
		public delegate void DestroyedEvent(AbstractBrick aDestroyedBrick);
		public static event DestroyedEvent OnBrickDestroyed;


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
			if(OnBrickDestroyed != null ) OnBrickDestroyed(this);
			Destroy(this.gameObject);
		}

        #region Abstract members
        public abstract int ScoreValue { get; }
		public abstract void OnThisBrickDestroyed();
        #endregion
    }
}