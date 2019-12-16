using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LectureButton : MonoBehaviour
{	
	//naziv lekcije za kviz
	public string LectureName;
    // Start is called before the first frame update
	
	void Start() {
	}
    public void StartQuiz(){
		//pozovi funkciju iz QM
		QuizManager.QM.TurnOffLectureButtons(LectureName);
	}
}
