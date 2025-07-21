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

    // [SerializeField] float startTimer = 0 ;
    [SerializeField] float thrustSpeed = 1000f;
    [SerializeField] float rotateSpeed = 100f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem bodythrustParticle;
    [SerializeField] ParticleSystem leftThrustParticle;
    [SerializeField] ParticleSystem rightThrustParticle;

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
    private void OnCollisionEnter()
    {
        bodythrustParticle.Stop();
        leftThrustParticle.Stop();
        rightThrustParticle.Stop();
    }



    void proccessThrust()
    {
        // Input.GetKey("Space");
        if (Input.GetKey(KeyCode.Space))
        {
            playing_thrust();
        }

        else
        {
            stopping_thrust();
        }
    }

    void playing_thrust()
    {
        moverRB.AddRelativeForce(Vector3.up * thrustSpeed * Time.deltaTime);
        
        if (!thrustOgg.isPlaying)
        {
            thrustOgg.PlayOneShot(mainEngine);
        }
        // IDK why i added this it was working fine before
        // fix : i see its because it doesnt reset the animation for the particle
        if (!bodythrustParticle.isPlaying)
        {
            bodythrustParticle.Play();
        } 
    }

    void stopping_thrust()
    {
        bodythrustParticle.Stop();
        thrustOgg.Stop();
    }

    void proccessRotate()
    {

        if (Input.GetKey(KeyCode.D))
        {
            rotate_right();
        }

        else if (Input.GetKey(KeyCode.A))
        {
            rotate_left();
        }

        else
        {
            stopping_rotate();
        }
    }

    void rotate_right()
    {
        rotation(rotateSpeed);
        if (!leftThrustParticle.isPlaying)
        {
            leftThrustParticle.Play();
        }     
    }

    void rotate_left()
    {
        rotation(-rotateSpeed);
        if (!rightThrustParticle.isPlaying)
        {
            rightThrustParticle.Play();
        }
    }

    void stopping_rotate()
    {
        leftThrustParticle.Stop();
        rightThrustParticle.Stop();
    }

    void rotation(float rotationThisFrame)
    {
        moverRB.freezeRotation = true; // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        moverRB.freezeRotation = false; // unfreezing rotation so physics system take over
    }
}
