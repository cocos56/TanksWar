using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class AnimationControllerTest : MonoBehaviour
{

    #region 缓存玩家的Animator组件
    public Animator anim = null;
    //private AudioSource audio;
    Rigidbody2D rigidbody2D;
    public GameObject player;
    //public GameObject Money;
    //public GameObject Cavans;
    public GameObject Maincamera;
    public GameObject Cavans;
    public int PlayerDirection = 4;//坦克面朝右
    public int SpeedX = 1;
    public float SpeedY = 0;
    public GameObject LeftGun;
    public GameObject RightGun;
    public GameObject UpGun;
    public GameObject DownGun;
    public GameObject LeftGun1;
    public GameObject RightGun1;
    public GameObject UpGun1;
    public GameObject DownGun1;
    public bool shoot = true;
    public int i = 0;

    public bool wait = false;
    private float mtime = 0;
    #endregion

    #region Start 缓存
    void Start()
    {
        anim = GetComponent<Animator>();
        //audio = GetComponent<AudioSource>();
        rigidbody2D = GetComponent<Rigidbody2D>();


        //LeftGun.GetComponent<Gun>().Fire();


    }
    #endregion

    #region Update 每帧控制
    void Update()
    {
        PlayerConroller();
        mtime += Time.deltaTime;
    }
    #endregion

    #region -PlayerConroller 具体玩家动画的方法 只实现动画不实现具体位移

    private void PlayerConroller()
    {
        //***********************坦克行走*****************************************//
        if (Input.GetKey(KeyCode.A))
        {
            PlayerDirection = 3;
            anim.SetTrigger("IsLeft");
            //this.transform.localScale = new Vector3(-1, 1, 1);//坦克向左走
            this.transform.Translate(Vector3.left * Time.deltaTime * 0.85f * SpeedX);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            PlayerDirection = 4;
            anim.SetTrigger("IsRight");
            //this.transform.localScale = new Vector3(1, 1, 1);//坦克 向右走
            this.transform.Translate(Vector3.right * Time.deltaTime * 0.85f * SpeedX);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            PlayerDirection = 1;
            anim.SetTrigger("IsUp");
            Vector2 temPosition = rigidbody2D.transform.position;
            rigidbody2D.transform.position = new Vector2(temPosition.x, temPosition.y + 0.02f + SpeedY);//坦克向上

        }
        else if (Input.GetKey(KeyCode.S))
        {
            PlayerDirection = 2;
            anim.SetTrigger("IsDown");
            Vector2 temPosition = rigidbody2D.transform.position;
            rigidbody2D.transform.position = new Vector2(temPosition.x, temPosition.y - 0.02f - SpeedY);//坦克向下
        }

        //*******************发射子弹*******************************************//
        //                              炮弹                                    //

        if (PlayerDirection == 3 && Input.GetKeyDown(KeyCode.K))
        {
            i++;
            if (i == 3)
            {
                LeftGun.GetComponent<Gun>().Fire();
                GameObject.Find("Gun1").GetComponent<Test>().PlayAudio("导弹");
                i = 0;
            }


        }
        else if (PlayerDirection == 4 && Input.GetKeyDown(KeyCode.K))
        {
            i++;
            if (i == 3)
            {
                RightGun.GetComponent<Gun>().Fire();
                GameObject.Find("Gun1").GetComponent<Test>().PlayAudio("导弹");
                i = 0;
            }

        }
        else if (PlayerDirection == 1 && Input.GetKeyDown(KeyCode.K))
        {
            i++;
            if (i == 3)
            {
                UpGun.GetComponent<Gun>().Fire();
                GameObject.Find("Gun1").GetComponent<Test>().PlayAudio("导弹");
                i = 0;

            }
        }
        else if (PlayerDirection == 2 && Input.GetKeyDown(KeyCode.K))
        {
            i++;
            if (i == 3)
            {
                DownGun.GetComponent<Gun>().Fire();
                Debug.Log("下导弹");
                GameObject.Find("Gun1").GetComponent<Test>().PlayAudio("导弹");
                i = 0;
            }

        }

        //****************子弹**************************************//

        if (PlayerDirection == 3 && Input.GetKeyDown(KeyCode.J))
        {
            LeftGun1.GetComponent<Gun>().Fire();

            GameObject.Find("Gun1").GetComponent<Test>().PlayAudio("开枪");

        }
        else if (PlayerDirection == 4 && Input.GetKeyDown(KeyCode.J))
        {
            RightGun1.GetComponent<Gun>().Fire();
            GameObject.Find("Gun1").GetComponent<Test>().PlayAudio("开枪");

        }
        else if (PlayerDirection == 1 && Input.GetKeyDown(KeyCode.J))
        {
            UpGun1.GetComponent<Gun>().Fire();
            GameObject.Find("Gun1").GetComponent<Test>().PlayAudio("开枪");

        }
        else if (PlayerDirection == 2 && Input.GetKeyDown(KeyCode.J))
        {
            DownGun1.GetComponent<Gun>().Fire();
            GameObject.Find("Gun1").GetComponent<Test>().PlayAudio("开枪");

        }
    }

    public void MoveRight()
        {
            PlayerDirection = 4;
            anim.SetTrigger("IsRight");
            //this.transform.localScale = new Vector3(1, 1, 1);//坦克 向右走
            this.transform.Translate(Vector3.right * Time.deltaTime * 0.85f * SpeedX);
        }
    public void MoveLeft()
    {

        PlayerDirection = 3;
        anim.SetTrigger("IsLeft");
        //this.transform.localScale = new Vector3(-1, 1, 1);//坦克向左走
        this.transform.Translate(Vector3.left * Time.deltaTime * 0.85f * SpeedX);
    }
    public void MoveUp()
    {
        PlayerDirection = 1;
        anim.SetTrigger("IsUp");
        Vector2 temPosition = rigidbody2D.transform.position;
        rigidbody2D.transform.position = new Vector2(temPosition.x, temPosition.y + 0.02f + SpeedY);//坦克向上

        
    }
    public void MoveDown()
    {

        PlayerDirection = 2;
        anim.SetTrigger("IsDown");
        Vector2 temPosition = rigidbody2D.transform.position;
        rigidbody2D.transform.position = new Vector2(temPosition.x, temPosition.y - 0.02f - SpeedY);//坦克向下

        
    }
    public void Attack1()
    {
        if (PlayerDirection == 3 )
        {
            i++;
            if (i == 3)
            {
                LeftGun.GetComponent<Gun>().Fire();
                GameObject.Find("Gun1").GetComponent<Test>().PlayAudio("导弹");
                i = 0;
            }


        }
        else if (PlayerDirection == 4 )
        {
            i++;
            if (i == 3)
            {
                RightGun.GetComponent<Gun>().Fire();
                GameObject.Find("Gun1").GetComponent<Test>().PlayAudio("导弹");
                i = 0;
            }

        }
        else if (PlayerDirection == 1 )
        {
            i++;
            if (i == 3)
            {
                UpGun.GetComponent<Gun>().Fire();
                GameObject.Find("Gun1").GetComponent<Test>().PlayAudio("导弹");
                i = 0;

            }
        }
        else if (PlayerDirection == 2 )
        {
            i++;
            if (i == 3)
            {
                DownGun.GetComponent<Gun>().Fire();
                Debug.Log("下导弹");
                GameObject.Find("Gun1").GetComponent<Test>().PlayAudio("导弹");
                i = 0;
            }

        }
    }
    public void Attack2()
    {
        if (PlayerDirection == 3 )
        {
            LeftGun1.GetComponent<Gun>().Fire();

            GameObject.Find("Gun1").GetComponent<Test>().PlayAudio("开枪");

        }
        else if (PlayerDirection == 4 )
        {
            RightGun1.GetComponent<Gun>().Fire();
            GameObject.Find("Gun1").GetComponent<Test>().PlayAudio("开枪");

        }
        else if (PlayerDirection == 1 )
        {
            UpGun1.GetComponent<Gun>().Fire();
            GameObject.Find("Gun1").GetComponent<Test>().PlayAudio("开枪");

        }
        else if (PlayerDirection == 2 )
        {
            DownGun1.GetComponent<Gun>().Fire();
            GameObject.Find("Gun1").GetComponent<Test>().PlayAudio("开枪");

        }

    }

        public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "EnemyBullet"|| other.tag == "Enemy")
        {
            print("主角碰到了子弹应该减少一个生命值");
            GameObject.Find("life").GetComponent<Life>().Minus();
            GameObject.Find("Canvas").GetComponent<Score>().Minus();

            transform.position = new Vector3(-7.91f, -3.61f, 0.1f);
            Maincamera.transform.position = new Vector3(-4.53f, -3f, -10f);

        }
        if (other.tag == "AddLife")
        {
            GameObject.Find("life").GetComponent<Life>().Plus();
            other.gameObject.SetActive(false);
            GameObject.Find("Gun1").GetComponent<Test>().PlayAudio("box");
            GameObject.Find("Canvas").GetComponent<Score>().Add5();
        }
        if (other.tag == "AddSpeed")
        {
            print("加速");
            other.gameObject.SetActive(false);
            GameObject.Find("Gun1").GetComponent<Test>().PlayAudio("box");
            GameObject.Find("Canvas").GetComponent<Score>().Add5();
            SpeedX = 2;
            SpeedY = 0.03f;
            Invoke("ResetSpeed", 5);
        }
    }
    private void Waittime()
    {
        wait = true;
    }
    private void ResetSpeed()
    {
        print("重置速度");
        SpeedX = 1;
        SpeedY = 0;
    }

    #endregion
    public void Move(Vector2 _ve)
    {
        if (Mathf.Abs(_ve.x) > Mathf.Abs(_ve.y))
        {
            if (_ve.x > 0)
            {
                MoveRight();
            }
            else
            {
                MoveLeft();
            }
        }
        else
        {
            if (_ve.y > 0)
            {
                MoveUp();
            }
            else
            {
                MoveDown();
            }
        }
    }

}