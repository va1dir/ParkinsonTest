using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{

    public AudioClip sound;

    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = sound;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<AudioSource>().Play();
        Debug.Log("Birl");
    }
}
