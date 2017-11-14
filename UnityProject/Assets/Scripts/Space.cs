using UnityEngine;
public class Space : MonoBehaviour
{
	[SerializeField]
	TextMesh mText;
	[SerializeField]
	BoxCollider2D mCol;
	[SerializeField]
	Renderer mRenderer;
	[SerializeField]
	GameManager mGameManager;

	const float mScaleYBias = 0.5f;
	void Change( string inText )
	{
		mText.text = inText;
		Vector3 size = mRenderer.bounds.size;
		size.y *= mScaleYBias;
		mCol.size = size;
		Vector2 offset = mRenderer.bounds.extents;
		offset.y = -offset.y;
		mCol.offset = offset;
	}
	void Start()
	{
		Change( "Space" );
	}
	void Update()
	{
		if( Input.GetKeyDown( KeyCode.Space ) )
		{
			Change( "Space" );
		}
		if( Input.GetKeyDown( KeyCode.Backspace ) )
		{
			Change( "BackSpace" );
		}
	}
	void OnTriggerEnter2D( Collider2D inCollider )
	{
		var fallChar = inCollider.gameObject.GetComponent<FallChar>();
		if( fallChar == null )
		{
			return;
		}
		if(fallChar.IsHankaku)
		{
			mGameManager.GameOver();
		}
		Destroy( fallChar.gameObject );
	}
}
