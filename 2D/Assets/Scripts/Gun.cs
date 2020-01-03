using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    
    public GameObject Bullet;
    // Use this for initialization

    void Start()
    {
       
    }

    public void Fire()
    {
        GameObject.Instantiate(Bullet, transform.position, Quaternion.identity);
    }

 
}