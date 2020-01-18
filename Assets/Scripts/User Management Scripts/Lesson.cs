using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[System.Serializable]

public class Lesson
{

    public string Name;
    public string[] Models;
    public string[] ModelsViewed = {""};
    public bool Started = false;

    public Lesson(string name, string[] models)
    {
        Name = name;
        Models = models;
    }

    public Lesson(string name, string[] models, string[] modelsViewed)
    {
        Name = name;
        Models = models;
        ModelsViewed = modelsViewed;
        Started = true;
    }

}
