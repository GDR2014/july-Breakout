using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// The paddle is a player-controlled object, that can move in order to prevent
/// the ball from reaching the bottom of the screen, as well as it can be used 
/// to aim the ball at bricks, and collect powerups.
/// </summary>
public class Paddle : MonoBehaviour
{
	/// <summary>
	/// The movement speed multiplier for the paddle.
	/// </summary>
	[SerializeField] private float myMoveSpeed = 10f;

    private float myMaxAbsoluteXPosition { get { return myMainCamera.orthographicSize * myMainCamera.aspect - collider2D.bounds.size.x / 2; }}

    private Dictionary<Ball, bool> myStuckBalls = new Dictionary<Ball, bool>();

    [SerializeField] private Transform myBallStuckPosition;
    public Vector2 BallStuckPosition { get { return myBallStuckPosition.position; } }

    // TODO: Move screen width calculation to a proper class
    private Camera myMainCamera;

    void Start()
    {
        myMainCamera = Camera.main;
        SetStuck(FindObjectOfType<Ball>());
    }

	void Update()
	{
		handleInput();
        clampPaddlePosition();
	}

    private void clampPaddlePosition() 
    {
        if (transform.position.x < -myMaxAbsoluteXPosition) transform.position = new Vector3(-myMaxAbsoluteXPosition, transform.position.y, transform.position.z);
        else if (transform.position.x > myMaxAbsoluteXPosition) transform.position = new Vector3(myMaxAbsoluteXPosition, transform.position.y, transform.position.z); 
    }

	/// <summary>
	/// Handles the player input
	/// </summary>
	private void handleInput()
	{
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 position = transform.position;
        position.x += horizontalInput * myMoveSpeed * Time.deltaTime;
        transform.position = position;

        if(Input.GetKeyDown("space")) ReleaseAllStuckBalls();
	}

    void ReleaseAllStuckBalls()
    {
        for(int i = 0; i < myStuckBalls.Count; i++)
        {
            Ball ball = myStuckBalls.Keys.ElementAt( i );
            Release(ball);
        }
    }

    public void SetStuck(Ball aBall)
    {
        bool isStuck;
        bool exists = myStuckBalls.TryGetValue( aBall, out isStuck );
        if (isStuck) return;
        if(!exists) myStuckBalls.Add(aBall, true);
        myStuckBalls[aBall] = true;
	    aBall.rigidbody2D.velocity = Vector2.zero;
        aBall.transform.parent = transform;
        aBall.transform.position = BallStuckPosition;
    }

    public void Release(Ball aBall)
    {
        bool isStuck;
        myStuckBalls.TryGetValue(aBall, out isStuck);
        if (!isStuck) return;
        myStuckBalls[aBall] = false;
        
        aBall.transform.parent = null;
        aBall.rigidbody2D.velocity = getReleaseVelocity();
    }
     
    private Vector2 getReleaseVelocity()
    {
        return Vector2.up * 3;
    }
}
