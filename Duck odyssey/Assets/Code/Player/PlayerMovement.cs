using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private PlayerCharacterInput _input;
    private PlayerInput _playerInput;

    private Rigidbody rb;
    public float speed;
    public float boost = 1.5f;

    public float delay = 0.35f;
    public float timer = 0;

    //public float acceleration;
    //public float maxSpeed = 300f;

    private float vertical;
    private float horizontal;

    public List<float> lastVertical;
    public List<float> lastHorizontal;

    void Start()
    {
        _input = GetComponent<PlayerCharacterInput>();
        _playerInput = GetComponent<PlayerInput>();

        rb = GetComponent<Rigidbody>();

        lastVertical = new List<float>();
        lastHorizontal = new List<float>();
}
    void Update()
    {
        if (!_input.sprint)
        {
            vertical = Input.GetAxisRaw("Vertical");
            horizontal = Input.GetAxisRaw("Horizontal");
        }

        if (timer < 0 && timer > -delay)
        {
            timer -= Time.deltaTime;
        }
        else if (timer < 0 && timer <= -delay)
        {
            timer = 0;
        }
    }
    void FixedUpdate()
    {
        if (_input.sprint)
        {
            lastVertical.Add(Input.GetAxisRaw("Vertical"));
            lastHorizontal.Add(Input.GetAxisRaw("Horizontal"));

            if (timer >= delay)
            {
                if (lastVertical.Count > 0)
                {
                    vertical = (lastVertical[0] + Input.GetAxisRaw("Vertical"))/2f;
                    lastVertical.RemoveAt(0);
                }

                if (lastHorizontal.Count > 0)
                {
                    horizontal = (lastHorizontal[0] + Input.GetAxisRaw("Horizontal"))/2f;
                    lastHorizontal.RemoveAt(0);
                }
            }

            timer += Time.deltaTime;
        }
        else 
        {
            lastVertical.Clear();
            lastHorizontal.Clear();

            timer = -Mathf.Abs(timer);
        }

        if (_input.sprint && timer >= 0)
        {
            rb.velocity = new Vector3(horizontal * speed * boost * Time.fixedDeltaTime, vertical * speed * boost * Time.fixedDeltaTime, 0);
        }
        else
        {
            rb.velocity = new Vector3(horizontal * speed * Time.fixedDeltaTime, vertical * speed * Time.fixedDeltaTime, 0);

            _input.jump = false;
        }
        
    }

}
