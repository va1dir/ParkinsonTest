using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultController : MonoBehaviour {

    public Text giros;
    public Text giros2;
    public Text userAcce;
    public Text rms;
    public Text rms2;
    public Text rms3;
    public Text time;

    public Button playAgainButton;

    // Use this for initialization
    void Start () {
        giros.text = PlayerPrefs.GetFloat("giros").ToString();
        giros2.text = PlayerPrefs.GetFloat("giros2").ToString();
        userAcce.text = PlayerPrefs.GetFloat("userAcce").ToString();
        rms.text = PlayerPrefs.GetFloat("rms").ToString();
        rms2.text = PlayerPrefs.GetFloat("rms2").ToString();
        rms3.text = PlayerPrefs.GetFloat("rms3").ToString();
        time.text = PlayerPrefs.GetString("time").ToString();

        Button btn = playAgainButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        SceneManager.LoadScene("Menu");
    }
}
