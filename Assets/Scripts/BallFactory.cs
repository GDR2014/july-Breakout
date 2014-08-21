using UnityEngine;

namespace Breakout.Balls
{
    public class BallFactory
    {
        private Ball myBallPrefab;

        private void Start()
        {
            myBallPrefab = Resources.Load<Ball>( "Prefabs/Ball" );
        }

        public Ball CreateBall()
        {
            return new Ball();
        }
    }
}