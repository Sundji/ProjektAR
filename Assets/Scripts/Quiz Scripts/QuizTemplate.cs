using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizTemplate : MonoBehaviour
{
	public GameObject Question;
	public GameObject[] Answers; 
	
	private Text _questionText;
	private static QuizTemplate _QT;
	
	#region QUIZ TEMPLATE PROPERTY
	
	public static QuizTemplate QT
	{
		get
		{
			if (_QT == null)
				_QT = FindObjectOfType<QuizTemplate>();
			return _QT;
		}
	}
	#endregion
	
    // Start is called before the first frame update
    void Start()
    {
        //_questionText.text = GameObject.Find("Question").GetComponentInChildren<Text>().text;
        SetQuestion(GameObject.Find("Question").GetComponentInChildren<Text>().text);
        Debug.Log(_questionText.text + "-> text");
    }

    // Update is called once per frame
    void Update()
    {
       
    }
	
	//jel se mogu kliknut ili ne
	public void IsEnabled(bool enabled)
	{
		foreach (GameObject ans in Answers)
		{
			Button butt = ans.GetComponent<Button>();
			butt.interactable = false;
		}
	}
	
	public void SetQuestion(string question)
	{
		_questionText.text = question; 
	}

    public void SetAnswers(GameObject[] Ans)
    {
        for(int i = 0; i < Ans.Length; i++)
        {
            Answers[i] = Ans[i];
        }
    }
}
