using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public string sceneName;
	public bool quit;
	
	public void GoTo() {
		if (quit){
			Application.Quit();
		}
		SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
	}

}
