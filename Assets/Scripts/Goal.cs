using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] int score;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            if(VictoryBlock.remainingBlocks <= 0)
            {
                Debug.Log("Victory");
            }
        }
        Destroy(other.gameObject);
    }
}
