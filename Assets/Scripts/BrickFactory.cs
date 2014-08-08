using UnityEngine;

namespace Breakout.Bricks
{
	public class BrickFactory
	{
		private SimpleBrick mySimpleBrick;

		public BrickFactory()
		{
			mySimpleBrick = Resources.Load<SimpleBrick>("Prefabs/Bricks/SimpleBrick");
		}

		public SimpleBrick GetNewSimpleBrick()
		{
			return Object.Instantiate(mySimpleBrick) as SimpleBrick;
		}
	}
}