using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
 
public class SceneLoadScript : MonoBehaviour {
 
	//　スタートボタンを押したら実行する
	public void GameStart() {
		SceneManager.LoadScene ("Portal");
	}

    void LateUpdate() {
        if (SceneManager.GetActiveScene().name == "Portal")
        {
            if (transform.position.z < -12)
            {
                SceneManager.LoadScene("Portal1");
            }
        }
    }
}