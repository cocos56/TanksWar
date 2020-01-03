using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiHome : MonoBehaviour
{

    public GameObject Tank;
    // Use this for initialization

    public void CreatBox2()
    {
        GameObject.Instantiate(original: Tank, position: transform.position, rotation: Quaternion.identity);
    }

    void Update()
    {
        CreatBox2();
    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            //PlayAudio("Aced");
            gameObject.SetActive(false);
            Destroy(col.gameObject, 0.01f);
            CreatBox2();
        }

    }
}
