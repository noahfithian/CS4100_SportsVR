using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable : MonoBehaviour
{

    public ParticleSystem explosionParticle;
    public int pointValue;
    private GameManager gameManager;
    private float xRange = 4;
    private float ySpawnPos = 3;
    private float zRange = -8;
    private bool isOnGround = false;
    private float timeOnGround = 5f;
    private float groundTimer;

    // Start is called before the first frame update
    void Start()
    {
        // targetRb = GetComponent<Rigidbody>();
        transform.position = RandomSpawnPos();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    // Update is called once per frame
    void Update()
    {
         if (isOnGround)
        {
            groundTimer += Time.deltaTime;
            if (groundTimer >= timeOnGround)
            {
                Destroy(gameObject); // Destroy the object after the set time
            }
        }
    }
    Vector3 RandomSpawnPos()
    {
        return new Vector3(UnityEngine.Random.Range(-xRange, xRange), ySpawnPos, UnityEngine.Random.Range(zRange, -1));
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            // Debug.Log("Throwable is on ground.");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rival"))
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.SetScore(pointValue);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isOnGround = false;
            // Debug.Log("Throwable has left the ground.");
        }
    }
}

