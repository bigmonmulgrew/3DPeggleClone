using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] float delay = 5.0f;
    [SerializeField] float points = 5.0f;
    protected virtual void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        StartCoroutine(DestroyBlock());
    }

    IEnumerator DestroyBlock()
    {
        yield return new WaitForSeconds(delay);
        Destroy(this.gameObject);
    }
}
