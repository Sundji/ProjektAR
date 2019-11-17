using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class UserInterfaceManager : MonoBehaviour
{

    public GameObject AppInterface;
    public GameObject MenuInterface;

    private void Start()
    {
        ShowMenu();
    }

    public void HideMenu()
    {
        MenuInterface.SetActive(false);
        AppInterface.SetActive(true);
    }

    public void ShowMenu()
    {
        AppInterface.SetActive(false);
        MenuInterface.SetActive(true);
    }

}
