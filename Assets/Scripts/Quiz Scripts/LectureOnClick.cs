using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LectureOnClick : MonoBehaviour
{
    public GameObject Panel;
    public static string lecture;
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
        QuestionsGenerator.qAndA = QuestionsGenerator.CheckLecture(lecture);
        List<string> questions = new List<string> (QuestionsGenerator.qAndA.Keys);
        QuestionsGenerator.questions = questions;
        questions = QuestionsGenerator.ShuffleArray(questions);
        //foreach(string q in questions)
        //{
        //    Debug.Log(q + " -> q");
        //}
        GameObject.Find("Kviz").GetComponent<QuestionsGenerator>().GenerateQuestions();
        QuestionsGenerator.CheckLecture(lecture);
    }
}
