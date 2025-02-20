using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryBlock : Block
{
    public static int remainingBlocks;

    bool destgroyed = false;

    private void Awake()
    {
        remainingBlocks++;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);

        if (destgroyed) return;
        remainingBlocks--;
        destgroyed = true;

    }

}
