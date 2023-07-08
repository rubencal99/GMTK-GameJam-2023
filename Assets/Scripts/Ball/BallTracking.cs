using UnityEngine;

public class BallTracking : MonoBehaviour
{
    private Team teamOwner;

    public Team GetOwner()
    {
        return teamOwner;
    }

    public void SetOwner(Team team)
    {
        teamOwner = team;
    }
}
