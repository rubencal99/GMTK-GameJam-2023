using UnityEngine;

public class RefereeContact : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ball"))
        {
            CrowdManager.instance.BallContact();
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            CrowdManager.instance.PlayerContact();
        }
    }
}
