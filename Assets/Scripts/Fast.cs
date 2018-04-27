using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fast : MonoBehaviour {

    public Button yourButton;

    private float secondsCount = 0;

    private int quantity = 0;

    // Use this for initialization
    void Start () {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
	
	// Update is called once per frame
	void Update () {
        if (secondsCount <= PlayerPrefs.GetFloat("timerTest3"))
            secondsCount += Time.deltaTime;
        else
        {
            PlayerPrefs.SetInt("resultTest3", quantity);
            SceneManager.LoadScene("Result3");
        }
    }

    void TaskOnClick()
    {
        quantity++;
    }
}
