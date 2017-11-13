using UnityEngine;
public class FallChar : MonoBehaviour
{
	const float mEndY = -10.0f;
	const float mStartY = 10.0f;
	float mSpeed;
	public void SetParameter( string inChar, float inSpeed )
	{
		mSpeed = inSpeed;
		var txt = GetComponent<TextMesh>();
		if( txt == null )
		{
			return;
		}
		txt.text = inChar;
	}
	void Start()
	{
		transform.position = Vector3.up * mStartY;
	}
	void Update()
	{
		transform.Translate( Vector3.down * mSpeed * Time.deltaTime );
		if( transform.position.y < mEndY )
		{
			Destroy( gameObject );
		}
	}
}
