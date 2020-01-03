using UnityEngine;
using System.Collections;

public class CBullet : MonoBehaviour
{

    public Vector3 m_vDirection;

    public float m_fMoveSpeed = 0.001f;

    void Start()
    {

    }

    void Update()
    {
        this.transform.position += m_vDirection * m_fMoveSpeed * Time.deltaTime;
        Destroy(gameObject,0.8f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("buttel OnTriggerEnter");
        //撞墙
        if (other.gameObject.name == "bg"|| other.gameObject.name == "Tong")
        {
            
            Destroy(gameObject );
        }
        if (other.gameObject.name == "Player")
        {
            //Destroy(other.gameObject);

        }
    }
}
