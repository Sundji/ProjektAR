using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[System.Serializable]

public class Lessons
{

    public Lesson[] LessonArray;

    public Lessons()
    {

        LessonArray = new Lesson[2];

        string[] modelsOne = { "ProkariotskaStanica"};
        string[] modelsTwo = { "ZivotinjskaStanica", "Jezgra", "EndoplazmatskiRetikulum", "GolgijevAparat", "Mitohondrij", "BiljnaStanica", "Kloroplast"};

        LessonArray[0] = new Lesson("ProkariotskeStanice", modelsOne);
        LessonArray[1] = new Lesson("EukariotskeStanice", modelsTwo);

    }

    public Lessons(Lesson[] lessonArray)
    {
        LessonArray = lessonArray;
    }

    private bool ContainsString(string[] array, string value)
    {

        for (int counter = 0; counter < array.Length; counter++)
            if (array[counter].Equals(value))
                return true;

        return false;

    }

    private int GetLessonIndex(string lesson)
    {

        for (int index = 0; index < LessonArray.Length; index++)
            if (LessonArray[index].Name.Equals(lesson))
                return index;

        return -1;

    }

    public void AddModel(string model, string lesson)
    {

        if (GetLessonIndex(lesson) == -1)
            return;

        int index = GetLessonIndex(lesson);
        string[] models = LessonArray[index].Models;
        string[] modelsViewed = LessonArray[index].ModelsViewed;

        if (ContainsString(models, model) == false || ContainsString(modelsViewed, model))
            return;

        if (modelsViewed.Length == 1 && modelsViewed[0].Length == 0)
            LessonArray[index].ModelsViewed[0] = model;

        else
        {

            string[] modelsViewedUpdated = new string[modelsViewed.Length + 1];

            for (int counter = 0; counter < modelsViewed.Length; counter++)
                modelsViewedUpdated[counter] = modelsViewed[counter];

            modelsViewedUpdated[modelsViewed.Length] = model;
            LessonArray[index].ModelsViewed = modelsViewedUpdated;

        }

        LessonArray[index].Started = true;

    }

}
