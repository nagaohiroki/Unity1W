using UnityEngine;
public class FallCharManager : MonoBehaviour
{
	readonly string[] mChars =
	{
		"a a",
		"a　a"
	};
	readonly string[] mGameOverChars =
	{
		"GaemOver",
		"Press",
		"SpaceKey",
	};
	[SerializeField]
	FallChar mFallCharPrefab;
	[SerializeField]
	GameManager mGameManager;
	int mProgress;
	void Update()
	{
		if( mGameManager == mGameManager.IsGameOver )
		{
			mProgress = 0;
			return;
		}
		if( Time.frameCount % 30 == 0 )
		{
			GenerateFallChar( RandChar(), 10.0f );
			++mProgress;
			Debug.Log( mProgress );
		}
	}
	string RandChar()
	{
		return mChars[Random.Range( 0, mChars.Length )];
	}
	void GenerateFallChar( string inChar, float inSpeed )
	{
		var go = Object.Instantiate( mFallCharPrefab );
		if( go == null )
		{
			return;
		}
		var fallChar = go.GetComponent<FallChar>();
		if( fallChar == null )
		{
			return;
		}
		fallChar.gameObject.SetActive( true );
		fallChar.SetParameter( inChar, inSpeed );
	}
}
