using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // needed to access the new UI classes and functions

public class AnswerButton : MonoBehaviour
{
	private AnswerData _ans;
	private Text _buttonText;
	private bool _isEnabled;
	
	//referenca gumba za odgovor
	public Button button;
	
    void Start()
    {
        _buttonText = GetComponentInChildren<Text>();
		_isEnabled = true;
    }

    // Update is called once per frame
    void Update()
    {
		
        
    }
	
	public void onClick()
	{
		QuizTemplate.QT.IsEnabled(false);
		_isEnabled = false;
		// provjera tocnosti - OVO (linije 29-32) ODKOMENTIRATI KADA SE POVEZE SA QM I MOZE DOBIT ANSWERDATA U SET() METODI
		/*if (_ans.isCorrect){
			//promijeni boju, prepraviti kada napravimo razred sa konstantama
			_buttonText.color = Color.red; // Constants.CorrectAnswerColor
		} else {
			_buttonText.color = Color.green;  // Constants.FalseAnswerColor
		}*/
	}
	
	void Set(AnswerData Ans, int order){ //order = a), b), c) ili d) - isto u global negdje skodirat Constants.AnswerOrder[4]
		_buttonText.color = Color.black; //Constants.DefaultAnswerColor
		if (!_isEnabled)
		{
			QuizTemplate.QT.IsEnabled(true);
			_isEnabled = true;
		}
		if (Ans != null)
		{	
			//postavlja novi odgovor
			_ans = Ans; 
			
			//odkomentirati poveže u QM od kojeg prima AnswerData preko metode Set()
			//_buttonText.text = "a)"+ _ans.AnswerText; //prepraviti u nesto poput : "Constants.AnswerOrder[order]"+ " " + Ans;
		} else
		{
			_buttonText.text = "";
		}
	}
}
