using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
 
public class profileInformation : MonoBehaviour
{
	public bool Name;
	public bool Level;
	public bool DOB;
	public bool DOR;
	public bool image;
	
	private string _text;
    // Start is called before the first frame update
    void Start()
    {
		SetProfile();
		
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnEnable()
	{
		SetProfile();
	}
	
	private void SetProfile()
	{
		if (!image)
		{
			try
			{
				if (Name)
				{
		        	//_text = "ime";
				} else if (Level)
				{
					//_text = "35";
				}else if (DOB)
				{
					//DateTime dt = 
					//_text = dt.ToString("yyyy-MM-dd")
					//_text = DateTime.Now.ToString("hh:mm:ss");
				}else if (DOR)
				{
					//DateTime dt = 
					//_text = dt.ToString("yyyy-MM-dd")
					//_text = DateTime.Now.ToString("yyyy-MM-dd");
				}
				//izbrisat kasnije
				_text = "<none>";
				
			} catch (Exception e)
			{
				_text = "<none>";
			}
			GetComponent<Text>().text = _text;
		} else 
		{
			//GetComponent<Image>().sprite = 
		}
	}
}
