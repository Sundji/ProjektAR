using System.Collections;
using System.Collections.Generic;

using UnityEngine;

// U aplikaciji ce postojati samo jedan UserManager koji ce pratiti podatke o korisniku.
// Kako bi se osiguralo da je samo jedan UserManager u aplikaciji, koristen je singleton
// pattern - napravljena je static varijabla _UM u kojoj ce se cuvati "pravi" UserManager
// objekt. U skripti se (Awake funkcija) prvo provjeri je li _UM postavljen na null - ako
// to vrijedi, ta instanca se postavlja kao _UM. Ako varijabla nije null i trenutna inst.
// nije jednaka pohranjenoj, onda se trenutna instanca brise kako bi se ocuvao samo jedan.

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

    public User User;

    private void Awake()
    {
        #region USER MANAGER PROPERTY SET-UP

        if (_UM == null)
            _UM = this;

        if (_UM.Equals(this) == false)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        #endregion
    }

}
