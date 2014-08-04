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
	[SerializeField]
	private float myMoveSpeed = 10f;

    private float myMaxAbsoluteXPosition { get { return myMainCamera.orthographicSize * myMainCamera.aspect - collider2D.bounds.size.x / 2; }} // TODO: Move screen width calculation to a proper class

    private Camera myMainCamera;

    void Start() {
        myMainCamera = Camera.main;
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
	}
}
