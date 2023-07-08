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
        
    }

    public bool AttemptCapture()
    {
        //attemptingCapture = true;
        if (!inPossession)
            return true;

        ballStaminaAttacker = Random.Range(0.3f, 0.9f);
        ballStaminaDefender = Random.Range(0.3f, 0.9f);

        return ballStaminaAttacker < ballStaminaDefender;
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
