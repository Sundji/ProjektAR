using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class QuestionsAndAnswers : MonoBehaviour
{
    public static List<string> questions1 = new List<string>{ "Tko je otkrio penicilin?", "Tko je otkrio uzročnike zaraznih bolesti?", "Što znači grč. bakterion?", "Koju veličinu bakterijska stanica ne prelazi?" };
    public static List<string> questions2 = new List<string>{ "Prije približno koliko milijardi godina su se razvili eukarioti?", "Kako se objašnjava postanak energetski značajnih organela kod eukariota?",
        "Kako su organeli kod eukariota nastali prema endosimbiontskoj teoriji?", "Koje veličine u prosjeku mogu biti eukarioti?" };
    static List<string> ans11 = new List<string> { "Alexander Fleming +", "Louis Pasteur ", "Robert Koch ", "Edward Jenner " };
    static List<string> ans12 = new List<string> { "Louis Pasteur ", "Robert Koch +", "Thomas Milton Rivers ", "Carlos Finlay " };
    static List<string> ans13 = new List<string> { "Štapić +", "Stanica ", "Otrov ", "Mikroorganizam " };
    static List<string> ans14 = new List<string> { "10 pikometara ", "11 mikrometara +", "5 mikrometara ", "600 pikometara " };
    static List<string> ans21 = new List<string> { "3,7 ", "2,7 +", "3,1 ", "4,6 " };
    static List<string> ans22 = new List<string> { "Endosimbiontskom teorijom +", "Teorijom evolucije ", "Abiogenezom ", "Britten-Davidsonovim modelom " };
    static List<string> ans23 = new List<string> { "Razdvajanjem genetskog materijala eukariota ", "Ulaskom virusa u pretke eukariotske stanice ", "Genetskim mutacijama kroz generacije ", "Ulaskom prokariota u pretke eukariotske stanice +" };
    static List<string> ans24 = new List<string> { "10 do 100 mikrometara +", "10 do 100 pikometara ", "5 do 10 mikrometara ", "5 do 10 pikometara " };
    public static List<List<string>> answers1 = new List<List<string>> { ans11, ans12, ans13, ans14 };
    public static List<List<string>> answers2 = new List<List<string>> { ans21, ans22, ans23, ans24 };
    public static string quizFile1 = @"C:\Users\Simun\Desktop\Projekt iz PP\ProjektAR\Lekcija 1.txt";
    public static string quizFile2 = @"C:\Users\Simun\Desktop\Projekt iz PP\ProjektAR\Lekcija 2.txt";
    public static string quizFile3 = @"C:\Users\Simun\Desktop\Projekt iz PP\ProjektAR\Lekcija 3.txt";
    public static string quizFile4 = @"C:\Users\Simun\Desktop\Projekt iz PP\ProjektAR\Lekcija 4.txt";
}
