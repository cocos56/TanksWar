using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metal : MonoBehaviour
{
    private AudioSource audio;

    // Use this for initialization
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnCollisionEnter2D(Collision2D col)
    {   //if(collider .col="Ground")
        if (col.gameObject.tag == "Bullet")
        {
            PlayAudio("metal");
            Destroy(col.gameObject);
        }
    }
    void PlayAudio(string name)
    {
        AudioClip tempClip = Resources.Load<AudioClip>("Audios/" + name);
        audio.PlayOneShot(tempClip, 1);
    }
}
