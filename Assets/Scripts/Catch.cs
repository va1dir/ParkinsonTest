using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Catch : MonoBehaviour {

    public Button yourButton;

    private float secondsCount = 0;

    private int quantity = 0;

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
    void Update()
    {
        if (secondsCount <= PlayerPrefs.GetFloat("timerTest2"))
            secondsCount += Time.deltaTime;
        else
        {
            PlayerPrefs.SetInt("resultTest2",quantity);
            SceneManager.LoadScene("Result2");
        }
    }

    void TaskOnClick()
    {
        quantity++;
        yourButton.transform.position = new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), 0);
    }
}
