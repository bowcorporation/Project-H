using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSystem : MonoBehaviour {

    public float jumpHeight;
    public bool isGrounded;
    public float GravityStrength;
    Rigidbody rb;

    // Use this for initialization
    void Start()
    {

        Physics.gravity = new Vector3(0, GravityStrength, 0);
        rb = GetComponent<Rigidbody>();
        isGrounded = true;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(transform.up * jumpHeight);
            isGrounded = false;
        }

    }

    void OnCollisionEnter()
    {
        isGrounded = true;
    }
}
