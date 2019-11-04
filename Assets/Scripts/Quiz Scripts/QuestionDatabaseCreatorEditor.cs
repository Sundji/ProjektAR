using System.Collections;
using System.Collections.Generic;

using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(QuestionDatabaseCreator))]

public class QuestionDatabaseCreatorEditor : Editor
{

    public override void OnInspectorGUI()
    {

        DrawDefaultInspector();

        if (GUILayout.Button("Save"))
            ((QuestionDatabaseCreator)target).SaveQuestionDatabase();

    }

}
