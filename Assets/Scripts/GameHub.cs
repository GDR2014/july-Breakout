using UnityEngine;
using System.Collections;

/// <summary>
/// This class serves as a "hub" for information.
/// </summary>
public class GameHub : MonoBehaviour
{
	private ScoreManager myScoreManager;
	private LevelGenerator myLevelGenerator;

	// Use this for initialization
	void Start()
	{
		myScoreManager = ScoreManager.Instance;
		myLevelGenerator = FindObjectOfType<LevelGenerator>();
	}

	// Update is called once per frame
	void Update()
	{

	}
}
