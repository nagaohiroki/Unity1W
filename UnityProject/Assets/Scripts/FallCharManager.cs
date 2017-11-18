using UnityEngine;
using System.Collections.Generic;
public class FallCharManager : MonoBehaviour
{
	[SerializeField]
	int mFrame;
	[SerializeField]
	FallChar mFallCharPrefab;
	[SerializeField]
	GameManager mGameManager;
	List<string> mChars;
	List<GameObject> mFallChars = new List<GameObject>();
	int mProgress;
	int mStage = 1;
	const float mBaseSpeed = 10.0f;
	const float mStageWeightSpeed = 0.3f;
	const int mCharBaseCount = 3;
	public void Initialize()
	{
		ClearFallChars();
		GenerateChars();
	}
	void GenerateChars()
	{
		mChars = new List<string>();
		mProgress = 0;
		int count = mCharBaseCount + mStage;
		for( int i = 0; i < count; ++i )
		{
			var str = string.Format( "Stage {0} - {1} / {2}", mStage, i + 1, count );
			if( Random.Range( 0, 3 ) == 0 )
			{
				 str = RandromReplace( str, " ", "　" );
			}
			mChars.Add( str );
		}
	}
	void ClearFallChars()
	{
		int fallCharCount = mFallChars.Count;
		for( int i = 0; i < fallCharCount; ++i )
		{
			if( mFallChars[i] != null )
			{
				Destroy( mFallChars[i] );
			}
		}
		mFallChars.Clear();
	}
	void Fall()
	{
		if( mProgress >= mChars.Count )
		{
			return;
		}
		if( Time.frameCount % mFrame != 0 )
		{
			return;
		}
		GenerateFallChar();
		++mProgress;
	}
	void GenerateFallChar()
	{
		string ch = mChars[mProgress];
		bool isLast = mProgress == mChars.Count - 1;
		float speed = mBaseSpeed + mStageWeightSpeed * mStage;
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
		fallChar.SetParameter( ch, speed, isLast );
		mFallChars.Add( fallChar.gameObject );
	}
	string RandromReplace( string inText, string inA, string inB )
	{
		var indexList = new List<int>();
		int index = 0;
		while( true )
		{
			index = inText.IndexOf( inA, index + 1, System.StringComparison.CurrentCulture );
			if( index == -1 )
			{
				break;
			}
			indexList.Add( index );
		}
		if( indexList.Count == 0 )
		{
			return inText;
		}
		int randomIndex = Random.Range( 0, indexList.Count );
		int position = indexList[randomIndex];
		return inText.Remove( position, inA.Length ).Insert( position, inB );
	}
	void Start()
	{
		Initialize();
	}
	void Update()
	{
		if( mGameManager.IsRetryWait )
		{
			return;
		}
		if( mGameManager.IsGameOver )
		{
			return;
		}
		if( mGameManager.IsGameClear )
		{
			++mStage;
			return;
		}
		Fall();

	}
}
