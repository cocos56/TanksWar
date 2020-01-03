using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    
    public GameObject Box2;
    // Use this for initialization

    public void CreatBox2()
    {
        GameObject.Instantiate(original: Box2, position: transform.position, rotation: Quaternion.identity);
    }

    void Update()
    {

    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            //PlayAudio("Aced");
            GameObject.Find("Gun").GetComponent<Test>().PlayAudio("box1");
            //Debug.Log("Bullet");
            gameObject.SetActive(false);
            Destroy(col.gameObject);
            CreatBox2();
        }

    }
}
