using Breakout;
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
			LevelManager.LevelCompletedEvent += OnLevelCompleted;
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

		private void OnLevelCompleted()
		{
			resetBall();
			LifeManager.Instance.GainLife();
			LevelManager.Instance.GenerateLevel();
		}

		private void OnLifeChanged(int currentlives, int previouslives)
		{
			if (currentlives >= previouslives) return; // Only act if a life was lost
			if (currentlives < 0) gameOver();
			else resetBall();
		}
	}
}