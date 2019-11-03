using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void GoToMenu() {
		SceneManager.LoadScene("Scene for User Interface (Main)", LoadSceneMode.Single);
	}

}
