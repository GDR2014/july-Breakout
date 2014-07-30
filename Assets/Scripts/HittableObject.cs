using UnityEngine;

public class HittableObject : MonoBehaviour 
{
	void OnTriggerEnter2D(Collider2D aCollider2D)
	{
		Ball ball = aCollider2D.gameObject.GetComponent<Ball>();
		ball.Bounce();
	}
}
