using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Button test1;
    public Button test2;

    public InputField time;

    void Start()
    {
        Button btn1 = test1.GetComponent<Button>();
        Button btn2 = test2.GetComponent<Button>();
        btn1.onClick.AddListener(TaskOnClick1);
        btn2.onClick.AddListener(TaskOnClick2);
    }

    void TaskOnClick1()
    {
        SceneManager.LoadScene("Test");
    }

    void TaskOnClick2()
    {
        PlayerPrefs.SetFloat("timerTest2", float.Parse(time.text));
        SceneManager.LoadScene("Test2");
    }
}