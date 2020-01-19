using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class QuestionsGenerator : MonoBehaviour
{

    public Text questionText;
    public Text a1, a2, a3, a4;
    int cntr = 0;
    public static List<List<string>> answers = new List<List<string>>();
    public int answersCount;
    public bool[] correctAns = { false, false, false, false };
    public string[] currAnswers = new string[4];
    public string currQuestion;
    //public static string[] questions1 = { "Tko je otkrio penicilin?", "Tko je otkrio uzročnike zaraznih bolesti?", "Što znači grč. bakterion?", "Koju veličinu bakterijska stanica ne prelazi?" };
    //public static string[] questions2 = { "Prije približno koliko milijardi godina su se razvili eukarioti?", "Kako se objašnjava postanak energetski značajnih organela kod eukariota?",
    //"Kako su organeli kod eukariota nastali prema endosimbiontskoj teoriji?", "Koje veličine u prosjeku mogu biti eukarioti?" };
    public static List<string> questions;
    //string[] ans11 = { "Alexander Fleming +", "Louis Pasteur", "Robert Koch", "Edward Jenner" };
    //string[] ans12 = { "Louis Pasteur", "Robert Koch +", "Thomas Milton Rivers", "Carlos Finlay" };
    //string[] ans13 = { "Štapić +", "Stanica", "Otrov", "Mikroorganizam" };
    //string[] ans14 = { "10 pikometara", "11 mikrometara +", "5 mikrometara", "600 pikometara" };
    //string[] ans21 = { "3,7", "2,7 +", "3,1", "4,6" };
    //string[] ans22 = { "Endosimbiontskom teorijom +", "Teorijom evolucije", "Abiogenezom", "Britten-Davidsonovim modelom" };
    //string[] ans23 = { "Razdvajanjem genetskog materijala eukariota", "Ulaskom virusa u pretke eukariotske stanice", "Genetskim mutacijama kroz generacije", "Ulaskom prokariota u pretke eukariotske stanice +" };
    //string[] ans24 = { "10 do 100 mikrometara +", "10 do 100 pikometara", "5 do 10 mikrometara", "5 do 10 pikometara" };
    public static IDictionary<string, List<string>> qAndA = new Dictionary<string, List<string>>();
    List<Text> ansButtons = new List<Text>();


    public void GenerateQuestions()
    {
        //foreach (string q in questions)
        //{
        //    Debug.Log(q + " -> q");
        //}
        //List<string> questions = new List<string>();
        string selectedLecture = LectureOnClick.lecture;
        for (int i = 0; i < correctAns.Length; i++)
        {
            correctAns[i] = false;
        }
        Text[] answersText = { a1, a2, a3, a4 };
        string[] alphabet = { "a)", "b)", "c)", "d)" };
        ansButtons.Add(a1);
        ansButtons.Add(a2);
        ansButtons.Add(a3);
        ansButtons.Add(a4);
        //Debug.Log(qAndA[questions[cntr % questions.Count]].Count);
        //foreach (string q in qAndA.Keys)
        //{
        //    Debug.Log(q);
        //}
        for (int i = 0; i < 4; i++)
        {
            ansButtons[i].text = "";
        }

        //Debug.Log(questions[cntr] + " " + qAndA[questions[cntr]][0]);
        for (int i = 0; i < qAndA[questions[cntr % questions.Count]].Count; i++)
        {
            if (qAndA[questions[cntr % questions.Count]][i].EndsWith("+"))
            {
                correctAns[i] = true;
                qAndA[questions[cntr % questions.Count]][i] = qAndA[questions[cntr % questions.Count]][i].Substring(0, qAndA[questions[cntr % questions.Count]][i].Length - 1);
            }
            ansButtons[i].text = alphabet[i] + " " + qAndA[questions[cntr % questions.Count]][i];
            //Debug.Log(ansButtons[i].text);
            //for(int j = 0; j < qAndA[questions[cntr % questions.Count]][i].Length; j++)
            //{
            //    Debug.Log(qAndA[questions[cntr % questions.Count]][i][j] + "________");
            //}
        }
        questionText.text = questions[cntr % questions.Count];
        for (int i = 0; i < 4; i++)
        {
            if (ansButtons[i].text.Length == 0)
            {
                ansButtons[i].text = "";
            }
        }

        a1.text = ansButtons[0].text;
        a2.text = ansButtons[1].text;
        a3.text = ansButtons[2].text;
        a4.text = ansButtons[3].text;
        ansButtons.Clear();
        cntr++;

        //a1.text = "a) " + qAndA[questions[cntr % questions.Count]][0].Substring(0, qAndA[questions[cntr % questions.Count]][0].Length - 1);
        //a2.text = "b) " + qAndA[questions[cntr % questions.Count]][1].Substring(0, qAndA[questions[cntr % questions.Count]][1].Length - 1);
        //a3.text = "c) " + qAndA[questions[cntr % questions.Count]][2].Substring(0, qAndA[questions[cntr % questions.Count]][2].Length - 1);
        //a4.text = "d) " + qAndA[questions[cntr % questions.Count]][3].Substring(0, qAndA[questions[cntr % questions.Count]][3].Length - 1);

    }

    public static void readString(string filePath)
    {
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            (List<string>, List<List<string>>) parserReturn = questionsParser(lines);
            questions = parserReturn.Item1;
            answers = parserReturn.Item2;
            //for (int i = 0; i < questions.Count; i++)
            //{
            //    Debug.Log(questions[i] + "  " + answers[i][0]);
            //}
        }
    }

    public static (List<string>, List<List<string>>) questionsParser(string[] textLines)
    {
        List<List<string>> answers = new List<List<string>>();
        List<string> questions = new List<string>();
        List<string> ansIter = new List<string>();

        bool ans = false;
        int ansIndex = 0;
        for (int i = 0; i < textLines.Length; i++)
        {
            if (textLines[i].EndsWith(" PITANJE"))
            {
                ans = true;
                questions.Add(textLines[i].Substring(textLines[i].IndexOf(".") + 1, textLines[i].Length - textLines[i].IndexOf(".") - 8));
                answers.Add(new List<string>());
            }
            else if (ans == true & textLines[i].Length > 0)
            {
                //Debug.Log("A " + ansIndex + " " + textLines[i]);
                answers[ansIndex].Add(textLines[i]);
                //ansIter.Add(textLines[i]);
            }
            else if (textLines[i].Length == 0)
            {
                if (ans == true)
                {
                    ansIndex++;
                    ansIter.Clear();
                    //for (int k = 0; k < ansIter.Count; k++)
                    //{
                    //    Debug.Log(ansIter[k] + "-> ITER");
                    //}
                    //for (int k = 0; k < answers[0].Count; k++)
                    //{
                    //    Debug.Log(answers[0] + "-> ITER");
                    //}
                }
                ans = false;
            }
        }
        return (questions, answers);
    }

    public static List<string> ShuffleArray(List<string> array)
    {
        System.Random r = new System.Random();
        for (int i = array.Count; i > 0; i--)
        {
            int j = r.Next(i);
            string k = array[j];
            array[j] = array[i - 1];
            array[i - 1] = k;
        }
        return array;
    }

    public static IDictionary<string, List<string>> CheckLecture(string lecture)
    {
        //for (int i = 0; i < answers.Count; i++)
        //{
        //    Debug.Log(questions[i]);
        //    for (int j = 0; j < answers[i].Count; j++)
        //    {
        //        Debug.Log(answers[i][j]);
        //    }
        //}
        qAndA.Clear();
        for (int i = 0; i < questions.Count; i++)
        {
            qAndA.Add(questions[i], answers[i]);
        }

        //if (lecture == "Lekcija 1")
        //{
        //    questions = QuestionsAndAnswers.questions1;
        //    answers = QuestionsAndAnswers.answers1;
        //    //questions = ShuffleArray(questions);
        //    for (int i = 0; i < questions.Count; i++)
        //    {
        //        qAndA.Add(questions[i], answers[i]);
        //    }
        //}
        //else
        //{
        //    questions = QuestionsAndAnswers.questions2;
        //    answers = QuestionsAndAnswers.answers2;
        //    for (int i = 0; i < QuestionsAndAnswers.questions2.Count; i++)
        //    {
        //        qAndA.Add(QuestionsAndAnswers.questions2[i], answers[i]);
        //    }
        //}
        return (qAndA);
    }
}

