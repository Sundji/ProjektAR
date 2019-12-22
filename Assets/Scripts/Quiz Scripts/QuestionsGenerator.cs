using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionsGenerator : MonoBehaviour
{

    public Text questionText;
    public Text a1, a2, a3, a4;
    int cntr = 0;
    public string[][] answers = new string[4][];
    public int answersCount;
    public bool[] correctAns = { false, false, false, false };
    public string[] currAnswers = new string[4];
    public string currQuestion;
    // Start is called before the first frame update
    public void Start()
    {
        cntr = 0;
        //Debug.Log("Pozvan start");
        IDictionary<string, string[]> qAndA = new Dictionary<string, string[]>();
        //Button button1 = gameObject.AddComponent(typeof(Button)) as Button;
        //AnswerButton ansBut = gameObject.AddComponent(typeof(AnswerButton)) as AnswerButton;
        
        Text[] answersText = {a1, a2, a3, a4};
        string[] alphabet = { "a)", "b)", "c)", "d)" };

        string[] questions = { "Tko sam ja?", "Tko si ti?", "Tko je on?", "Tko je ona?" };
        string[] ans1 = { "+Ja", "Ti", "On", "Ona" };
        string[] ans2 = { "Ja", "+Ti", "On", "Ona" };
        string[] ans3 = { "Ja", "Ti", "+On", "Ona" };
        string[] ans4 = { "Ja", "Ti", "On", "+Ona" };
        answers[0] = ans1;
        answers[1] = ans2;
        answers[2] = ans3;
        answers[3] = ans4;
        for (int i = 0; i < questions.Length; i++)
        {
            qAndA.Add(questions[i], answers[i]);
        }
        //qAndA.Add("Tko sam ja?", new string[] { "+Ja", "Ti", "On", "Ona" });
        //qAndA.Add("Tko si ti?", new string[] { "Ja", "+Ti", "On", "Ona" });
        //qAndA.Add("Tko je on?", new string[] { "Ja", "Ti", "+On", "Ona" });


        //Random uzimanje pitanja bez ponavljanja

        Random rand = new Random();

        int index = Random.Range(0, questions.Length);
        int ansIndex = Random.Range(0, questions.Length);
        do
        {
            index = Random.Range(0, questions.Length);
        } while (questions[index] == "");
        string randQuestion = questions[index];
        currQuestion = questions[index];
        currAnswers = answers[index];
        //Debug.Log(randQuestion);

        questionText.text = randQuestion;
        //for (int j = 0; j < qAndA[questions[index]].Length; j++)
        //{
        //    Console.Write("{0} {1} ", qAndA[questions[index]][ansIndex % qAndA[questions[index]].Length], ansIndex);

        //}
        answersCount = 4;

        do
        {
            do
            {
                ansIndex = Random.Range(0, questions.Length);
            } while (answers[index][ansIndex] == "");
            //Debug.Log(answers[index][ansIndex]);
            if (answers[index][ansIndex].StartsWith("+"))
            {
                answers[index][ansIndex] = answers[index][ansIndex].Substring(1);
                correctAns[cntr] = true;
            }
            answersText[cntr].text = alphabet[cntr] + " " + answers[index][ansIndex];
            cntr++;
            answers[index][ansIndex] = "";
            answersCount--;
        } while (answersCount > 0);

        for(int k = 0; k < correctAns.Length; k++)
        {
            if(correctAns[k] == true)
            {
                //Debug.Log(k);
            }
        }
        questions[index] = "";


        //Za provjeru koji je odgovor tocan
        //for (int i = 0; i < qAndA["Tko sam ja?"].Length; i++)
        //{
        //    if (qAndA["Tko sam ja?"][i].StartsWith("+"))
        //    {
        //        Console.WriteLine(qAndA["Tko sam ja?"][i].Remove(0, 1));
        //    }
        //}
    }
}

