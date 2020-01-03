using UnityEngine;
using System.Collections;
using System;

public class GhostMove : MonoBehaviour
{
    public float speed = 0.4f;
    Vector2 dest = Vector2.zero;
    protected Vector3 m_curAngle;

    public float m_fMoveSpeed = 3.0f;
    public float m_fAngle;

    public GameObject m_gBullet;
    //for debug
    public string m_sName;

    public Vector3 m_initPosition;

    public GameObject m_BoomAnimation;
    public Transform[] waypoints;
    int cur = 0;

    //public float speed = 0.3f;

    void Start()
    {
        InvokeRepeating("doFire", 1, 1f);
        //InvokeRepeating("death", 1, 30);
        dest = transform.position;
        m_curAngle = Vector3.up;
    }
    protected virtual void death()
    {
        Destroy(this.gameObject, 30f);
    }
    void FixedUpdate()
    {
        // Waypoint not reached yet? then move closer
        if (transform.position != waypoints[cur].position)
        {
            Vector2 p = Vector2.MoveTowards(transform.position, waypoints[cur].position, speed);
            GetComponent<Rigidbody2D>().MovePosition(p);
        }
        // Waypoint reached, select next one
        else cur = (cur + 1) % waypoints.Length;
        // Animation
        Vector2 dir = waypoints[cur].position - transform.position;
        m_curAngle = dir.normalized;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);
    }


 
    bool valid(Vector2 dir)
    {
        // Cast Line from 'next to Pac-Man' to 'Pac-Man'
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        return (hit.collider == GetComponent<Collider2D>());
    }
    protected virtual void doFire()
    {
        GameObject bullet = Instantiate(m_gBullet) as GameObject;
        bullet.name= m_sName + "Bullet";
        Debug.Log("怎么了");
        bullet.GetComponent<CBullet>().m_vDirection = m_curAngle;
        bullet.GetComponent<CBullet>().m_fMoveSpeed = m_fMoveSpeed + 3.0f;
        bullet.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 0);
        Destroy(bullet, 1f);
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        print("pengdaoqiang");
        if (col.gameObject.tag == "Bullet")
        {
            GameObject.Find("Gun").GetComponent<Test>().PlayAudio("attack");
            GameObject.Find("Canvas").GetComponent<Score>().Add9();
            Destroy(col.gameObject );
            Debug.Log("触发销毁子弹");
        }
        if (col.name == "Player")

        {
            //Destroy(col.gameObject);
        }

    }
}


