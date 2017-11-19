using UnityEngine;

public class FixScreenCamera : MonoBehaviour
{


	// Update is called once per frame
	void Update()
	{
		// カメラコンポーネントを取得します
		// カメラのorthographicSizeを設定
		Camera.main.orthographicSize = 500.0f / 2.0f/ 30.0f;
	}
}
