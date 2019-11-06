using System.Collections;
using System.Collections.Generic;

using UnityEditor;
using UnityEngine;

#if (UNITY_EDITOR)

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

#endif