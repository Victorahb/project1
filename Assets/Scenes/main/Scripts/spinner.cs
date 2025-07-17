using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinner : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 10f;
    void Update()
    {
        float yVal = rotateSpeed * Time.deltaTime;

        transform.Rotate(0, yVal, 0);
    }
}
