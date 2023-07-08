using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Team team;
    public Color teamColor;

    private void Awake()
    {
        teamColor = team.color;
    }
}
