using UnityEngine;

public class Space : MonoBehaviour
{
	[SerializeField]
	TextMesh Text;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if( Input.GetKeyDown( KeyCode.Space ) )
		{
			Text.text = "Space";
		}
		if( Input.GetKeyDown( KeyCode.Backspace ) )
		{
			Text.text = "BackSpace";
		}

	}
}
