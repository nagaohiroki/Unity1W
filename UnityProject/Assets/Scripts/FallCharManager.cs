using UnityEngine;
using System.Collections.Generic;
public class FallCharManager : MonoBehaviour
{
	readonly List<string> mTutorial = new List<string>
	{
		"ここの",
		"文字に",
		"全角スペースが",
		"入っている",
		"時だけ",
		"BackSpaceキーを",
		"押してね",
		"それ以外の時は",
		"Spaceキーを",
		"押してね",
		"GameOverした時",
		"Spaceキーで",
		"リトライできるよ",
		"クリアした時も",
		"Spaceキーで",
		"次に行けるよ",
		"ステージは",
		"全部で",
		"100万以上あるよ",
		"では",
		"よーい",
		"ス タ　ー ト !",
	};
	[SerializeField]
	Color mStart;
	[SerializeField]
	Color mEnd;
	[SerializeField]
	int mFrame;
	[SerializeField]
	FallChar mFallCharPrefab;
	[SerializeField]
	GameManager mGameManager;
	List<string> mChars;
	List<GameObject> mFallChars = new List<GameObject>();
	int mProgress;
	int mStage;
	const float mBaseSpeed = 5.0f;
	const float mStageWeightSpeed = 0.3f;
	const int mCharBaseCount = 3;
	public void Initialize()
	{
		mProgress = 0;
		ClearFallChars();
		if( mStage == 0 )
		{
			mChars = new List<string>();
			mChars.AddRange( mTutorial );
			return;
		}
		GenerateChars();
	}
	void GenerateChars()
	{
		mChars = new List<string>();
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
