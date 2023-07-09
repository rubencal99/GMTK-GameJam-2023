using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float time;
    public float Timer;

    public Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        time = Random.Range(15f, 25f);
        Timer = time;
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        if(Timer < 0 )
        {
            AnimateBird();
            Timer = Random.Range(15f, 25f);
        }
        if(transform.position.x < -3)
        {
            transform.localPosition = new Vector3(3, 0, 1);
            rigidbody.velocity = Vector2.zero;
        }
    }

    void AnimateBird()
    {
        rigidbody.velocity = new Vector2(-1, 0);
    }
}
