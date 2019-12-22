using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonOnClick : MonoBehaviour
{

    //public Button b;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void OnClick()
    {
        //Debug.Log("You have clicked button:" + GameObject.Find(this.name).GetComponentInChildren<Text>().text);
        //Debug.Log(GameObject.Find(this.name).GetComponentInParent<QuestionsGenerator>().answersCount);
        //Debug.Log(GameObject.Find("Question").GetComponentInChildren<Text>().text + "-> pitanje");
        //foreach(bool b in GameObject.Find(this.name).GetComponentInParent<QuestionsGenerator>().correctAns)
        //{
        //    Debug.Log(b);
        //}
        ////foreach(string ans in GameObject.Find(this.name).GetComponentInParent<QuestionsGenerator>().answers)
        //Debug.Log(GameObject.Find(this.name).GetComponentInParent<QuizTemplate>().Answers);
    }
}
