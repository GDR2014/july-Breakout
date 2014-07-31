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

	void Update()
	{
		handleInput();
	}

	/// <summary>
	/// Handles the player input
	/// </summary>
	private void handleInput()
	{
		Vector2 position = transform.position;
		float horizontalInput = Input.GetAxis("Horizontal");
		position.x += horizontalInput * myMoveSpeed * Time.deltaTime;
		transform.position = position;
	}
}
