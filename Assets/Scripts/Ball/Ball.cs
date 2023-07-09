using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public bool inPossession;
    public BallController possesser;
    public float ballStaminaAttacker;
    public float ballStaminaDefender;
    public bool attemptingCapture;
    public Team teamOwner;

    float ballTimer = 15f;
    float ballTime = 15f;

    // Start is called before the first frame update
    void Start()
    {
        inPossession = false;
        ballStaminaAttacker = Random.Range(0.3f, 0.9f);
        ballStaminaDefender = Random.Range(0.3f, 0.9f);
    }

    // Update is called once per frame
    void Update()
    {
        if(!inPossession)
        {
            ballTimer -= Time.deltaTime;
            if(ballTimer < 0)
            {
                ResetBall();
                ballTimer = ballTime;
            }
        }
        EnsureCapture();
    }

    void ResetBall()
    {
        transform.position = Vector2.zero;
    }

    public bool AttemptCapture()
    {
        //attemptingCapture = true;
        if (!inPossession)
            return true;

        ballTimer = ballTime;
        ballStaminaAttacker = Random.Range(0.3f, 0.9f);
        ballStaminaDefender = Random.Range(0.3f, 0.9f);

        ballTimer = ballTime;

        return ballStaminaAttacker < ballStaminaDefender;
    }

    public void EnsureCapture()
    {
        if(transform.parent != null)
        {
            transform.parent.GetComponent<BallController>().Ball = this;
            teamOwner = transform.parent.parent.GetComponent<Player>().team;
        }
    }

    public Team GetOwner()
    {
        return teamOwner;
    }

    public void SetOwner(Team team)
    {
        teamOwner = team;
    }
}
