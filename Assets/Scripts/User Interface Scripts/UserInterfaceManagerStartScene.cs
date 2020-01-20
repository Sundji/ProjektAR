using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;

public class UserInterfaceManagerStartScene : MonoBehaviour
{

    public static UnityEvent UserExistsEvent = new UnityEvent();

    public float WelcomeCanvasDisplayTime;
    public GameObject WelcomeCanvas;
    public GameObject SignInCanvas;
    public GameObject SignUpCanvas;

    [Header("Effect Information")]

    public float EffectAppearTime;
    public float EffectDuration;
    public GameObject Effect;

    [Header("Sign In Canvas Elements")]

    public InputField SignInUsernameField;
    public InputField SignInPasswordField;

    [Header("Sign Up Canvas Elements")]

    public AvatarManager SignUpAvatar;
    public InputField SignUpUsernameField;
    public InputField SignUpPasswordField;
    public InputField SignUpMailField;

    private bool _skip;
    private float _timer;

    private Animator _effectAnimator;
    private bool _effectAppear;
    private bool _effectStarted;
    private float _effectTimer;

    private void Awake()
    {

        Time.timeScale = 1;

        WelcomeCanvas.SetActive(true);
        SignInCanvas.SetActive(false);
        SignUpCanvas.SetActive(false);

        _effectAnimator = Effect.GetComponent<Animator>();
        _timer = WelcomeCanvasDisplayTime;

        UserExistsEvent.AddListener(SetSkipToMainScene);

    }

    private void Update()
    {

        #region TIMER FOR WELCOME CANVAS

        if (_timer > 0)
        {

            _timer -= Time.deltaTime;

            if (_timer <= 0)
            {
                if (_skip)
                    SkipToMainScene();
                else
                    ChangeToSignIn();
            }

        }

        #endregion

        #region TIMER FOR EFFECT

        if (_skip)
            return;

        _effectTimer += Time.deltaTime;

        if (_effectTimer >= EffectAppearTime && _effectStarted == false)
        {
            _effectAnimator.SetBool("appear", true);
            _effectAppear = true;
            _effectStarted = true;
        }

        if (_effectTimer >= EffectAppearTime + 0.5f && _effectAppear == true && _effectStarted == true)
        {
            _effectAnimator.SetBool("appear", false);
            _effectAppear = false;
        }

        if (_effectTimer >= EffectDuration && _effectStarted == true)
        {
            Effect.SetActive(false);
            _effectStarted = false;
        }

        #endregion

    }

    private void SetSkipToMainScene()
    {
        _skip = true;
    }

    private void SkipToMainScene()
    {
        SceneManager.LoadScene(1);
    }

    public void ChangeToSignIn()
    {
        WelcomeCanvas.SetActive(false);
        SignInCanvas.SetActive(true);
        SignUpCanvas.SetActive(false);
    }

    public void ChangeToSignUp()
    {
        WelcomeCanvas.SetActive(false);
        SignInCanvas.SetActive(false);
        SignUpCanvas.SetActive(true);
    }

    public void Exit()
    {
        DBManager.LogOut();
        Application.Quit();
    }

    public void SignIn()
    {
        StartCoroutine(LoginPlayer());
    }

    IEnumerator LoginPlayer()
    {
        if (DBManager.CheckIfOnline())
        {
            WWWForm form = new WWWForm();
            form.AddField("name", SignInUsernameField.text);
            form.AddField("password", SignInPasswordField.text);
            
            UnityWebRequest www = UnityWebRequest.Post("http://161.53.19.203/arprojekt/login.php", form);
            yield return www.SendWebRequest();

            if (www.downloadHandler.text[0] == '0')
            {
                DBManager.username = SignInUsernameField.text;
                DBManager.experience = int.Parse(www.downloadHandler.text.Split('\t')[1]);
                DBManager.avatarname = www.downloadHandler.text.Split('\t')[2];
                DBManager.email = www.downloadHandler.text.Split('\t')[3];
                SkipToMainScene();   //changing scene upon successful login
                Debug.Log("User logged in - Username: " + DBManager.username + " Avatarname: " + DBManager.avatarname + " Experience: " + DBManager.experience + " E-mail: " + DBManager.email);
            }

            else
            {
                Debug.Log("User login failed. Error #" + www.downloadHandler.text);
            }
        }

        else
        {
            Debug.Log("Not connected to Internet");
        }

    }

    public void SignUp()
    {

        string username = SignUpUsernameField.text;
        string password = SignUpPasswordField.text;

        if (username.Length == 0)
            return;

        if (password.Length == 0)
            return;

        string mail = SignUpMailField.text;
        string[] mailLocalPart = mail.Split('@');
        string[] mailDomain = mailLocalPart[1].Split('.');

        if (mailLocalPart.Length != 2 || mailLocalPart[0].Length == 0)
            return;

        if (mailDomain.Length != 2 || mailDomain[0].Length == 0 || mailDomain[1].Length == 0)
            return;

        UserInformation information = new UserInformation(username, password, mail, SignUpAvatar.GetAvatarName()); 
        UserManager.AddUserEvent.Invoke(information);

        StartCoroutine(Register());
        
        SkipToMainScene();

    }

    IEnumerator Register()
    {
        if (DBManager.CheckIfOnline())
        {
            WWWForm form = new WWWForm();
            form.AddField("name", SignUpUsernameField.text);
            form.AddField("password", SignUpPasswordField.text);
            form.AddField("email", SignUpMailField.text);
            form.AddField("avatarname", SignUpAvatar.GetAvatarName());

            UnityWebRequest www = UnityWebRequest.Post("http://161.53.19.203/arprojekt/register.php", form);
            yield return www.SendWebRequest();

            if (www.downloadHandler.text == "0")
            {
                Debug.Log("User created successfully");
                SkipToMainScene();   // changing scene upon successful registration
            }

            else
            {
                Debug.Log("User creation failed. Error #" + www.downloadHandler.text);
            }
        }

        else
        {
            Debug.Log("Not connected to Internet.");
        }
    }

}
