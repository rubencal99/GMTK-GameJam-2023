using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldBoundsManager : MonoBehaviour
{
    public static FieldBoundsManager instance;

    public void OOBDetected(Team foulTeam)
    {
        if(!FoulManager.instance.recentFoul)
        {
            Foul oob = new Foul(Foul.FoulType.BALLOOB, foulTeam);
            FoulManager.instance.FoulHappened(oob);
        }
    }
}
