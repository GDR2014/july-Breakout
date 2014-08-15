using Breakout.Bricks;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

/// <summary>
/// This class manages score logic and UI
/// </summary>
public class ScoreManager : MonoBehaviour {

    private int _score = 0;
	
    /// <summary>
	/// The global score variable. It might be useful to limit the scope of
	/// this later.
	/// </summary>
	public int Score 
    {
	    get {
	        return _score;
	    }
	    set {
	        _score = value;
	        myScoreText.text = "" + value;
	    } 
    }

    private static ScoreManager _instance = null;
    public static ScoreManager Instance {
        get {
            if( _instance == null ) _instance = FindObjectOfType<ScoreManager>();
            return _instance;
        }
    }

    [SerializeField]
    private GUIText myScoreText;

    void Start()
    {
        Score = 0;
        AbstractBrick.BrickDestroyedEvent += OnBrickDestroyed;
    }

    void OnBrickDestroyed( AbstractBrick brick )
    {
        Score += brick.ScoreValue;
    }
}
