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

    void Start()
    {
        LifeChangedEvent += OnLifeChanged;
        LifeChangedEvent( myLives );
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

    public void OnLifeChanged( int remainingLives )
    {
        myLivesRemainingText.text = LIVES_REMAINING_PREFIX_TEXT + remainingLives;
    }
}
