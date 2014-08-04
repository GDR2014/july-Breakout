using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    [SerializeField] private GameObject myBrick;

    [SerializeField] private int myBrickWidth = 2, myBrickHeight = 1;

    [SerializeField] private int myGridWidth = 16, myGridHeight = 8;

    private float myGridMargin = .05f;
    private float myCellSize;

    void Start() {
        Camera cam = Camera.main;
        myCellSize = (cam.orthographicSize * cam.aspect * 2 - myGridMargin * 2) / myGridWidth;
        FillGrid();
    }

    void FillGrid() {
        for( int row = 0; row <= myGridHeight - myBrickHeight; row += myBrickHeight ) {
            for( int col = 0; col <= myGridWidth - myBrickWidth; col += myBrickWidth ) {
                Vector2 position = new Vector2();
                position.x = col * myCellSize;
                position.y = row * myCellSize;
                GameObject brick = (GameObject) Instantiate( myBrick );
                brick.transform.parent = transform;
                brick.transform.localPosition = position;
            }
        }
    }
    
}