using Breakout.Bricks;
using UnityEngine;
using BrickType = Breakout.Bricks.BrickFactory.BrickType;

namespace Breakout
{
	/// <summary>
	/// This class creates and manages the levels
	/// </summary>
	public class LevelManager : MonoBehaviour {
		[SerializeField] private const int myGridWidth = 16;
		[SerializeField] private const int myGridHeight = 8;
		[SerializeField] private const float myGridMargin = 0.0f;
		private float myCellSize;

		private BrickFactory myBrickFactory;

		private static LevelManager _instance;

		public static LevelManager Instance
		{
			get
			{
				if (_instance == null) _instance = FindObjectOfType<LevelManager>();
				return _instance;
			}
		}

		public delegate void LevelCompletedHandler();
		public static event LevelCompletedHandler LevelCompletedEvent;

		void Start() {
			myBrickFactory = new BrickFactory();
			myBrickFactory.RemainingBricksCountChangedEvent += OnRemainingBricksCountChanged;
			Camera cam = Camera.main;
			myCellSize = (cam.orthographicSize * cam.aspect * 2 - myGridMargin * 2) / myGridWidth;
			FillGrid();
		}

		public void GenerateLevel()
		{
			foreach (AbstractBrick brick in FindObjectsOfType<AbstractBrick>())
			{
				Destroy(brick);
			}
			FillGrid();
		}

		void FillGrid()
		{
			const float halfGridWidth = myGridWidth / 2.0f;
			const float halfHeightWidth = myGridHeight / 2.0f;
			const float halfBrickWidth = 1; // HACK: Temporary solution until real level generation
			// TODO: Fix loop to prevent overflow in the case of AssetHeight > 1. This is just a quick "make it work"-solution, though, so it's okay for now.
			for( float row = -halfHeightWidth; row < halfGridWidth; )
			{
				AbstractLevelGeneratorAsset asset = null;
				for( float col = -halfGridWidth - halfBrickWidth; col < halfGridWidth-halfBrickWidth;  )
				{
					asset = myBrickFactory.GetBrick(BrickType.SIMPLE);
					col += asset.AssetWidthInCells;
					Vector2 assetSize = asset.transform.localScale;
					assetSize *= myCellSize;
					asset.transform.localScale = assetSize;
					Vector2 position = new Vector2();
					position.x = col * myCellSize;
					position.y = row * myCellSize;
					asset.transform.parent = transform;
					asset.transform.localPosition = position;
				}
				if(asset == null) break;
				row += asset.AssetHeightInCells;
			}
		}

		void OnRemainingBricksCountChanged(int previousValue)
		{
			if (BrickFactory.RemainingBricksCount > 0) return;
			LevelCompletedEvent();
		}
    
		/// <summary>
		/// Superclass for objects that should be usable in the level generator.
		/// </summary>
		public abstract class AbstractLevelGeneratorAsset : MonoBehaviour
		{
			public abstract int AssetHeightInCells { get; }
			public abstract int AssetWidthInCells { get; } 
		}
	}
}