using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

public class ModelBehaviour : MonoBehaviour
{

    public static CustomEvent<string, string, string> ModelVisibleEvent = new CustomEvent<string, string, string>();
    public static UnityEvent ModelInvisibleEvent = new UnityEvent();

    public string Model;
    public string Lesson;
    public string About;

    private void OnBecameVisible()
    {
        ModelVisibleEvent.Invoke(Model, Lesson, About);
        if (DBManager.LoggedIn)
        {
            DBManager.AddExperience(150);
            OnlineDataSave saveData = (new GameObject("save3")).AddComponent<OnlineDataSave>();
            saveData.CallSavePlayerData();
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        ModelInvisibleEvent.Invoke();
    }

}
