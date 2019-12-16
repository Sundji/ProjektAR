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
		if (Input.GetKeyDown(KeyCode.Escape)){
	        if (Paused)
			{
				Resume();
			} else 
			{
				Pause();
			}
		}
    }
	
	public void Resume(){
		pauseMenuUI.SetActive(false);
		Time.timeScale=1f;
		Paused = false;
	}
	
	void Pause(){
		pauseMenuUI.SetActive(true);
		Time.timeScale=0f;
		Paused = true;
		
	}
	
	public void LoadScan()
	{
		Debug.Log("Loading scanner...");
	}
	
	public void QuitGame()
	{
		Debug.Log("Quitting...");
	}
	
	public void NewQuiz()
	{
		Debug.Log("Making new quiz...");
	}
	public void Options()
	{
		Debug.Log("Opening options...");
	}
}
