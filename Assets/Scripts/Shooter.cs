using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("Ball Settings")]
    [Range(0, 50.0f)]
    [SerializeField] float power = 100.0f;
    [SerializeField] int balls = 3;
    [SerializeField] GameObject ballPrefab;

    [Header("Indicator Settings")]
    [SerializeField] GameObject indicatorPrefab;
    [Range(0,5.0f)]
    [SerializeField] float indicatorInterval = 0.3f;
    [Range(0, 5.0f)]
    [SerializeField] float indicatorDisplay = 2.0f;

    private void Start()
    {
        StartCoroutine(FireIndicator());
    }

    // Update is called once per frame
    void Update()
    {
        FireBall();
    }

    private void FireBall()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(GameObject.FindGameObjectWithTag("Ball")) return;

            FireSphere(ballPrefab);

        }
    }

    IEnumerator FireIndicator()
    {
        while (true)
        {
            // Wait first before checking again
            yield return new WaitForSeconds(indicatorInterval);

            if (GameObject.FindGameObjectWithTag("Ball")) continue;

            GameObject sphere = FireSphere(indicatorPrefab);

            Destroy(sphere, indicatorDisplay); 
        }
    }

    private GameObject FireSphere(GameObject spherePrefab)
    {
        // Get the camera's forward direction
        Vector3 direction = Camera.main.transform.forward.normalized;

        // Adjust sphere spawn position slightly in front of the shooter
        Vector3 sphereSpawn = transform.position + direction;

        // Instantiate the indicator prefab at the calculated position
        GameObject sphere = Instantiate(spherePrefab, sphereSpawn, Quaternion.identity);

        // Apply force to the sphere
        sphere.GetComponent<Rigidbody>().AddForce(direction * power, ForceMode.Impulse);

        return sphere;
    }
}
