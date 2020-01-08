using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // needed to access the new UI classes and functions

public class AnswerButton : MonoBehaviour
{
    private AnswerData _ans;
    private Text _buttonText;
    private bool _isEnabled;
    public bool correct = false;
    private int _buttonNum;
    private string _buttonName;
    private string[] questions = { "Tko sam ja?", "Tko si ti?", "Tko je on?", "Tko je ona?" };


    //referenca gumba za odgovor
    public Button button;

    void Start()
    {

        button = this.GetComponent<Button>();
        _buttonName = GameObject.Find(this.name).GetComponentInParent<Button>().name;
        switch (_buttonName)
        {
            case "Button1":
                _buttonNum = 0;
                break;
            case "Button2":
                _buttonNum = 1;
                break;
            case "Button3":
                _buttonNum = 2;
                break;
            case "Button4":
                _buttonNum = 3;
                break;
        }
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
        //      _buttonText = GetComponentInChildren<Text>();
        //_isEnabled = true;
        //      AddButtons();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find(this.name).GetComponentInParent<QuestionsGenerator>().correctAns[_buttonNum] == true)
        {
            this.correct = true;
            ColorBlock colorblock = GameObject.Find(this.name).GetComponentInParent<Button>().colors;
            colorblock.pressedColor = Color.green;
            button.GetComponent<Button>().colors = colorblock;
        }
        else
        {
            this.correct = false;
            ColorBlock colorblock = button.GetComponent<Button>().colors;
            colorblock.pressedColor = Color.red;
            button.GetComponent<Button>().colors = colorblock;
        }


    }

    public void OnClick()
    {

        //bool[] polje = GameObject.Find(this.name).GetComponentInParent<QuestionsGenerator>().correctAns;
        //foreach(bool p in polje)
        //{
        //    Debug.Log(p);
        //}

        //QuizTemplate.QT.IsEnabled(false);
        _isEnabled = false;
        if (this.correct == true)
        {
            Debug.Log("Correct!");

        }
        else
        {
            Debug.Log("False");

        }
        //GetComponentInParent<QuestionsGenerator>().GenerateQuestions();
        button.GetComponentInParent<QuestionsGenerator>().GenerateQuestions();
        //    _buttonText.color = Color.green;
        //}
        //else
        //{
        //    _buttonText.color = Color.red;
        //}

        // provjera tocnosti - OVO (linije 29-32) ODKOMENTIRATI KADA SE POVEZE SA QM I MOZE DOBIT ANSWERDATA U SET() METODI
        /*if (_ans.isCorrect){
            //promijeni boju, prepraviti kada napravimo razred sa konstantama
            _buttonText.color = Color.red; // Constants.CorrectAnswerColor
        } else {
            _buttonText.color = Color.green;  // Constants.FalseAnswerColor
        }*/
    }

    public void Set(AnswerData Ans, int order)
    { //order = a), b), c) ili d) - isto u global negdje skodirat Constants.AnswerOrder[4]
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
        }
        else
        {
            _buttonText.text = "";
        }
    }
    void AddButtons()
    {
        AnswerButton b1 = gameObject.AddComponent<AnswerButton>();
        AnswerButton b2 = gameObject.AddComponent<AnswerButton>();
        AnswerButton b3 = gameObject.AddComponent<AnswerButton>();
        AnswerButton b4 = gameObject.AddComponent<AnswerButton>();
    }
}
