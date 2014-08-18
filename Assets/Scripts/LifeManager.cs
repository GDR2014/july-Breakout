using System;
using UnityEngine;

public class LifeManager : MonoBehaviour
{

    public delegate void LifeChangedHandler(int currentLives, int previousLives);
    public static event LifeChangedHandler LifeChangedEvent;

    [SerializeField]
    private static int myLives = 3;
    public static int Lives { get { return myLives; } }

    [SerializeField] private GUIText myLivesRemainingText;
    [SerializeField] private const string LIVES_REMAINING_PREFIX_TEXT = "Lives: ";
    [SerializeField] private DeathTrigger myDeathTrigger;

    void Start()
    {
        LifeChangedEvent += OnLifeChanged;
        LifeChangedEvent( myLives, 0 );
        myDeathTrigger.DeathTriggerEvent += OnDeathTrigger;
    }

    public void LoseLife()
    {
		changeLives(myLives-1);
    }

    public void GainLife()
    {
	    changeLives(myLives+1);
    }

	public void changeLives(int newLives)
	{
		int previousLives = myLives;
		myLives = newLives;
		LifeChangedEvent(myLives, previousLives);
	}

    private void OnLifeChanged( int remainingLives, int previousLives )
    {
        myLivesRemainingText.text = LIVES_REMAINING_PREFIX_TEXT + remainingLives;
    }

    private void OnDeathTrigger( DeathTrigger.DeathTriggerEventType aType, GameObject aGameObject )
    {
        if( aType != DeathTrigger.DeathTriggerEventType.EXIT || aGameObject.GetComponent<Ball>() == null ) return;
        LoseLife();
    }
}
