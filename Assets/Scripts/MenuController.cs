using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Button test1;
    public Button test2;
    public Button test3;

    public InputField time1;
    public InputField time2;

    void Start()
    {
        Button btn1 = test1.GetComponent<Button>();
        Button btn2 = test2.GetComponent<Button>();
        Button btn3 = test3.GetComponent<Button>();
        btn1.onClick.AddListener(TaskOnClick1);
        btn2.onClick.AddListener(TaskOnClick2);
        btn3.onClick.AddListener(TaskOnClick3);
    }

    void TaskOnClick1()
    {
        SceneManager.LoadScene("Test");
    }

    void TaskOnClick2()
    {
        PlayerPrefs.SetFloat("timerTest2", float.Parse(time1.text));
        SceneManager.LoadScene("Test2");
    }

    void TaskOnClick3()
    {
        PlayerPrefs.SetFloat("timerTest3", float.Parse(time2.text));
        SceneManager.LoadScene("Test3");
    }
}