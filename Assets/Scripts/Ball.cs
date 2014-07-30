using UnityEngine;

public class Ball : MonoBehaviour 
{

	public Vector2 myInitialVelocity = new Vector2(0, -3);

	Vector2 myCurrentVelocity;

	private Rigidbody2D myRigidbody;

	void Awake()
	{
		myRigidbody = GetComponent<Rigidbody2D>();
	}

	void Start ()
	{
		myCurrentVelocity = myInitialVelocity;
		myRigidbody.velocity = myCurrentVelocity;
	}

	private void Update()
	{
		myRigidbody.velocity = myCurrentVelocity;
	}

	public void Bounce()
	{
		myCurrentVelocity.y *= -1;
	}
}
