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
        GetComponentInParent<QuestionsGenerator>().GenerateQuestions();
        QuestionsGenerator.CheckLecture(lecture);
        //QuestionsGenerator.ShuffleArray(lecture);
    }
}
