using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Result2Controller : MonoBehaviour {

    public Text result;

    public Button playAgainButton;

    // Use this for initialization
    void Start () {
        result.text = PlayerPrefs.GetInt("resultTest2").ToString();

        Button btn = playAgainButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void TaskOnClick()
    {
        SceneManager.LoadScene("Menu");
    }
}
