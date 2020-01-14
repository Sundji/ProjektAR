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

    private UserInformation _userInformation;

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

        AddUserEvent.AddListener(AddUser);
        RemoveUserEvent.AddListener(RemoveUser);

    }

    private void Start()
    {
        if (_userInformation != null)
            UserInterfaceManagerStartScene.UserExistsEvent.Invoke();
    }

    private void AddUser(UserInformation information)
    {
        _userInformation = information;
        SaveUserInformation();
    }

    public void RemoveUser()
    {

        _userInformation = null;

        if (File.Exists(_userDataFilePath))
            File.Delete(_userDataFilePath);

    }

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

}
