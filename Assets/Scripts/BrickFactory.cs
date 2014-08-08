using UnityEngine;

namespace Breakout.Bricks
{
	public class BrickFactory
	{
		private SimpleBrick mySimpleBrick;

		public BrickFactory()
		{
			mySimpleBrick = Resources.Load<SimpleBrick>("Prefabs/Bricks/Brick_Simple_Horizontal");
		}

		public SimpleBrick GetNewSimpleBrick()
		{
			return Object.Instantiate(mySimpleBrick) as SimpleBrick;
		}
	}
}