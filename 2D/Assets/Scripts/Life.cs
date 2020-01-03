using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class Life : MonoBehaviour
{
    public int Lifevalue = 1;

    void Start()
    {

    }


    void Update()
    {
        GameObject.Find("Canvas/life").GetComponent<Text>().text = " " + Lifevalue;
        if (Lifevalue <= 0)
        {
            SceneManager.LoadScene("Defeat");
        }
    }
    public void Minus()
    {
        Lifevalue = Lifevalue - 1;

    }
    public void Plus()
    {
        Lifevalue = Lifevalue + 1;

    }

}
