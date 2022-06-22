using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10.0f;
    private float turnSpeed = 30.0f;

    Rigidbody rb;
    private Vector3 inputVector;
    [SerializeField]
    float vertical, horizontal;
    Vector3 m_EulerAngleVelocity;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        m_EulerAngleVelocity = new Vector3(0, 100, 0);

    }
    // Update is called once per frame
    void Update()
    {
     
        
    }
    private void FixedUpdate()
    {
        rb.velocity = inputVector;
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");

        SetInputs(vertical, horizontal);
    }

    public void SetInputs(float forwardAmount, float turnAmount)
    {
        //Debug.Log($"Sterowanie: {forwardAmount}, {turnAmount}");

        transform.Translate(Vector3.forward * forwardAmount * moveSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up, turnAmount * turnSpeed * Time.deltaTime);
        //inputVector = new Vector3(Input.GetAxis("Horizontal") * forwardAmount, rb.velocity.y, Input.GetAxis("Vertical") * turnAmount);
        //transform.LookAt(transform.position + new Vector3(inputVector.x, 0, inputVector.z));
        /*
        rb.MovePosition(transform.position + m_Input * Time.deltaTime * moveSpeed);

        rb.MoveRotation(Quaternion.EulerAngles())
        */
        
       // Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.fixedDeltaTime);

        //rb.MovePosition(transform.position + m_Input * Time.deltaTime * moveSpeed);
       // rb.MoveRotation(rb.rotation * deltaRotation);
     
        
    }
    /*
    public void Inputs()
    {
        if (Input.GetKey("w"))
        {
            transform.Translate(forward * speed * Time.deltaTime);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(backward * speed * Time.deltaTime);
        }

        if (Input.GetKey("d"))
        {
            Quaternion deltaRotationRight = Quaternion.Euler(rotationRight * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotationRight);
        }

        if (Input.GetKey("a"))
        {
            Quaternion deltaRotationLeft = Quaternion.Euler(rotationLeft * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotationLeft);
        }
    }
    */
    public void StopCompletely()
    {
        SetInputs(0f, 0f);

    }

    public void IsUnder()
    {
        if (rb.transform.position.y < -1)
        {
            rb.transform.Translate(100,0,-18);

        }
    }
}
