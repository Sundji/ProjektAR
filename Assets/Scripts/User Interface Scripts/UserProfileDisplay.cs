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

    private UserInformation _information;

    private void Start()
    {
        if (DBManager.LoggedIn)
        {
            AvatarImage.sprite = Resources.Load<Sprite>(DBManager.avatarname);
            UsernameText.text = DBManager.username;
            MailText.text = DBManager.email;
            //ovdje dodati experience, dohvatit s DBManager.experience
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
        }

    }

    public void SignOut()
    {
        UserManager.UM.RemoveUser();
        SceneManager.LoadScene(0);
    }

}
