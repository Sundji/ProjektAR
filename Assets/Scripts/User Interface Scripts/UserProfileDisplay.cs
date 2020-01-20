using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UserProfileDisplay : MonoBehaviour
{

    public Image AvatarImage;
    public Text UsernameText;
    public Text MailText;
    public Text ExperienceText;
    public Text LevelText;

    public GameObject SignOutButton;
    public GameObject GoToStartButton;

    private UserInformation _information;

    private void Start()
    {
        if (DBManager.LoggedIn)
        {

            SignOutButton.SetActive(true);
            GoToStartButton.SetActive(false);

            AvatarImage.sprite = Resources.Load<Sprite>(DBManager.avatarname);
            UsernameText.text = DBManager.username;
            MailText.text = DBManager.email;
            ExperienceText.text = (DBManager.GetExperience()).ToString();
            LevelText.text = (LevelController.DetermineLevel()).ToString();

        }

        else
        {

            SignOutButton.SetActive(false);
            GoToStartButton.SetActive(true);

            if (UserManager.UM)
                _information = UserManager.UM.GetUserInformation();

            if (_information == null)
                Destroy(gameObject);

            AvatarImage.sprite = Resources.Load<Sprite>(_information.Avatar);
            UsernameText.text = "Unavailable when not logged in";
            MailText.text = "Unavailable when not logged in";
            ExperienceText.text = "Unavailable when not logged in";
            LevelText.text = "Unavailable when not logged in";

        }

    }

    public void GoToStart()
    {
        SceneManager.LoadScene(0);
    }

    public void SignOut()
    {
        DBManager.LogOut();
        SceneManager.LoadScene(0);
    }

}
