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

    private UserInformation _information;

    private void Start()
    {
        if (DBManager.LoggedIn)
        {
            AvatarImage.sprite = Resources.Load<Sprite>(DBManager.avatarname);
            UsernameText.text = DBManager.username;
            MailText.text = DBManager.email;
            ExperienceText.text = (DBManager.experience).ToString();
            LevelText.text = (LevelController.DetermineLevel()).ToString();

        }

        else
        {
            if (UserManager.UM)
                _information = UserManager.UM.GetUserInformation();

            if (_information == null)
                Destroy(gameObject);

            AvatarImage.sprite = Resources.Load<Sprite>(_information.Avatar);
            UsernameText.text = _information.Username;
            MailText.text = _information.Mail;
            ExperienceText.text = "Unavailable when not logged in";
            LevelText.text = "Unavailable when not logged in";
        }

    }

    public void SignOut()
    {
        UserManager.UM.RemoveUser();
        SceneManager.LoadScene(0);
    }

}
