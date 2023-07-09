using UnityEngine;

public class FieldBounds : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ball"))
        {
            Team foulTeam = collision.GetComponent<Ball>().GetOwner();
            if(foulTeam != null)
            {
                Foul oob = new Foul(Foul.FoulType.BALLOOB, foulTeam);
                FoulManager.instance.FoulHappened(oob);
            }
            //else reset ball
        }
        else if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Team foulTeam = collision.GetComponent<TeamColor>().GetTeam();
            if(foulTeam != null)
            {
                Foul oob = new Foul(Foul.FoulType.PLAYEROOB, foulTeam);
                FoulManager.instance.FoulHappened(oob);
            }
        }
    }
}
