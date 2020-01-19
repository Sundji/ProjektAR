using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class OnlineDataSave : MonoBehaviour
{
    //saves user's experience to database
    public void CallSavePlayerData()
    {
        StartCoroutine(SavePlayerData());
    }

    IEnumerator SavePlayerData()
    {
        if (DBManager.LoggedIn & DBManager.CheckIfOnline())
        {
            WWWForm form = new WWWForm();
            form.AddField("name", DBManager.username);
            form.AddField("experience", DBManager.experience);

            UnityWebRequest www = UnityWebRequest.Post("https://arprojekt.herokuapp.com/savedata.php", form);
            yield return www.SendWebRequest();

            if (www.downloadHandler.text == "0")
            {
                Debug.Log("Game Saved.");
            }

            else
            {
                Debug.Log("Save failed. Error #" + www.downloadHandler.text);
            }

            //UnityEngine.SceneManagement.SceneManager.LoadScene(0);             -----------> open starting screen, or not
        }

        else
        {
            Debug.Log("Not logged in or no Internet connection, can't save data");
        }
    }

    public void CallSaveAvatarName()
    {
        StartCoroutine(SaveAvatarName());
    }

    IEnumerator SaveAvatarName()
    {
        if (DBManager.LoggedIn & DBManager.CheckIfOnline())
        {
            WWWForm form = new WWWForm();
            form.AddField("name", DBManager.username);
            form.AddField("avatarname", DBManager.avatarname);

            UnityWebRequest www = UnityWebRequest.Post("https://arprojekt.herokuapp.com/saveavatarname.php", form);
            yield return www.SendWebRequest();

            if (www.downloadHandler.text == "0")
            {
                Debug.Log("Avatarname saved.");
            }

            else
            {
                Debug.Log("Save failed. Error #" + www.downloadHandler.text);
            }
        }

        else
        {
            Debug.Log("Not logged in or no Internet connection, can't save avatar name");
        }
    }

    public void UpdateLeaderboard(string leaderboardID, int score)
    {
        //StartCoroutine(UpdateLeaderboard1(string leaderboardID, int score));
    }

    //available leaderboards by ID (i.e. valid IDs to use):
    //leaderboard1
    //leaderboard2
    //leaderboard3
    //leaderboard4
    IEnumerator UpdateLeaderboard1(string leaderboardID, int score)
    {
        if (DBManager.LoggedIn & DBManager.CheckIfOnline())
        {
           //sending score to a leaderboard
            WWWForm form = new WWWForm();
            form.AddField("name", DBManager.username);
            form.AddField("score", score);
            form.AddField("leaderboardID", leaderboardID);          //add identifier as second argument so backend can recognize what table to communicate with

            UnityWebRequest www2 = UnityWebRequest.Post("https://arprojekt.herokuapp.com/leaderboards.php", form);
            yield return www2.SendWebRequest();

            if (www2.downloadHandler.text == "0")
            {
                Debug.Log("Score added to leaderboard.");
            }

            else
            {
                Debug.Log("Adding score to leaderboard failed. Error #" + www2.downloadHandler.text);
            }
 
        }

        else
        {
            Debug.Log("Not logged in or no Internet connection, can't save data");
        }
    }
}
