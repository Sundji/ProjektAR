using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionsAndAnswers : MonoBehaviour
{
    public static string[] questions1 = { "Tko je otkrio penicilin?", "Tko je otkrio uzročnike zaraznih bolesti?", "Što znači grč. bakterion?", "Koju veličinu bakterijska stanica ne prelazi?" };
    public static string[] questions2 = { "Prije približno koliko milijardi godina su se razvili eukarioti?", "Kako se objašnjava postanak energetski značajnih organela kod eukariota?",
        "Kako su organeli kod eukariota nastali prema endosimbiontskoj teoriji?", "Koje veličine u prosjeku mogu biti eukarioti?" };
    static string[] ans11 = { "Alexander Fleming +", "Louis Pasteur", "Robert Koch", "Edward Jenner" };
    static string[] ans12 = { "Louis Pasteur", "Robert Koch +", "Thomas Milton Rivers", "Carlos Finlay" };
    static string[] ans13 = { "Štapić +", "Stanica", "Otrov", "Mikroorganizam" };
    static string[] ans14 = { "10 pikometara", "11 mikrometara +", "5 mikrometara", "600 pikometara" };
    static string[] ans21 = { "3,7", "2,7 +", "3,1", "4,6" };
    static string[] ans22 = { "Endosimbiontskom teorijom +", "Teorijom evolucije", "Abiogenezom", "Britten-Davidsonovim modelom" };
    static string[] ans23 = { "Razdvajanjem genetskog materijala eukariota", "Ulaskom virusa u pretke eukariotske stanice", "Genetskim mutacijama kroz generacije", "Ulaskom prokariota u pretke eukariotske stanice +" };
    static string[] ans24 = { "10 do 100 mikrometara +", "10 do 100 pikometara", "5 do 10 mikrometara", "5 do 10 pikometara" };
    public static string[][] answers1 = { ans11, ans12, ans13, ans14 };
    public static string[][] answers2 = { ans21, ans22, ans23, ans24 };
}
