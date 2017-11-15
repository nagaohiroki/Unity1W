using UnityEngine;

public class GameManager : MonoBehaviour
{
	public bool IsGameOver{get; private set;}
	public bool IsRetry
	{
		get
		{
			return IsGameOver && mRetryTimer > 1.0f;
		}
	}
	float mRetryTimer;
	public void GameOver()
	{
		mRetryTimer = 0.0f;
		IsGameOver = true;
		Debug.Log( "GameOver" );
	}
	void Retry()
	{
		if( !IsRetry )
		{
			mRetryTimer += Time.deltaTime;
			return;
		}
		if( Input.GetKeyDown( KeyCode.Space ) )
		{
			mRetryTimer = 0.0f;
			IsGameOver = false;
			Debug.Log( "Retry" );
		}
	}
	void Update()
	{
		Retry();
	}
}
