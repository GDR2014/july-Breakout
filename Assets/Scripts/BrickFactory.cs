using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Breakout.Bricks
{
	public class BrickFactory
	{
		public static int RemainingBricksCount { get; private set; }
	
		public enum BrickType
		{
			SIMPLE
		}

		public delegate void RemainingBricksCountChangedHandler(int previousValue);
		public event RemainingBricksCountChangedHandler RemainingBricksCountChangedEvent;

		private Dictionary<BrickType, AbstractBrick> myBricks; 

		public BrickFactory()
		{
			myBricks = new Dictionary<BrickType, AbstractBrick>();
			myBricks.Add(BrickType.SIMPLE, Resources.Load<SimpleBrick>("Prefabs/Bricks/Brick_Simple_Horizontal"));
		}

		public AbstractBrick GetBrick(BrickType aType)
		{
			AbstractBrick brickPrefab;
			bool exists = myBricks.TryGetValue(aType, out brickPrefab);
			if(!exists) throw new NotImplementedException(string.Format("{0} does not have a prefab assigned!", aType));
			return Object.Instantiate(brickPrefab) as SimpleBrick;
		}

		private void OnBrickDestroyed(AbstractBrick aBrick)
		{
			int previousValue = RemainingBricksCount;
			RemainingBricksCount--;
			RemainingBricksCountChangedEvent(previousValue);
		}
	}
}