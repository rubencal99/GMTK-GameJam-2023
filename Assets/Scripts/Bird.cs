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
        time = Random.Range(20f, 30f);
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
            Timer = Random.Range(20f, 30f);
        }
    }

    void AnimateBird()
    {
        rigidbody.velocity = new Vector2(-1, 0);
    }
}
