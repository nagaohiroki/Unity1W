using UnityEngine;
public class Space : MonoBehaviour
{
	[SerializeField]
	TextMesh mText;
	[SerializeField]
	BoxCollider2D mCol;
	[SerializeField]
	Renderer mRenderer;
	void Change( string inText )
	{
		mText.text = inText;
		mCol.size = mRenderer.bounds.size;
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
}
