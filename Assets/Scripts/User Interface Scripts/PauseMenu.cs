using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
	public static bool Paused = false;
	public GameObject pauseMenuUI;
	
	//void Start () {
	   //     pauseMenuUI.SetActive(false);
	// }
    // Update is called once per frame
    void Update()
    {
    }
	
	
	public void onClick() 
	{
		Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
		//if (!Paused)
		//{
			Pause();
		//}
	}
	
	public void Resume(){
		Debug.Log("bbbbbb");
		pauseMenuUI.SetActive(false);
		Time.timeScale=1f;
		Paused = false;
	}
	
	void Pause(){
		Debug.Log("aCAYAX");
		pauseMenuUI.SetActive(true);
		Time.timeScale=0f;
		Paused = true;
		
	}
}
