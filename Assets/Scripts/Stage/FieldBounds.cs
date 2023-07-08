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
                FoulTracker.instance.FoulHappened(oob);
            }
        }
        else if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Team foulTeam = collision.GetComponent<PlayerTeam>().GetTeam();
            if(foulTeam != null)
            {
                Foul oob = new Foul(Foul.FoulType.PLAYEROOB, foulTeam);
                FoulTracker.instance.FoulHappened(oob);
            }
        }
    }
}
