using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover_1stL : MonoBehaviour
{


    //This is the old moving method down here
    // void Update()
    // {
    //     float zVal = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
    //     float yVal = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
    //     // transform.Rotate(0.1f, 0.1f, 0.1f);
    //     transform.Translate(0, yVal, zVal);
    // }


    // Actions : 

    // 1.Transform (Movement - vector up)  
    // 2.Rotation and bug fix which hasn't been completely fixed  
    // 3.Auiohandler for thrust

    [SerializeField] float thrustSpeed = 1000f ;
    [SerializeField] float rotateSpeed = 100f ;
    [SerializeField] float startTimer = 0 ;
    Rigidbody moverRB;
    AudioSource thrustOgg;
    void Start()
    {
        moverRB = GetComponent<Rigidbody>();
        thrustOgg = GetComponent<AudioSource>();
    }

    void Update()
    {
        proccessThrust();
        proccessRotate();
    }

    void proccessThrust()
    {
        // Input.GetKey("Space");
        if (Input.GetKey(KeyCode.Space))
        {
            moverRB.AddRelativeForce(Vector3.up * thrustSpeed * Time.deltaTime);

            if (!thrustOgg.isPlaying)
            {
                thrustOgg.Play();
            }
        }
        
        else
        {
            thrustOgg.Stop();
        }

    }

    void proccessRotate()
    {

        if (Input.GetKey(KeyCode.D))
        {
            rotation(rotateSpeed);
        }

        else if (Input.GetKey(KeyCode.A))
        {
            rotation(-rotateSpeed);
        }
    }

    private void rotation(float rotationThisFrame)
    {
        moverRB.freezeRotation = true; // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        moverRB.freezeRotation = false; // unfreezing rotation so physics system take over
    }
}
