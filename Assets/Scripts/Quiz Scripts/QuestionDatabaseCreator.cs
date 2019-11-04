using System.Collections;
using System.Collections.Generic;
using System.IO;

using UnityEngine;

public class QuestionDatabaseCreator : MonoBehaviour
{

    public string DatabaseLessonName;
    public QuestionData[] DatabaseQuestions;

    private string _path;

    private void Awake()
    {
        _path = Application.dataPath + "/StreamingAssets/";
    }

    public void SaveQuestionDatabase()
    {

        if (DatabaseLessonName.Length == 0)
            return;

        QuestionDatabase database = new QuestionDatabase
        {
            LessonName = DatabaseLessonName,
            Questions = DatabaseQuestions
        };

        string json = JsonUtility.ToJson(database);
        File.WriteAllText(_path + DatabaseLessonName + ".json", json);
        
    }

}
