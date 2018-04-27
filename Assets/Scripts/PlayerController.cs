using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public Slider speedSlider;

    public float speed = 1000;
    public Text countText;
    public Text girosInfo;

    public AudioClip soundPoint;
    public AudioClip soundWall;

    private Rigidbody player;
    private int count;

    List<float> accelDataX = new List<float>();
    List<float> accelDataY = new List<float>();
    List<float> accelDataZ = new List<float>();

    List<float> accelData2 = new List<float>();

    List<float> accelData3 = new List<float>();

    DateTime start;

    long RMSValue;

    float teste = 0;

    float offsetX, offsetY, offsetZ;

    float result = 0;
    float result2 = 0;
    float result3 = 0;

    private float secondsCount;
    private int minuteCount;
    private int hourCount;

    Gyroscope m_Gyro;

    void Start()
    {
        speedSlider.value = 1000;

        //Set up and enable the gyroscope (check your device has one)
        m_Gyro = Input.gyro;
        m_Gyro.enabled = true;

        player = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();

        start = DateTime.Now;

        offsetX = Input.acceleration.x;
        offsetY = Input.acceleration.y;
        offsetZ = Input.acceleration.z;

        //accelDataX.Add(-1.207089900970459f);
        //accelDataX.Add(7.04614782333374f);
        //accelDataX.Add(10.624306678771973f);
        //accelDataX.Add(5.475014686584473f);
        //accelDataX.Add(7.185059070587158f);
        //accelDataX.Add(3.3482375144958496f);
        //accelDataX.Add(6.083349704742432f);
        //accelDataX.Add(7.505991458892822f);
        //accelDataX.Add(0.5939648747444153f);
        //accelDataX.Add(0.910107433795929f);
        //accelDataX.Add(7.352710247039795f);
        //accelDataX.Add(6.787485599517822f);
        //accelDataX.Add(0.3688330352306366f);
        //accelDataX.Add(7.362290382385254f);
        //accelDataX.Add(7.371870517730713f);
        //accelDataX.Add(5.01038122177124f);
        //accelDataX.Add(7.5778422355651855f);
        //accelDataX.Add(3.3578174114227295f);
        //accelDataX.Add(4.694238662719727f);
        //accelDataX.Add(7.2281694412231445f);
        //accelDataX.Add(3.4871485233306885f);
        //accelDataX.Add(2.4381299018859863f);
        //accelDataX.Add(7.2281694412231445f);
        //accelDataX.Add(6.888076305389404f);
        //accelDataX.Add(5.680986404418945f);
        //accelDataX.Add(7.443720817565918f);
        //accelDataX.Add(2.615361452102661f);
        //accelDataX.Add(3.7985012531280518f);
        //accelDataX.Add(7.328760147094727f);
        //accelDataX.Add(2.7399024963378906f);
        //accelDataX.Add(-0.40236330032348633f);
        //accelDataX.Add(7.185059070587158f);
        //accelDataX.Add(10.691368103027344f);
        //accelDataX.Add(-0.6131250262260437f);
        //accelDataX.Add(7.132368564605713f);
        //accelDataX.Add(10.76321792602539f);
        //accelDataX.Add(7.343130111694336f);
        //accelDataX.Add(7.017407417297363f);
        //accelDataX.Add(1.2549903392791748f);
        //accelDataX.Add(5.891748428344727f);
        //accelDataX.Add(7.103628158569336f);
        //accelDataX.Add(2.016606569290161f);
        //accelDataX.Add(7.079678058624268f);
        //accelDataX.Add(7.592212200164795f);
        //accelDataX.Add(-1.686093807220459f);
        //accelDataX.Add(9.829160690307617f);
    }

    void Main()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    void FixedUpdate()
    {
        UpdateTimer();
        MovePlayer();
        UpdateInfo();
        debugInfo();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            Handheld.Vibrate();
        }
        if ( other.CompareTag("Cube"))
            GetComponent<AudioSource>().PlayOneShot(soundPoint);

        if (other.gameObject.CompareTag("Cube"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        if (other.gameObject.CompareTag("Trail"))
        {
            other.GetComponent<Renderer>().material.color = Color.green;
        }
        else if (other.gameObject.CompareTag("Ground"))
        {
            other.GetComponent<Renderer>().material.color = Color.red;
        }
    }
    void MovePlayer()
    {
        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            
            player.AddForce(movement * speed * Time.deltaTime);
        }
        else
        {
            Vector3 movement = new Vector3(Input.acceleration.x, 0.0f, Input.acceleration.y - offsetY);
            
            player.AddForce(movement * speed * Time.deltaTime);
        }
    }
    void UpdateInfo()
    {
        speed = speedSlider.value;

        accelDataX.Add(m_Gyro.rotationRate.x);
        accelDataY.Add(m_Gyro.rotationRate.y);
        accelDataZ.Add(m_Gyro.rotationRate.z);

        accelData2.Add(m_Gyro.rotationRate.sqrMagnitude);
        
        accelData3.Add(m_Gyro.userAcceleration.sqrMagnitude);

        if (Math.Abs(m_Gyro.rotationRate.x) + Math.Abs(m_Gyro.rotationRate.y) + Math.Abs(m_Gyro.rotationRate.z) > result)
            result = Math.Abs(m_Gyro.rotationRate.x) + Math.Abs(m_Gyro.rotationRate.y) + Math.Abs(m_Gyro.rotationRate.z);

        if (Math.Abs(m_Gyro.rotationRate.sqrMagnitude) > result2)
            result2 = Math.Abs(m_Gyro.rotationRate.sqrMagnitude);

        if (Math.Abs(m_Gyro.userAcceleration.sqrMagnitude) > result3)
            result3 = Math.Abs(m_Gyro.userAcceleration.sqrMagnitude);
    }
    private void debugInfo()
    {
        girosInfo.text = "rotation rate " + m_Gyro.rotationRate;
    }

    private double RMSCount(List<float> accelDataX, List<float> accelDataY, List<float> accelDataZ)
    {
        double accTotal = 0;

        for (int i = 0; i < accelDataX.Count; i++)
        {
            accTotal += accelDataX[i] + accelDataY[i] + accelDataZ[i];
        }

        return Math.Sqrt(Math.Abs(accTotal / accelDataX.Count));
    }

    private double RMSCount(List<float> accelData)
    {
        double accTotal = 0;

        for (int i = 0; i < accelData.Count; i++)
        {
            accTotal += accelData[i];
        }

        return Math.Sqrt(Math.Abs(accTotal / accelData.Count));
    }

    void SetCountText()
    {
        countText.text = "Count " + count.ToString();
        if (count >= 8)
        {
            PlayerPrefs.SetFloat("giros", result);
            PlayerPrefs.SetFloat("giros2", result2);
            PlayerPrefs.SetFloat("userAcce", result3);
            PlayerPrefs.SetFloat("rms", (float)RMSCount(accelDataX,accelDataY,accelDataZ));
            PlayerPrefs.SetFloat("rms2", (float)RMSCount(accelData2));
            PlayerPrefs.SetFloat("rms3", (float)RMSCount(accelData3));
            PlayerPrefs.SetString("time", minuteCount + "m:" + (int)secondsCount + "s");


            //StaticClass.CrossSceneInformation = finalResult;
            SceneManager.LoadScene("Result");

            //Debug.Log(RMSValue.ToString(), GameObject.Find("Player"));
        }
    }
    public void UpdateTimer()
    {
        secondsCount += Time.deltaTime;
        if (secondsCount >= 60)
        {
            minuteCount++;
            secondsCount = 0;
        }
        else if (minuteCount >= 60)
        {
            hourCount++;
            minuteCount = 0;
        }
    }
}