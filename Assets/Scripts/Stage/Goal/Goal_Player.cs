using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_Player : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "BallController")
        {
            print("Player goal!");
        }
    }
}
