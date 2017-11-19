using UnityEngine;
public class FixScreenCamera : MonoBehaviour
{
	void Update()
	{
		Camera.main.orthographicSize = 500.0f / 2.0f/ 30.0f;
	}
}
