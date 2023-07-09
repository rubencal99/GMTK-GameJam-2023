using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_Player : MonoBehaviour
{
    public Team team;
    public Color teamColor;

    private void Awake()
    {
        teamColor = team.color;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "BallController")
        {
            print("Player goal!");
        }
    }
}
