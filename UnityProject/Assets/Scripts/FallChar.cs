using UnityEngine;
public class FallChar : MonoBehaviour
{
	[SerializeField]
	TextMesh mText;
	[SerializeField]
	GameManager mGameManager;
	const float mEndY = -10.0f;
	const float mStartY = 10.0f;
	float mSpeed;
	public bool IsHankaku
	{
		get
		{
			return mText.text.IndexOf( '　' ) == -1;
		}
	}
	public void SetParameter( string inChar, float inSpeed )
	{
		mSpeed = inSpeed;
		if( mText == null )
		{
			return;
		}
		mText.text = inChar;
	}
	void Start()
	{
		transform.position = Vector3.up * mStartY;
	}
	void Update()
	{
		if( mGameManager.IsGameOver )
		{
			Destroy( gameObject );
			return;
		}
		transform.Translate( Vector3.down * mSpeed * Time.deltaTime );
		if( transform.position.y > mEndY )
		{
			return;
		}
		Destroy( gameObject );
		if( !IsHankaku )
		{
			mGameManager.GameOver();
		}
	}
}
