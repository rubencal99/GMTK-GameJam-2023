using System.Collections.Generic;
using UnityEngine;

public class TeamManager : MonoBehaviour
{
    public static TeamManager instance;
    public List<Team> teamsList;

    private void Awake()
    {
        instance = this;
    }
}