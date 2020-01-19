using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;


public class ShowAchievements : MonoBehaviour
{

	public GameObject[] _iconSlots;
	private int _achisUnlocked;
	private int _achiSlots;
	
    // Start is called before the first frame update
    void Start()
    {
		//_iconSlots = new GameObject[1];
      	//_iconSlots = GameObject.FindGameObjectsWithTag("AchiIcon");
		SetAchievements();
		_achiSlots = 15;
    }

    // Update is called once per frame
    void Update()
    {
		
    }
	
	void OnEnable()
	{
		SetAchievements();
	}
	
	public void GoBack()
	{
		SceneManager.LoadScene("Profile", LoadSceneMode.Single);
	}
	
	void SetAchievements()
	{
		int slot = 0;
		/*foreach (Achievement ac in UserManager.UM.GetUserInformation().Achievements) // promijeniti dohvat postojećih achija
		{
			if (slot<_achiSlots-1)
			{
				Sprite spr = Resources.Load<Sprite>(ac.id)
				_iconSlots[slot].GetComponent<SpriteRenderer>().sprite = spr;
				slot += 1;
			}
		}*/
		while (slot<15)
		{
			//try
			//{
				Sprite spr = Resources.Load<Sprite>("Avatar "+slot);
				_iconSlots[slot].GetComponent<Image>().sprite = spr;
				slot += 1;
			//} 
			
		}
	}
}
