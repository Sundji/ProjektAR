using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class QuestionsGenerator : MonoBehaviour
{

    public Text questionText;
    public Text a1, a2, a3, a4;
    int cntr = 0;
    public static string[][] answers = new string[4][];
    public int answersCount;
    public bool[] correctAns = { false, false, false, false };
    public string[] currAnswers = new string[4];
    public string currQuestion;
    public static string[] questions1 = { "Tko je otkrio penicilin?", "Tko je otkrio uzročnike zaraznih bolesti?", "Što znači grč. bakterion?", "Koju veličinu bakterijska stanica ne prelazi?" };
    public static string[] questions2 = { "Prije približno koliko milijardi godina su se razvili eukarioti?", "Kako se objašnjava postanak energetski značajnih organela kod eukariota?",
        "Kako su organeli kod eukariota nastali prema endosimbiontskoj teoriji?", "Koje veličine u prosjeku mogu biti eukarioti?" };
    string[] ans11 = { "Alexander Fleming +", "Louis Pasteur", "Robert Koch", "Edward Jenner" };
    string[] ans12 = { "Louis Pasteur", "Robert Koch +", "Thomas Milton Rivers", "Carlos Finlay" };
    string[] ans13 = { "Štapić +", "Stanica", "Otrov", "Mikroorganizam" };
    string[] ans14 = { "10 pikometara", "11 mikrometara +", "5 mikrometara", "600 pikometara" };
    string[] ans21 = { "3,7", "2,7 +", "3,1", "4,6" };
    string[] ans22 = { "Endosimbiontskom teorijom +", "Teorijom evolucije", "Abiogenezom", "Britten-Davidsonovim modelom" };
    string[] ans23 = { "Razdvajanjem genetskog materijala eukariota", "Ulaskom virusa u pretke eukariotske stanice", "Genetskim mutacijama kroz generacije", "Ulaskom prokariota u pretke eukariotske stanice +" };
    string[] ans24 = { "10 do 100 mikrometara +", "10 do 100 pikometara", "5 do 10 mikrometara", "5 do 10 pikometara" };
    public static IDictionary<string, string[]> qAndA = new Dictionary<string, string[]>();


    public void GenerateQuestions()
    {
        qAndA.Clear();
        string selectedLecture = LectureOnClick.lecture;
        for (int i = 0; i < correctAns.Length; i++)
        {
            correctAns[i] = false;
        }
        Text[] answersText = { a1, a2, a3, a4 };
        string[] alphabet = { "a)", "b)", "c)", "d)" };
        string[] questions = new string[4];
        if (selectedLecture == "Lekcija 1")
        {
            questions = questions1;
            answers[0] = ans11;
            answers[1] = ans12;
            answers[2] = ans13;
            answers[3] = ans14;
            for (int i = 0; i < questions.Length; i++)
            {
                qAndA.Add(questions[i], answers[i]);
            }
        }

        else
        {
            questions = questions2;
            answers[0] = ans21;
            answers[1] = ans22;
            answers[2] = ans23;
            answers[3] = ans24;
            for (int i = 0; i < questions.Length; i++)
            {
                qAndA.Add(questions[i], answers[i]);
            }
        }

        //for(int i = 0; i < 4; i++)
        //{
        //    Debug.Log(questions[i] + " ->key " + qAndA[questions[i]][0] + " ->value");
        //}

        cntr++;
        questionText.text = questions[cntr];
        for (int i = 0; i < answers[cntr].Length; i++)
        {
            if (answers[cntr][i].EndsWith("+"))
            {
                answers[cntr][i] = answers[cntr][i].Substring(0, answers[cntr][i].Length - 1);
                correctAns[i] = true;
            }
        }
        a1.text = "a) " + answers[cntr][0];
        a2.text = "b) " + answers[cntr][1];
        a3.text = "c) " + answers[cntr][2];
        a4.text = "d) " + answers[cntr][3];


        //qAndA.Add("Tko sam ja?", new string[] { "+Ja", "Ti", "On", "Ona" });
        //qAndA.Add("Tko si ti?", new string[] { "Ja", "+Ti", "On", "Ona" });
        //qAndA.Add("Tko je on?", new string[] { "Ja", "Ti", "+On", "Ona" });


        //Random uzimanje pitanja bez ponavljanja

        //Random rand = new Random();

        //int index = Random.Range(0, questions.Length);
        //int ansIndex = Random.Range(0, questions.Length);
        //do
        //{
        //    index = Random.Range(0, questions.Length);
        //} while (questions[index] == "");
        //string randQuestion = questions[index];
        //currQuestion = questions[index];
        //currAnswers = answers[index];
        ////Debug.Log(randQuestion);

        //questionText.text = randQuestion;
        ////for (int j = 0; j < qAndA[questions[index]].Length; j++)
        ////{
        ////    Console.Write("{0} {1} ", qAndA[questions[index]][ansIndex % qAndA[questions[index]].Length], ansIndex);

        ////}
        //answersCount = 4;

        //do
        //{
        //    do
        //    {
        //        ansIndex = Random.Range(0, questions.Length);
        //    } while (answers[index][ansIndex] == "");
        //    //Debug.Log(answers[index][ansIndex]);
        //    if (answers[index][ansIndex].EndsWith("+"))
        //    {
        //        answers[index][ansIndex] = answers[index][ansIndex].Substring(0, answers[index][ansIndex].Length-1);
        //        correctAns[cntr] = true;
        //    }
        //    answersText[cntr].text = alphabet[cntr] + " " + answers[index][ansIndex];
        //    cntr++;
        //    //answers[index][ansIndex] = "";
        //    answersCount--;
        //} while (answersCount > 0);

        //for(int k = 0; k < correctAns.Length; k++)
        //{
        //    if(correctAns[k] == true)
        //    {
        //        //Debug.Log(k);
        //    }
        //}
        //questions[index] = "";

    }
    //void Update()
    //{
    //    Debug.Log(LectureOnClick.lecture);
    //}
    public static string[] ShuffleArray(string[] array)
    {
        System.Random r = new System.Random();
        for (int i = array.Length; i > 0; i--)
        {
            int j = r.Next(i);
            string k = array[j];
            array[j] = array[i - 1];
            array[i - 1] = k;
        }
        return array;
    }

    public static IDictionary<string, string[]> CheckLecture(string lecture)
    {
        string[] questions;
        qAndA.Clear();
        if (lecture == "Lekcija 1")
        {
            questions = questions1;
            //questions = ShuffleArray(questions);
            for (int i = 0; i < questions1.Length; i++)
            {
                qAndA.Add(questions1[i], answers[i]);
            }
        }
        else
        {
            for (int i = 0; i < questions2.Length; i++)
            {
                qAndA.Add(questions2[i], answers[i]);
            }
        }
        return (qAndA);
    }

}

