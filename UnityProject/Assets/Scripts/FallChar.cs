using UnityEngine;
public class FallChar : MonoBehaviour
{
	[SerializeField]
	BoxCollider2D mCol;
	[SerializeField]
	Renderer mRenderer;
	[SerializeField]
	TextMesh mText;
	[SerializeField]
	GameManager mGameManager;
	Vector3 mStart = new Vector3( 1.0f, 10.0f, 0.0f );
	float mSpeed;
	bool IsZenkaku
	{
		get
		{
			return mText.text.IndexOf( '　' ) != -1;
		}
	}
	public bool mIsLast {get; private set;}
	public void SetParameter( string inText, float inSpeed, bool inIsLast )
	{
		mSpeed = inSpeed;
		mIsLast = inIsLast;
		if( mText == null )
		{
			return;
		}
		mText.text = inText;
		Vector3 size = mRenderer.bounds.size;
		mCol.size = size;
		Vector2 offset = mRenderer.bounds.extents;
		offset.y = -offset.y;
		mCol.offset = offset;
	}
	public void CheckDead( bool inIsSpace )
	{
		bool check = inIsSpace ? !IsZenkaku : IsZenkaku;
		if( check )
		{
			mGameManager.GameOver();
			return;
		}
		if( mIsLast )
		{
			mGameManager.GameClear();
			return;
		}
		Debug.Log("Destroy " + mText.text);
		Destroy( gameObject );
	}
	void Start()
	{
		transform.position = mStart;
	}
	void Update()
	{
		if( mGameManager.IsGameOver || mGameManager.IsGameClear || mGameManager.IsRetryWait )
		{
			return;
		}
		transform.Translate( Vector3.down * mSpeed * Time.deltaTime );
	}
}
