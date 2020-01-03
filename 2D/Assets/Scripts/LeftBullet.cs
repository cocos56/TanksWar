using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftBullet : MonoBehaviour
{
    public float speed = 50;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(translation: Vector2.left * speed * Time.deltaTime);
        Destroy(this.gameObject, 0.5f);
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            //PlayAudio("Firstblood");
            Debug.Log("6561654654665");
            //GameObject.Find("Main Camera").GetComponent<Test>().PlayAudio("enemydeath");
            //查找  组件 （就是找到这个脚本） 然后调用 播放音效的代码就OK啦  勾傻瓜吧

            //this.gameObject.SetActive(false);
            // audio.Play();
        }
    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "bg")
        {
            Destroy(gameObject);
        }

    }
}
