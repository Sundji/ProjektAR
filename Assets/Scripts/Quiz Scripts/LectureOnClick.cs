using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LectureOnClick : MonoBehaviour
{
    public GameObject Panel;
    public static string lecture;
    public static string filepath;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void OnClick()
    {
        Panel.gameObject.SetActive(false);
        lecture = this.GetComponentInChildren<Text>().text;
        //filepath = Application.dataPath + "/QuizQuestions/" + lecture + ".txt";
        filepath = lecture;
        QuestionsGenerator.readString(filepath);
        QuestionsGenerator.qAndA = QuestionsGenerator.CheckLecture(lecture);
        //List<string> questions = QuestionsGenerator.questions;
        //QuestionsGenerator.questions = questions;
        //questions = QuestionsGenerator.ShuffleArray(questions);
        QuestionsGenerator.questions = QuestionsGenerator.ShuffleArray(QuestionsGenerator.questions);
        //foreach(string q in QuestionsGenerator.questions)
        //{
        //    Debug.Log(q);
        //}
        //foreach(string q in questions)
        //{
        //    Debug.Log(q + " -> q");
        //}
        GameObject.Find("Kviz").GetComponent<QuestionsGenerator>().GenerateQuestions();
        //QuestionsGenerator.CheckLecture(lecture);
    }
}
