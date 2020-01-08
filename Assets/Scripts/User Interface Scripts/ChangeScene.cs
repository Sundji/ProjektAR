using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public string sceneName;
	public bool quitButton;
	public bool continueButton;
	
	public void GoTo() {
		if (quitButton){
			Application.Quit();
		}
		else 
		{
			//aaaaa
			SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
		}
	}

}
