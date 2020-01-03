using UnityEngine;


public class AddLife : MonoBehaviour
{

    public GameObject Lifeadd;
    public static bool add = true;
    // Use this for initialization

    public void CreatBox2()
    {
        GameObject.Instantiate(original: Lifeadd, position: transform.position, rotation: Quaternion.identity);
        add = false;
    }

    void Awake()
    {
        add = true;
    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Bullet" && add == true)
        {
           
            CreatBox2();
        }

    }
}