using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public void goToMenu() {
		SceneManager.LoadScene("Scene for User Interface (Main)",LoadSceneMode.Single);
	}
}
