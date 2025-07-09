using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover : MonoBehaviour
{

    [SerializeField] float moveSpeed = 380f;
    [SerializeField] float rotateSpeed = 100f;
    Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Log("Player");
    }


    void Update()
    {
        ProcessThrust();
        ProcessRotate();

    }

    void ProcessThrust()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * moveSpeed * Time.deltaTime );
        }
    }
    void ProcessRotate()
    {
        float rotateVal = Time.deltaTime * rotateSpeed;
       
        if (Input.GetKey(KeyCode.A))
        {
            rotationVal(rotateVal, 1);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            rotationVal(rotateVal, -1);

        }

    }
    int forwardFlag = 1;
    void rotationVal(float rotateVal, int forwardFlag)
    {
        // rb.freezeRotation = true; // freezing rotation so we can manually rotate
        transform.Rotate(forwardFlag * Vector3.forward * rotateVal);
        // rb.freezeRotation = false; // unfreezing rotation so the physics system can take over
    }
}
