using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Range(0, 50.0f)]
    [SerializeField] float power = 100.0f;
    [SerializeField] int balls = 3;
    [SerializeField] GameObject ballPrefab;

    // Update is called once per frame
    void Update()
    {
        FireBall();
    }

    private void FireBall()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            Vector3 direction = Camera.main.transform.forward.normalized;

            Vector3 ballSpawn = transform.position;
            ballSpawn += direction.normalized;

            GameObject ball = Instantiate(ballPrefab, ballSpawn, Quaternion.identity);
            
            
            
            ball.GetComponent<Rigidbody>().AddForce(direction * power, ForceMode.Impulse);
        }
    }
}
