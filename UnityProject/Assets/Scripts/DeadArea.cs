using UnityEngine;
public class DeadArea : MonoBehaviour
{
	[SerializeField]
	GameManager mGameManager;
	void OnTriggerEnter2D( Collider2D inCollider )
	{
		var fallChar = inCollider.gameObject.GetComponent<FallChar>();
		if( fallChar == null )
		{
			return;
		}
		fallChar.CheckDead( false );
	}
}
