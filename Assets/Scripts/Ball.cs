using UnityEngine;

public class Ball : MonoBehaviour 
{
	public Vector2 myInitialVelocity = new Vector2(0, -3);
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
