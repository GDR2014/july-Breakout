using Breakout.Balls;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public enum GameEventType
    {
        START,
        LEVEL_CLEARED,
        BALL_LOST,
        BALL_RESET,
        GAME_OVER,
    }

    public delegate void GameEventHandler( GameEventType type );

    public event GameEventHandler GameEvent;

    private static GameManager myInstance;
    public static GameManager Instance
    {
        get
        {
            if( myInstance == null ) myInstance = FindObjectOfType<GameManager>();
            return myInstance;
        }
    }

    private void Start()
    {
        LifeManager lifeManager = FindObjectOfType<LifeManager>();
        lifeManager.DeathTrigger.DeathTriggerEvent += OnDeathTrigger;
    }

    public void StartNewGame()
    {
        GameEvent( GameEventType.START );
    }

    public void LevelCleared()
    {
        GameEvent( GameEventType.LEVEL_CLEARED );
    }

    public void BallLost()
    {
        GameEvent( GameEventType.BALL_LOST );
    }

    public void ResetBall()
    {
        GameEvent( GameEventType.BALL_RESET );
    }

    public void GameOver()
    {
        GameEvent( GameEventType.GAME_OVER );
    }

    private void OnDeathTrigger( DeathTrigger.DeathTriggerEventType aType, GameObject aGameObject )
    {
        if( aType != DeathTrigger.DeathTriggerEventType.EXIT || aGameObject.GetComponent<Ball>() == null ) return;

        BallLost();
        if( LifeManager.Lives < 0 )
        {
            GameOver();
            return;
        }
        ResetBall();
    }
}