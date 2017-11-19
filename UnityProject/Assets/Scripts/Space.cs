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
	void Change( string inText, Color inColor )
	{
		// テキスト
		mText.text = inText;
		mText.color = inColor;
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
			Change( "Space", Color.white );
		}
		if( Input.GetKeyDown( KeyCode.Backspace ) )
		{
			Change( "BackSpace", Color.white );
		}
	}
	void Start()
	{
		Change( "Space", Color.white );
	}
	void Update()
	{
		if( mGameManager.IsRetryWait )
		{
			if( Input.GetKeyDown( KeyCode.Space ) )
			{
				Change( "Space", Color.white );
				mGameManager.Retry();
				mFallCharManager.Initialize();
			}
			return;
		}
		if( mGameManager.IsGameOver )
		{
			Change( "GameOver..", Color.red );
			mGameManager.IsRetryWait = true;
			return;
		}
		if( mGameManager.IsGameClear )
		{
			Change( "StageClear!", Color.blue );
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
