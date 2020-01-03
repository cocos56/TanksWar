using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemydeath : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Boom;
    public GameObject can;
    //private float mtime;
    //private bool a=false;
    // Use this for initialization

    public void CreatBoom()
    {                         //代码不对
        GameObject newBoom = GameObject.Instantiate(Boom, transform.position,  Quaternion.identity);
        GameObject.Find("Gun").GetComponent<Test>().PlayAudio("boom");
        Destroy(newBoom,0.9f);
        //a = true;
        Debug.Log("创造了爆炸");
    }
    // Use this for initialization
    void Start()
    {
        //Enemy  类型是 Gameobject  不能再次。gameobject 会报错 自己定义的类型 
    }

    // Update is called once per frame
    void Update()
    {
        /*if (a == true)
        {
            mtime += Time.deltaTime;
        }*/
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            Debug.Log("敌方坦克碰到了子弹");
            CreatBoom();
            Destroy(this.gameObject,0.2f);
            Destroy(Enemy, 0.2f);
         
        }
    }
 
}


