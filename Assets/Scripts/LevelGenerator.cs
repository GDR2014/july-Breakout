using Breakout.Bricks;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

	//[SerializeField] private int myBrick.AssetWidthInCells = 2, myBrick.AssetHeightInCells = 1;

    [SerializeField] private int myGridWidth = 16, myGridHeight = 8;

    private float myGridMargin = .05f;
    private float myCellSize;

	private BrickFactory myBrickFactory;

    void Start() {
		myBrickFactory = new BrickFactory();
        Camera cam = Camera.main;
        myCellSize = (cam.orthographicSize * cam.aspect * 2 - myGridMargin * 2) / myGridWidth;
        FillGrid();
    }

    void FillGrid() {
		// TODO: Fix loop to prevent overflow in the case of AssetHeight > 1. This is just a quick "make it work"-solution, though, so it's okay for now.
        for( int row = 0; row < myGridHeight; ) 
		{
            for( int col = 0; col < myGridWidth;  )
            {
	            AbstractLevelGeneratorAsset asset = myBrickFactory.GetNewSimpleBrick();
	            row += asset.AssetHeightInCells;
	            col += asset.AssetWidthInCells;
                Vector2 position = new Vector2();
                position.x = col * myCellSize;
                position.y = row * myCellSize;
                asset.transform.parent = transform;
                asset.transform.localPosition = position;
            }
        }
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