using UnityEngine;
public class FallCharManager : MonoBehaviour
{
	string[] mChars =
	{
		"a", "ａ",
		"b", "ｂ"
	};
	[SerializeField]
	FallChar mFallCharPrefab;
	void Update()
	{
		if( Input.GetKeyDown( KeyCode.Alpha0 ) )
		{
		}
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
		fallChar.SetParameter( inChar, inSpeed );
	}
}
