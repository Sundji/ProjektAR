using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class UserInformation
{

    public string Username;
    public string Password;
    public string Mail;
    public string Avatar;

    public UserInformation(string username, string password, string mail, string avatar)
    {
        Username = username;
        Password = password;
        Mail = mail;
        Avatar = avatar;
    }


    // public int Score;

    // public Achievement[] Achievements;
    // public Lesson[] Lessons;
    // public Target[] ScannedTargets;

    // Achievement klasa bi sadržavala: naziv, opis (opcionalno, pr. ako se klikne da pokaže opis), sliku (opcionalno, ovisi hoćemo li na serveru spremati)
    // Lesson klasa bi sadržavala: naziv, status (završeno ili ne), najbolji rezultat na testu, broj slika koje nisu skenirane (da znamo pratiti status)
    // Target klasa bi sadržavala: naziv ili neku vrstu ID-a, status (skenirano ili ne)

}
