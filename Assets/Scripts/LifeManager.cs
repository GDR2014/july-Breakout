using Breakout.Balls;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public delegate void LifeChangedHandler(int currentLives);
    public static event LifeChangedHandler LifeChangedEvent;

    [SerializeField]
    private static int myLives = 3;
    public static int Lives { get { return myLives; } }

    [SerializeField] private GUIText myLivesRemainingText;
    [SerializeField] private const string LIVES_REMAINING_PREFIX_TEXT = "Lives: ";
    [SerializeField] public DeathTrigger DeathTrigger { get; private set; }

    void Start()
    {
        LifeChangedEvent += OnLifeChanged;
        LifeChangedEvent( myLives );
        DeathTrigger.DeathTriggerEvent += OnDeathTrigger;
    }

    public void LoseLife()
    {
        myLives--;
        LifeChangedEvent(myLives);
    }

    public void GainLife()
    {
        myLives++;
        LifeChangedEvent( myLives );
    }

    private void OnLifeChanged( int remainingLives )
    {
        myLivesRemainingText.text = LIVES_REMAINING_PREFIX_TEXT + remainingLives;
    }

    private void OnDeathTrigger( DeathTrigger.DeathTriggerEventType aType, GameObject aGameObject )
    {
        if( aType != DeathTrigger.DeathTriggerEventType.EXIT || aGameObject.GetComponent<Ball>() == null ) return;
        LoseLife();
    }
}
