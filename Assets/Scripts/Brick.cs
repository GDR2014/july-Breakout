using UnityEngine;

/// <summary>
/// The simplest of bricks. Destroy these to get points and complete the level.
/// </summary>
public class Brick : MonoBehaviour 
{
	/// <summary>
	/// Called when the brick enters collision with another object.
	/// </summary>
	/// <param name="aCollison">Details about the collision.</param>
	void OnCollisionEnter2D(Collision2D aCollison) 
    {
	    GameObject other = aCollison.gameObject;
	    if( other.layer == 8 ) // Layer 8 = Balls
        {
            destroyBrick();
            increaseScore(1);
	    }
	}

    void destroyBrick() 
    {
        // TODO: Add callback to check for remaining bricks
        Destroy(this.gameObject);
    }

    void increaseScore( int aScoreAmount )
    {
        ScoreManager.Instance.Score += aScoreAmount;
    }
}
