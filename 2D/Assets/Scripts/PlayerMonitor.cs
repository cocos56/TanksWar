using UnityEngine;
using System.Collections;

public class PlayerMonitor : MonoBehaviour
{
    public void JoyStickControlMove(Vector2 direction)
    {
        this.transform.rotation = Quaternion.LookRotation(new Vector2(direction.x, direction.y));
    }
}
