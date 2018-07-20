using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
 
public class SceneLoadScript : MonoBehaviour {

    private bool goalEntered;

	//　スタートボタンを押したら実行する
	public void GameStart() {
		SceneManager.LoadScene ("Portal");
	}

    void LateUpdate() {
        if (SceneManager.GetActiveScene().name == "Portal")
        {
            if (goalEntered)
            {
                SceneManager.LoadScene("Portal1");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            goalEntered = true;
        }
    }
}