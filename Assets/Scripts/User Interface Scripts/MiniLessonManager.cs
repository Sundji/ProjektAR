using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class MiniLessonManager : MonoBehaviour
{

    public GameObject MiniLessonButton;
    public GameObject MiniLessonCanvas;
    public Text MiniLessonText;

    private bool _currentlyAvailable = true;
    private string _text;

    private void Awake()
    {
        MiniLessonButton.SetActive(false);
        MiniLessonCanvas.SetActive(false);
    }

    private void Start()
    {
        ModelBehaviour.ModelVisibleEvent.AddListener(ModelVisibleEventListener);
        ModelBehaviour.ModelInvisibleEvent.AddListener(ModelInvisibleEventListener);
    }

    private void ModelVisibleEventListener(string model, string lesson, string text)
    {
        if (_currentlyAvailable)
        {
            _currentlyAvailable = false;
            _text = text;
            MiniLessonButton.SetActive(true);
        }
    }

    private void ModelInvisibleEventListener()
    {
        _currentlyAvailable = true;
        _text = "";
        MiniLessonButton.SetActive(false);
    }

    public void Display()
    {
        MiniLessonButton.SetActive(false);
        MiniLessonCanvas.SetActive(true);
        MiniLessonText.text = _text;
    }

    public void Close()
    {

        if (_currentlyAvailable == false)
            MiniLessonButton.SetActive(true);
        else
            MiniLessonButton.SetActive(false);

        MiniLessonCanvas.SetActive(false);
        MiniLessonText.text = "";
        _text = "";

    }

}
