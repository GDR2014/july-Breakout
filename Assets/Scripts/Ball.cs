using UnityEngine;

/// <summary>
/// Bouncy thing that can destroy some bricks. You will normally lose a life,
/// if it manages to hit the bottom of the screen.
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour 
{
	// TODO: Possibly move the initialVelocity logic to a separate monobehaviour?
	public Vector2 myInitialVelocity = new Vector2(0, -3);

	/// <summary>
	/// The rigidbody attached to this ball. Could alternatively use 
	/// this.rigidbody2D instead, but I don't know how Unity handles the 
	/// caching of GameObject component variables.
	/// </summary>
	private Rigidbody2D myRigidbody;

	void Awake()
	{
		myRigidbody = GetComponent<Rigidbody2D>();
	}

	void Start ()
	{
		myRigidbody.velocity = myInitialVelocity;
	}

}
