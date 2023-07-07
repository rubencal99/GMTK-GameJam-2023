using UnityEngine;

public class Goal_Ball : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Ball"))
        {
            print("Ball Goal!");
        }
    }
}
