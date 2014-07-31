using UnityEngine;

/// <summary>
/// The simplest of bricks. Destroy these to get points and complete the level.
/// </summary>
public class Brick : MonoBehaviour 
{
	/// <summary>
	/// Called when the brick enters collision with another object.
	/// </summary>
	/// <param name="aCollison">Details about the collision.</param>
	void OnCollisionEnter2D(Collision2D aCollison)
	{
		// TODO: Put brick destruction logic here (if the colliding gameObject is a ball or something similar)
	}
}
