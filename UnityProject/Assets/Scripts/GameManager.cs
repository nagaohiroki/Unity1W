using UnityEngine;
public class GameManager : MonoBehaviour
{
	public bool IsGameOver{get; private set;}
	public bool IsGameClear{get; private set;}
	public bool IsRetryWait{get; set;}
	public void GameOver()
	{
		IsGameOver = true;
		Debug.Log( "GameOver" );
	}
	public void GameClear()
	{
		IsGameClear = true;
		Debug.Log( "GameClear" );
	}
	public void Retry()
	{
		IsGameOver = false;
		IsGameClear = false;
		IsRetryWait = false;
		Debug.Log( "Retry" );
	}
}
