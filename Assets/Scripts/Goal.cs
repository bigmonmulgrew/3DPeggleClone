using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] int score;

    [SerializeField] GameObject textUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            if(VictoryBlock.remainingBlocks <= 0)
            {
                Debug.Log("Victory");
                textUI.SetActive(true);
            }
        }
        Destroy(other.gameObject);
    }
}
