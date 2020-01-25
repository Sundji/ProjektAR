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
    public GameObject endgameScreen;
    public bool[] correctAns = { false, false, false, false };
    public string[] currAnswers = new string[4];
    public string currQuestion;
    public static List<string> questions;
    public static IDictionary<string, List<string>> qAndA = new Dictionary<string, List<string>>();
    List<Text> ansButtons = new List<Text>();
    public Text experience;
    public Text score;
    OnlineDataSave saveData = (new GameObject("save1")).AddComponent<OnlineDataSave>();


    private void Start()
    {
        GameObject.Find("Rezultati").SetActive(false);
    }
    public void GenerateQuestions()
    {
        if (cntr >= 10)
        {
            GameObject.Find("Kviz").SetActive(false);
            endgameScreen.SetActive(true);
            Debug.Log(AnswerButton.correctAns + " " + cntr + " " + ((float)AnswerButton.correctAns / (float)cntr));
            if ((float)AnswerButton.correctAns / (float)cntr == 1)
            {
                AnswerButton.earnedExp *= 2;
            }
            else if (((float)AnswerButton.correctAns / (float)cntr) >= 0.9)
            {
                AnswerButton.earnedExp = (int)(AnswerButton.earnedExp * 1.5);
            }
            else if ((float)AnswerButton.correctAns / (float)cntr >= 0.8)
            {
                AnswerButton.earnedExp = (int)(AnswerButton.earnedExp * 1.3);
            }
            else if ((float)AnswerButton.correctAns / (float)cntr >= 0.7)
            {
                AnswerButton.earnedExp = (int)(AnswerButton.earnedExp * 1.1);
            }

            string lecturename = LectureOnClick.lecture;
            string leaderboardID = "";

            if (lecturename.Equals("Lekcija 1"))
            {
                leaderboardID = "leaderboard1";
            }
            else if (lecturename.Equals("Lekcija 2"))
            {
                leaderboardID = "leaderboard2";
            }
            else if (lecturename.Equals("Lekcija 3"))
            {
                leaderboardID = "leaderboard3";
            }
            else if (lecturename.Equals("Lekcija 4"))
            {
                leaderboardID = "leaderboard4";
            }
            else
            {
                Debug.Log("No leaderboard for that lection");
            }

            if (DBManager.LoggedIn)
            {
                DBManager.AddExperience((int)AnswerButton.earnedExp);
                OnlineDataSave saveData = (new GameObject("save1")).AddComponent<OnlineDataSave>();
                saveData.CallSavePlayerData();
                saveData.UpdateLeaderboard(leaderboardID, (int)AnswerButton.correctAns);
                Destroy(saveData.gameObject);
                          
            }

            score.text = "Rezultat: " + AnswerButton.correctAns + "/" + cntr;
            experience.text = "Iskustvo: " + AnswerButton.earnedExp;

            
        }
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
            if(!qAndA.ContainsKey(questions[i]))
            {
                qAndA.Add(questions[i], answers[i]);
            }
            
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

