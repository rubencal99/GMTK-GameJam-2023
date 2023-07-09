using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToPostAction : AIAction
{
    [SerializeField]
    float randomBias;
    float Timer = 0;
    float time = 7f;
    private void Update()
    {
        Timer -= Time.deltaTime;
    }
    void ResetTimer()
    {
        Timer = time;
    }
    public override void TakeAction()
    {
        if(Timer < 0)
        {
            Vector2 position;
            if(TeamManager.instance.inPossession == agentBrain.player.teamColor)
            {
                position = (Vector2)agentBrain.player.attackingPosition.position;
            }
            else
            {
                position = (Vector2)agentBrain.player.defendingPosition.position;
            }
            aiMovementData.PointOfInterest = position +
                                       new Vector2(Random.Range(-randomBias, randomBias), Random.Range(-randomBias, randomBias));
            ResetTimer();
        }
       
    }

    void OnDrawGizmos()
    {
        if (!Application.isPlaying)
            return;

        Gizmos.color = Color.magenta;
        Gizmos.DrawSphere(aiMovementData.PointOfInterest, 0.5f);
    }
}
