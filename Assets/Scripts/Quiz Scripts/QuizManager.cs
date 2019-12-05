using System.Collections;
using System.Collections.Generic;
using System.IO;

using UnityEngine;
using UnityEngine.UI; //Obrisati nakon sastanka 12.11.

public class QuizManager : MonoBehaviour
{
	private static QuizManager _QM;
	
	#region QUIZ MANAGER PROPERTY
	
	public static QuizManager QM
	{
		get
		{
			if (_QM ==null)
				_QM = FindObjectOfType<QuizManager>();
			return _QM;
		}
	}
	
	#endregion
	
    private string _path;
	private int numOfQuestions = 1;
	// referenca na izbornik kviza
	public GameObject LectureButtons;

    // Obrisati nakon sastanka 12.11.
    public Text Display;

    private void Awake()
    {

        #if UNITY_ANDROID
        _path = "jar:file://" + Application.dataPath + "!/assets";
        #endif

        #if UNITY_EDITOR
        _path = Application.streamingAssetsPath;
        #endif
		
		#region QUIZ MANAGER PROPERTY SET-UP
		
		if (_QM == null)
			_QM = this;
			
		if (_QM != this)
			Destroy(gameObject);
			
		DontDestroyOnLoad(gameObject); //nije nužno, ovisi želimo li zadržati isti QuizManager kroz scene
		
		#endregion

    }

    //Obrisati cijelu metodu nakon sastanka 12.11.
    public void DisplayAndGenerate()
    {
		//stvara listu od 3 pitanja	i ponudenih odgovora
        List<QuestionData> questions = GenerateQuiz("ProkariotskeStanice", numOfQuestions);
        if (Display == null)
            return;
        string text = "";
        foreach (QuestionData question in questions)
        {
			//za svako pitanje nadi odgovore i zalijepi u string text
            text += question.QuestionText + "\n";
            for (int i = 0; i < question.Answers.Length; i++)
                text += ("- " + question.Answers[i].AnswerText + "\n");
        }
		// prikazi sve
        Display.text = text;
    }

    // Obrisati kasnije.
    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {

            Debug.Log("Generating quiz...");
			//opet stvara listu pitanja
            List<QuestionData> questions = GenerateQuiz("ProkariotskeStanice", numOfQuestions);

            string text = "";
            
            foreach (QuestionData question in questions)
            {
				//opet traži odgovore
                text = "";
                text += question.QuestionText + "\n";
                for (int i = 0; i < question.Answers.Length; i++)
                    text += ((i + 1).ToString() + ". " + question.Answers[i].AnswerText + "\n");
                Debug.Log(text);
            }

        }

    }

    private QuestionDatabase GetQuestions(string lesson)
    {

        if (File.Exists(_path + "/" + lesson + ".json") == false)
            return null;

        string text = File.ReadAllText(_path + "/" + lesson + ".json");
        QuestionDatabase database = JsonUtility.FromJson<QuestionDatabase>(text);

        return database;

    }

    public List<QuestionData> GenerateQuiz(string lesson, int size)
    {
		
        QuestionDatabase database = GetQuestions(lesson);
        HashSet<int> indexes = new HashSet<int>();
        Vector2Int range = new Vector2Int(0, database.Questions.Length);

        List<QuestionData> questions = new List<QuestionData>();

        while (indexes.Count < size)
            indexes.Add(Random.Range(range.x, range.y));

        foreach (int index in indexes)
            questions.Add(database.Questions[index]);

        return questions;

    }
	
	//ugasi canvas sa gumbicima za izbor lekcije
	public void TurnOffLectureButtons(string lecture){
		LectureButtons.SetActive(false);
		
	}
		//upali canvas sa gumbicima za izbor lekcije
	public void TurnOnLectureButtons(string lecture){
		LectureButtons.SetActive(true);
		
	}

}
