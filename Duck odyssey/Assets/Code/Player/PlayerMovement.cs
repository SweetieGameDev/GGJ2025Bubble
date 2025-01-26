using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;

    //public float acceleration;
    //public float maxSpeed = 300f;

    private float vertical;
    private float horizontal;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector3(horizontal * speed * Time.fixedDeltaTime, vertical * speed * Time.fixedDeltaTime, 0);
    }


}
