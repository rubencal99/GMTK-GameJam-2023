using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AgentAnimations : MonoBehaviour
{
    protected Animator agentAnimator;
    protected SpriteRenderer sprite;

    protected void Awake()
    {
        agentAnimator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    public void AnimatePlayer(Vector2 direction)
    {
        SetRunAnimation(direction);
    }

    public void SetIdleAnimation()
    {
        agentAnimator.SetTrigger("Idle");
    }

    private void SetRunAnimation(Vector2 direction)
    {
        if(direction.x < 0)
            sprite.flipX = true;
        else if(direction.x > 0)
            sprite.flipX = false;

        agentAnimator.SetBool("Run", direction != Vector2.zero);
    }

    public void SetKickAnimation() 
    {
        agentAnimator.SetTrigger("Kick");
    }

    public void EnableSprite()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void DisableSprite()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

}
