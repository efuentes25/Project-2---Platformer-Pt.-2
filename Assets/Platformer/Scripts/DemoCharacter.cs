using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DemoCharacter : MonoBehaviour
{
    public float acceleration = 10f;
    public float maxSpeed = 3f;
    public float jumpForce = 10f;
    public float jumpBoost = 5f;

    public bool isGrounded = false;

    // Update is called once per frame
    void Update()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        Rigidbody rbody = GetComponent<Rigidbody>();
        rbody.velocity += horizontalAxis * Vector3.right * Time.deltaTime * acceleration;
        
        /*if (rbody.velocity.magnitude > maxSpeed)
        {
            rbody.velocity = Vector3.ClampMagnitude(rbody.velocity, maxSpeed);
        }*/

        Collider col = GetComponent<Collider>();
        float castAmount = 0.03f; //col.bounds.extents.y + 0.03f;

        isGrounded = Physics.Raycast(transform.position, Vector3.down, castAmount);
        
        rbody.velocity = new Vector3(Mathf.Clamp(rbody.velocity.x, -maxSpeed, maxSpeed), rbody.velocity.y, rbody.velocity.z);
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rbody.velocity = new Vector3(10f, rbody.velocity.y, 0f);
        }
        
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            rbody.AddForce(Vector3.up * jumpBoost, ForceMode.Force);
        }

        Color lineColor = (isGrounded) ? Color.green : Color.red;
        Debug.DrawLine(transform.position, transform.position + Vector3.down * castAmount, lineColor, 0f, false);

        float speed = rbody.velocity.magnitude;
        Animator animator = GetComponent<Animator>();
        animator.SetFloat("Speed", speed);
        animator.SetBool("Jumping", !isGrounded);
    }
}
