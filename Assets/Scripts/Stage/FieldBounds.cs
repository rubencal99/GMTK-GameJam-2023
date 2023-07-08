using UnityEngine;

public class FieldBounds : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ball"))
        {
            Foul oob = new Foul(Foul.FoulType.BALLOOB, 0);
            FoulTracker.instance.FoulHappened(oob);
        }
        else if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Foul oob = new Foul(Foul.FoulType.PLAYEROOB, 0);
            FoulTracker.instance.FoulHappened(oob);
        }
    }
}
