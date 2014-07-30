using UnityEngine;

public class Paddle : MonoBehaviour
{
	public float myMoveSpeed = 10f;

	void Update()
	{
		Vector2 position = transform.position;
		float horizontalInput = Input.GetAxis("Horizontal");
		position.x += horizontalInput * myMoveSpeed * Time.deltaTime;
		transform.position = position;
	}
}
