using UnityEngine;

public class FieldBounds : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ball"))
        {
            print("Ball out of bounds!");
        }
        else if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            print("Player out of bounds!");
        }
    }
}
