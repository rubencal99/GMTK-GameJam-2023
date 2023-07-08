using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float ballTimer;

    // Start is called before the first frame update
    void Start()
    {
        ballTimer = Random.Range(0.3f, 0.9f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
