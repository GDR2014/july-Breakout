using UnityEngine;

/// <summary>
/// This class creates four BoxCollider2Ds: One for each of the left, right, 
/// top and bottom sides. It also updates their size if the screensize changes,
/// and controls the state of them (on/off). 
/// </summary>
public class CameraBasedWalls : MonoBehaviour
{
	#region Wall states
	[SerializeField] private bool
		_isLeftWallActive = true,
		_isRightWallActive = true,
		_isTopWallActive = true,
		_isBottomWallActive = false;

	public bool IsLeftWallActive
	{
		get { return _isLeftWallActive; }
		set
		{
			_isLeftWallActive = value;
			myLeftWall.enabled = value;
		}
	}
	
	public bool IsRightWallActive
	{
		get { return _isRightWallActive; }
		set
		{
			_isRightWallActive = value;
			myRightWall.enabled = value;
		}
	}
	
	public bool IsTopWallActive
	{
		get { return _isTopWallActive; }
		set
		{
			_isTopWallActive = value;
			myTopWall.enabled = value;
		}
	}

	public bool IsBottomWallActive
	{
		get { return _isBottomWallActive; }
		set
		{
			_isBottomWallActive = value;
			myBottomWall.enabled = value;
		}
	}
	#endregion

	#region Bounds properties
	public Rect LeftWallBounds
	{
		get { return getBoxColliderBounds(myLeftWall); }
		set { setBoxColliderBounds(myLeftWall, value); }
	}
	
	public Rect RightWallBounds
	{
		get { return getBoxColliderBounds(myRightWall); }
		set { setBoxColliderBounds(myRightWall, value); }
	}
	
	public Rect TopWallBounds
	{
		get { return getBoxColliderBounds(myTopWall); }
		set { setBoxColliderBounds(myTopWall, value); }
	}
	
	public Rect BottomWallBounds
	{
		get { return getBoxColliderBounds(myBottomWall); }
		set { setBoxColliderBounds(myBottomWall, value); }
	}
	#endregion

	private BoxCollider2D myLeftWall;
	private BoxCollider2D myRightWall;
	private BoxCollider2D myTopWall;
	private BoxCollider2D myBottomWall;

	/// <summary>
	/// The camera to create bounds for.
	/// </summary>
	[SerializeField]
	private Camera myCamera;

	/// <summary>
	/// The thickness of the walls.
	/// </summary>
	[SerializeField]
	private float myWallThickness = 1.0f;

	void Start()
	{
		myLeftWall = gameObject.AddComponent<BoxCollider2D>();
		myRightWall = gameObject.AddComponent<BoxCollider2D>();
		myTopWall = gameObject.AddComponent<BoxCollider2D>();
		myBottomWall = gameObject.AddComponent<BoxCollider2D>();

		myLeftWall.hideFlags = HideFlags.HideInInspector;
		myRightWall.hideFlags = HideFlags.HideInInspector;
		myTopWall.hideFlags = HideFlags.HideInInspector;
		myBottomWall.hideFlags = HideFlags.HideInInspector;

		// Update states to match those set in the inspector
		IsLeftWallActive = IsLeftWallActive;
		IsRightWallActive = IsRightWallActive;
		IsTopWallActive = IsTopWallActive;
		IsBottomWallActive = IsBottomWallActive;

		updateWallPositionsAndSizes();
	}

	private void updateWallPositionsAndSizes()
	{
		// Save some camera details
		float wallHeight = myCamera.orthographicSize * 2;
		float wallWidth = wallHeight * myCamera.aspect;
		float halfWallHeight = wallHeight / 2;
		float halfWallWidth = wallWidth / 2;
		float halfWallThickness = myWallThickness / 2;
		Vector2 cameraPosition = myCamera.transform.position;
		// Center the gameObject on the camera
		transform.position = cameraPosition;
		// Calculate X-coordinates for side walls
		float leftWallX = cameraPosition.x - halfWallWidth - halfWallThickness;
		float rightWallX = cameraPosition.x + halfWallWidth + halfWallThickness;
		// Calculate Y-coordinates for top and bottom walls
		float topWallY = cameraPosition.y + halfWallHeight + halfWallThickness;
		float bottomWallY = cameraPosition.y - halfWallHeight - halfWallThickness;
		// Create wall centers
		Vector2 leftWallCenter = new Vector2(leftWallX, cameraPosition.y);
		Vector2 rightWallCenter = new Vector2(rightWallX, cameraPosition.y);
		Vector2 topWallCenter = new Vector2(cameraPosition.x, topWallY);
		Vector2 bottomWallCenter = new Vector2(cameraPosition.x, bottomWallY);
		// Create wall sizes
		Vector2 sideWallSize = new Vector2(myWallThickness, wallHeight);
		Vector2 topAndBottomWallSize = new Vector2(wallWidth, myWallThickness);
		// Assign values
		myLeftWall.center = leftWallCenter;
		myLeftWall.size = sideWallSize;
		myRightWall.center = rightWallCenter;
		myRightWall.size = sideWallSize;
		myTopWall.center = topWallCenter;
		myTopWall.size = topAndBottomWallSize;
		myBottomWall.center = bottomWallCenter;
		myBottomWall.size = topAndBottomWallSize;
	}

	/// <summary>
	/// Returns the bounds of a BoxCollider2D as a Rect.
	/// </summary>
	/// <param name="aBoxCollider2D">The BoxCollider2D to get the bounds of</param>
	/// <returns>The bounds of the BoxCollider2D as a Rect.</returns>
	private Rect getBoxColliderBounds(BoxCollider2D aBoxCollider2D)
	{
		return convertCenterAndSizeToRect(aBoxCollider2D.center, aBoxCollider2D.size);
	}

	/// <summary>
	/// Converts center and size information from a rectangle to a Rect object.
	/// </summary>
	/// <param name="aCenter">The center of the rectangle.</param>
	/// <param name="aSize">The size of the rectangle.</param>
	/// <returns>A Rect defined from the given rectangle informations.</returns>
	private Rect convertCenterAndSizeToRect(Vector2 aCenter, Vector2 aSize)
	{
		float halfWidth = aSize.x / 2;
		float halfHeight = aSize.y / 2;
		float topLeftX = aCenter.x - halfWidth; 
		float topLeftY = aCenter.y + halfHeight;
		return new Rect(topLeftX, topLeftY, aSize.x, aSize.y);
	}

	/// <summary>
	/// Set the size and center of a BoxCollider2D to match those of a given
	/// Rect.
	/// </summary>
	/// <param name="aBoxCollider2D">The BoxCollider2D to modify.</param>
	/// <param name="aRect">The new bounds of the BoxCollider2D.</param>
	private void setBoxColliderBounds(BoxCollider2D aBoxCollider2D, Rect aRect)
	{
		float halfWidth = aRect.width / 2;
		float halfHeight = aRect.height / 2;
		float centerX = aRect.x + halfWidth;
		float centerY = aRect.y - halfHeight;
		aBoxCollider2D.center = new Vector2(centerX, centerY);
		aBoxCollider2D.size = new Vector2(aRect.width, aRect.height);
	}
}
