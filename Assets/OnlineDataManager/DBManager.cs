using UnityEngine;
using System.Net;
using System.IO;

public static class DBManager
{
    public static string username;
    public static string avatarname;
    public static string email;
    public static int experience;

    public static bool LoggedIn { get { return username != null; } }

    public static bool CheckInternetConnectivity { get { return Application.internetReachability != NetworkReachability.NotReachable; } }

    public static void LogOut()
    {
        username = null;
    }

    public static string GetHtmlFromUri(string resource)
    {
        {
            string html = string.Empty;
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(resource);
            using (HttpWebResponse resp = (HttpWebResponse)req.GetResponse())
            {
                bool isSuccess = (int)resp.StatusCode < 299 && (int)resp.StatusCode >= 200;
                if (isSuccess)
                {
                    using (StreamReader reader = new StreamReader(resp.GetResponseStream()))
                    {
                        html = reader.ReadToEnd();
                    }
                }
            }
            return html;
        }
    }

    public static bool CheckIfOnline()
    {
        string HtmlText = GetHtmlFromUri("http://www.google.com");
        return !(HtmlText == "");
    }

    public static void AddExperience(int experience)
    {
       DBManager.experience = DBManager.experience + experience;
    }

    public static int GetExperience()
    {
        return DBManager.experience;
    }

}
