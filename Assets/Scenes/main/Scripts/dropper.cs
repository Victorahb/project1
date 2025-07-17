using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropper : MonoBehaviour
{

    MeshRenderer dropperRenderer;
    Rigidbody dropperRigid;
    [SerializeField] float timerStart = 3f;

    void Start()
    {
        dropperRenderer = GetComponent<MeshRenderer>();
        dropperRigid = GetComponent<Rigidbody>();

        dropperRenderer.enabled = false;
        dropperRigid.useGravity = false;
    }

    void Update()
    {
        dropperPhys();
    }

    void dropperPhys()
    {
        if (Time.time > timerStart)
        {
            // float timerNow = Time.time;
            // int newTime = System.Convert.ToInt32(timerNow);
            // Debug.Log("Time has passed : " + newTime);


            dropperRenderer.enabled = true;
            dropperRigid.useGravity = true;         
        }
    }

}
