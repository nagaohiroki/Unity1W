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
	[SerializeField]
	FallCharManager mFallCharManager;
	void Change( string inText )
	{
		// テキスト
		mText.text = inText;
		mText.color = Color.white;
		// サイズ
		Vector3 size = mRenderer.bounds.size;
		size.y *= 0.5f;
		mCol.size = size;
		// 位置
		Vector2 offset = mRenderer.bounds.extents;
		offset.y = -offset.y;
		mCol.offset = offset;
	}
	void GameUpdate()
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
	void Start()
	{
		Change( "Space" );
	}
	void Update()
	{
		if( mGameManager.IsRetryWait )
		{
			if( Input.GetKeyDown( KeyCode.Space ) )
			{
				Change( "Space" );
				mGameManager.Retry();
				mFallCharManager.Initialize();
			}
			return;
		}
		if( mGameManager.IsGameOver )
		{
			Change( "GameOver" );
			mGameManager.IsRetryWait = true;
			return;
		}
		if( mGameManager.IsGameClear )
		{
			Change( "StageClear!" );
			mGameManager.IsRetryWait = true;
			return;
		}
		GameUpdate();
	}
	void OnTriggerEnter2D( Collider2D inCollider )
	{
		var fallChar = inCollider.gameObject.GetComponent<FallChar>();
		if( fallChar != null )
		{
			fallChar.CheckDead( true );
		}
	}
}
