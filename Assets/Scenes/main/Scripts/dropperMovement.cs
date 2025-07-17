using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropperMovement : MonoBehaviour
{
    [SerializeField] float flag = 1000f;
    Rigidbody dropperRigid;
    void Start()
    {
        dropperRigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Wall")
        { 
        flag = -flag;
        }  
    }
    void Update()
    {
        dropperThrust(flag);
    }

    void dropperThrust(float flag)
    {
        dropperRigid.AddRelativeForce(Vector3.right * flag * Time.deltaTime);
    }
}
