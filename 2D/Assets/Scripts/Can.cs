using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Can : MonoBehaviour
{
    public Animator anim = null;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            print("peengdaole ");
            //PlayAudio("Aced");
            //gameObject.SetActive(false);
            GameObject.Find("Gun").GetComponent<Test>().PlayAudio("boom");
            GameObject.Find("Canvas").GetComponent<Score>().Add1();
            anim.enabled = true;
            Destroy(col.gameObject, 0.01f);
            Destroy(this.gameObject,0.95f);

        }

    }
}
    
