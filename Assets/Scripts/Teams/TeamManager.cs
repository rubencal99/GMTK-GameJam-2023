using System.Collections.Generic;
using UnityEngine;

public class TeamManager : MonoBehaviour
{
    public static TeamManager instance;
    public List<Team> teamsList;

    public Color inPossession = Color.red;

    private void Awake()
    {
        instance = this;
    }
}