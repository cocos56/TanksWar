using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public GameObject player;
    public float speed;

    public float minPosx;
    public float maxPosx;
    public float minPosy;
    public float maxPosy;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        FixCameraPos();
    }

    void FixCameraPos()
    {
        float pPosX = player.transform.position.x;
        float cPosX = transform.position.x;
        float pPosY = player.transform.position.y;
        float cPosY = transform.position.y;
        if (pPosX - cPosX > 1)
        {
            transform.position = new Vector3(cPosX + speed, transform.position.y, transform.position.z);
        }
        if (pPosX - cPosX < -1)
        {
            transform.position = new Vector3(cPosX - speed, transform.position.y, transform.position.z);
        }
        if (pPosY - cPosY > 1)
        {
            transform.position = new Vector3(transform.position.x, cPosY + speed, transform.position.z);
        }
        if (pPosY - cPosY < -1)
        {
            transform.position = new Vector3(transform.position.x, cPosY - speed, transform.position.z);
        }
        float realPosX = Mathf.Clamp(transform.position.x, minPosx, maxPosx);
        float realPosY = Mathf.Clamp(transform.position.y, minPosy, maxPosy);
        transform.position = new Vector3(realPosX, realPosY, transform.position.z);
    }
}
