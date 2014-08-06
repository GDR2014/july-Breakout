using UnityEditor;
using UnityEngine;

namespace Breakout.Bricks
{
	public class BrickFactory
	{
		private SimpleBrick mySimpleBrick;

		public BrickFactory()
		{
			mySimpleBrick = Resources.Load<SimpleBrick>("Prefabs/Bricks/SimpleBrick");
			Debug.Log(mySimpleBrick);
		}

		public SimpleBrick GetNewSimpleBrick()
		{
			return Object.Instantiate(mySimpleBrick) as SimpleBrick;
		}
	}
}