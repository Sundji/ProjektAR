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
        Debug.Log("Model " + Model + " visible...");
    }

    private void OnBecameInvisible()
    {
        ModelInvisibleEvent.Invoke();
        Debug.Log("Model " + Model + " invisible...");
    }

}
