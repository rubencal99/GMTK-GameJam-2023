using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float time;
    public float Timer;
    public GameObject bird_jumpscare;

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
        if(Timer < 10 && Timer > 9)
        {
            AnimateBird();
        }
        if(Timer < 4)
        {
            bird_jumpscare.SetActive(true);
        }
        if(Timer < 0)
        {
            Timer = Random.Range(25f, 30f);
            bird_jumpscare.SetActive(false);
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
