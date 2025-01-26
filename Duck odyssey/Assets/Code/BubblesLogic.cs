using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblesLogic : MonoBehaviour
{
    // Floating power of bubble
    public float upwardForce = 2f;

    // Lifetime of the bubble before it pops
    public float lifetime = 10f;

    private Rigidbody bubblesRB;

    void Start()
    {
        bubblesRB = GetComponent<Rigidbody>();
        
        bubblesRB.useGravity = false; // Gravity will not affect the bubble

        Destroy((gameObject),lifetime); // Pop bubble when time expires
    }

    void FixedUpdate()
    {
        // Apply upward force, to allow bubble to float
        bubblesRB.AddForce(Vector3.up * upwardForce, ForceMode.Acceleration);
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the object it collides with has the tag "Player"
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
