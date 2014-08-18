using UnityEngine;

namespace Assets.Scripts
{
	public class GameManager : MonoBehaviour
	{

		private static GameManager myInstance;

		public static GameManager Instance
		{
			get
			{
				if (myInstance == null) myInstance = FindObjectOfType<GameManager>();
				return myInstance;
			}
		}

		void Start()
		{
			LifeManager.LifeChangedEvent += OnLifeChanged;
		}

		private void resetBall()
		{
			Paddle paddle = FindObjectOfType<Paddle>();
			Ball ball = FindObjectOfType<Ball>();
			paddle.SetStuck(ball);
		}

		private void gameOver()
		{
			
		}

		private void OnLifeChanged(int currentlives, int previouslives)
		{
			Debug.Log(string.Format("Lives: {0}, Previous lives: {1}", currentlives, previouslives));
			if (currentlives >= previouslives) return; // Only act if a life was lost
			if (currentlives < 0) gameOver();
			else resetBall();
		}
	}
}