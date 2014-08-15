using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    private const float EXTRA_Y_OFFSET = .5f;
    private const float TRIGGER_HEIGHT = .1f;

    public enum DeathTriggerEventType
    {
        ENTER, EXIT, STAY
    }

    public delegate void DeathTriggerHandler(DeathTriggerEventType type, GameObject gameObject);
    public event DeathTriggerHandler DeathTriggerEvent;

    void Start()
    {
        initializePositionAndSize();
    }

    void initializePositionAndSize()
    {
        Camera mainCam = Camera.main;
        
        float halfHeight = mainCam.orthographicSize;
        Vector2 position = transform.position;
        position.y = mainCam.transform.position.y - halfHeight - EXTRA_Y_OFFSET;
        transform.position = position;

        float width = halfHeight * mainCam.aspect * 2;
        transform.localScale = new Vector2(width, TRIGGER_HEIGHT);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        DeathTriggerEvent( DeathTriggerEventType.ENTER, other.gameObject );
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        DeathTriggerEvent(DeathTriggerEventType.EXIT, other.gameObject);
    }
    
    void OnTriggerStay2D(Collider2D other)
    {
        DeathTriggerEvent(DeathTriggerEventType.STAY, other.gameObject);
    }
    
    
}
