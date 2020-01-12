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
        //Mozda ne treba
        //if (selectedLecture == "Lekcija 1")
        //{
        //    questions = QuestionsAndAnswers.questions1;
        //}

        //else
        //{
        //    questions = QuestionsAndAnswers.questions2;
        //}
        //questions = ShuffleArray(questions);
        //for(int i=0; i< questions.Count; i++ ){
        //    Debug.Log("KEY: " + questions[i] + " VALUE: " + qAndA[questions[i]][0]);
        //}

        //for (int i = 0; i < 4; i++)
        //{
        //    Debug.Log(questions[i] + " ->key " + qAndA[questions[i]][0] + " ->value");
        //}

        cntr++;
        questionText.text = questions[cntr%4];
        for (int i = 0; i < qAndA[questions[cntr%4]].Count; i++)
        {
            if (qAndA[questions[cntr%4]][i].EndsWith("+"))
            {
                //qAndA[questions[cntr%4]][i] = qAndA[questions[cntr%4]][i].Substring(0, answers[cntr % 4][i].Length - 1);
                correctAns[i] = true;
            }
        }
        
        a1.text = "a) " + qAndA[questions[cntr % 4]][0].Substring(0, qAndA[questions[cntr % 4]][0].Length - 1);
        a2.text = "b) " + qAndA[questions[cntr % 4]][1].Substring(0, qAndA[questions[cntr % 4]][1].Length - 1);
        a3.text = "c) " + qAndA[questions[cntr % 4]][2].Substring(0, qAndA[questions[cntr % 4]][2].Length - 1);
        a4.text = "d) " + qAndA[questions[cntr % 4]][3].Substring(0, qAndA[questions[cntr % 4]][3].Length - 1);


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
    //public static IDictionary<string, string[]> ShuffleDict(IDictionary<string, string[]> dict, string[] questions)
    //{
    //    System.Random r = new System.Random();
    //    for (int i = dict.Count; i > 0; i--)
    //    {
    //        int j = r.Next(i);
    //        string k = questions[j];
    //        questions[j] = questions[i - 1];
    //        questions[i - 1] = k;
    //    }
    //    for(int i=0; i < questions.Length; i++)
    //    {
    //        Debug.Log(questions[i]);
    //        for(int j=0; j<4; j++)
    //        {
    //            Debug.Log(dict[questions[i]][j]);
    //        }
    //    }

    //    return dict;
    //}
    

    public static IDictionary<string, List<string>> CheckLecture(string lecture)
    {
        List<string> questions;
        List<List<string>> answers = new List<List<string>>();
        qAndA.Clear();
        if (lecture == "Lekcija 1")
        {
            questions = QuestionsAndAnswers.questions1;
            answers = QuestionsAndAnswers.answers1;
            //questions = ShuffleArray(questions);
            for (int i = 0; i < questions.Count; i++)
            {
                qAndA.Add(questions[i], answers[i]);
            }
        }
        else
        {
            questions = QuestionsAndAnswers.questions2;
            answers = QuestionsAndAnswers.answers2;
            for (int i = 0; i < QuestionsAndAnswers.questions2.Count; i++)
            {
                qAndA.Add(QuestionsAndAnswers.questions2[i], answers[i]);
            }
        }
        return (qAndA);
    }
}

