using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Team team;
    public Color teamColor;

    [SerializeField]
    public List<Transform> positions;

    private void Awake()
    {
        teamColor = team.color;
    }
}
