using UnityEngine;
public class FallCharManager : MonoBehaviour
{
	string[] mChars =
	{
		"a a",
		"a　a"
	};
	[SerializeField]
	FallChar mFallCharPrefab;
	void Update()
	{
		if( Time.frameCount % 30 == 0 )
		{
			GenerateFallChar( RandChar(), 10.0f );
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
