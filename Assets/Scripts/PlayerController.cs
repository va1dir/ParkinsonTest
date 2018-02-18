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

    void Start()
    {
        player = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        infoText.text = "";
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
        infoText.text = "x " + Input.acceleration.x + "\nz " + Input.acceleration.z + "\ny " + Input.acceleration.y;
    }

    void SetCountText()
    {
        countText.text = "Count " + count.ToString();
        if (count >= 8)
            winText.text = "You win";
    }
}
