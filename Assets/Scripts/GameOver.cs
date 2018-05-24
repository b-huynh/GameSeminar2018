using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour
{
	public GameObject gameoverObject;

	void OnTriggerEnter (Collider hit)
	{
		if (hit.CompareTag("Player")) {
			// オブジェクトをアクティブにする
			gameoverObject.SetActive (true);
		}
	}
}