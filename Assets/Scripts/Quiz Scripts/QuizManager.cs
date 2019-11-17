using System.Collections;
using System.Collections.Generic;
using System.IO;

using UnityEngine;
using UnityEngine.UI; //Obrisati nakon sastanka 12.11.

public class QuizManager : MonoBehaviour
{

    private string _path;

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

    }

    //Obrisati cijelu metodu nakon sastanka 12.11.
    public void DisplayAndGenerate()
    {
        List<QuestionData> questions = GenerateQuiz("ProkariotskeStanice", 3);
        if (Display == null)
            return;
        string text = "";
        foreach (QuestionData question in questions)
        {
            text += question.QuestionText + "\n";
            for (int i = 0; i < question.Answers.Length; i++)
                text += ("- " + question.Answers[i].AnswerText + "\n");
        }
        Display.text = text;
    }

    // Obrisati kasnije.
    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {

            Debug.Log("Generating quiz...");
            List<QuestionData> questions = GenerateQuiz("ProkariotskeStanice", 3);

            string text = "";
            
            foreach (QuestionData question in questions)
            {
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

}
