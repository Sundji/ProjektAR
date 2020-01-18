using System.Collections;
using System.Collections.Generic;
using System.IO;

using UnityEngine;
using UnityEngine.Events;

public class UserManager : MonoBehaviour
{

    #region USER MANAGER PROPERTY

    private static UserManager _UM;

    public static UserManager UM
    {
        get
        {
            if (_UM == null)
                _UM = FindObjectOfType<UserManager>();
            return _UM;
        }
    }

    #endregion

    public static CustomEvent<UserInformation> AddUserEvent = new CustomEvent<UserInformation>();
    public static UnityEvent RemoveUserEvent = new UnityEvent();

    private string _userDataFileName = "user.json";
    private string _userDataFilePath;

    private string _lessonDataFileName = "lessons.json";
    private string _lessonDataFilePath;

    private UserInformation _userInformation;
    private Lessons _lessons;

    private void Awake()
    {

        #region USER MANAGER PROPERTY SET-UP

        if (_UM == null)
            _UM = this;

        if (_UM.Equals(this) == false)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        #endregion

        _userDataFilePath = Application.persistentDataPath + "/" + _userDataFileName;
        LoadUserInformation();

        _lessonDataFilePath = Application.persistentDataPath + "/" + _lessonDataFileName;
        LoadLessonData();

        AddUserEvent.AddListener(AddUser);
        RemoveUserEvent.AddListener(RemoveUser);

        ModelBehaviour.ModelVisibleEvent.AddListener(ModelVisibleEventHandler);

    }

    private void Start()
    {
        if (_userInformation != null)
            UserInterfaceManagerStartScene.UserExistsEvent.Invoke();
    }

    private void ModelVisibleEventHandler(string model, string lesson, string about)
    {

        if (_lessons == null)
            return;

        _lessons.AddModel(model, lesson);
        SaveLessonData();

    }

    private void AddUser(UserInformation information)
    {

        _userInformation = information;
        _lessons = new Lessons();

        SaveUserInformation();
        SaveLessonData();

    }

    public void RemoveUser()
    {

        _userInformation = null;
        _lessons = null;

        if (File.Exists(_userDataFilePath))
            File.Delete(_userDataFilePath);

        if (File.Exists(_lessonDataFilePath))
            File.Delete(_lessonDataFilePath);

    }

    private void LoadLessonData()
    {

        if (File.Exists(_lessonDataFilePath) == false)
            return;

        _lessons = JsonUtility.FromJson<Lessons>(File.ReadAllText(_lessonDataFilePath));

    }

    private void SaveLessonData()
    {
        File.WriteAllText(_lessonDataFilePath, JsonUtility.ToJson(_lessons));
    }

    #region METHODS FOR HANDLING USER INFORMATION

    private void LoadUserInformation()
    {

        if (File.Exists(_userDataFilePath) == false)
            return;

        _userInformation = JsonUtility.FromJson<UserInformation>(File.ReadAllText(_userDataFilePath));

    }

    private void SaveUserInformation()
    {
        File.WriteAllText(_userDataFilePath, JsonUtility.ToJson(_userInformation));
    }

    public UserInformation GetUserInformation()
    {
        return _userInformation;
    }

    #endregion

    public void AddToScore(int points)
    {
        _userInformation.Score += points;
        SaveUserInformation();
    }

}
