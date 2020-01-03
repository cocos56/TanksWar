using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Box2 : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            //PlayAudio("Aced");
            GameObject.Find("Gun").GetComponent<Test>().PlayAudio("box");
            GameObject.Find("Canvas").GetComponent<Score>().Add5();
            gameObject.SetActive(false);
            Destroy(col.gameObject, 0.01f);
            
        }

    }
}
