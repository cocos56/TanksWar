using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyblood1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            //Debug.Log("血条碰到了子弹");
            Destroy(other.gameObject);
            Debug.Log("销毁子弹");
            gameObject.SetActive(false);
            

        }
    }
}
