using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    
    public float speed = 1000;
    public Text countText;
    public Text winText;
    public Text infoText;

    private Rigidbody player;
    private int count;

    List<float> accelDataX = new List<float>();
    List<float> accelDataY = new List<float>();
    List<float> accelDataZ = new List<float>();
    
    DateTime start;

    long RMSValue;

    float teste = 0;

    void Start()
    {
        player = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        infoText.text = "";

        start = DateTime.Now;

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
        MovePlayer();
        UpdateInfo();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cube"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
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
            Vector3 movement = new Vector3(Input.acceleration.x, 0.0f, Input.acceleration.y);
            
            player.AddForce(movement * speed * Time.deltaTime);
        }
    }

    void UpdateInfo()
    {
        //if (DateTime.Now.Second < start.Second + 20 && DateTime.Now.Millisecond % 5 == 0)
        //{ 
            accelDataX.Add(Input.acceleration.x * 100);
            accelDataY.Add(Input.acceleration.y * 100);
            accelDataZ.Add(Input.acceleration.z * 100);

            teste = Input.acceleration.x + Input.acceleration.y + Input.acceleration.z;

            Debug.Log(accelDataX[accelDataX.Count-1].ToString(), GameObject.Find("Player"));
        //}

        infoText.text = "teste " + teste;
    }

    void RMSCount()
    {
        double accTotal = 0;

        /*foreach (double accValue in accelDataX)
        {
            accTotal += accValue;
        }
        foreach (double accValue in accelDataY)
        {
            accTotal += accValue;
        }
        foreach (double accValue in accelDataY)
        {
            accTotal += accValue;
        }*/

        for (int i = 0; i < 1000; i++)
        {
            accTotal += accelDataX[i] + accelDataY[i] + accelDataZ[i];
        }

        Debug.Log(accTotal.ToString(), GameObject.Find("Player"));

        RMSValue = (long) Math.Sqrt(Math.Abs(accTotal / accelDataX.Count));
    }

    void SetCountText()
    {
        countText.text = "Count " + count.ToString();
        if (count >= 8)
        {
            RMSCount();
            winText.text =  RMSValue.ToString();

            //Debug.Log(RMSValue.ToString(), GameObject.Find("Player"));
        }
    }
}
