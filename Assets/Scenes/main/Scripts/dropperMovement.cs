using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropperMovement : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    [SerializeField][Range(0, 1)] float movementFactor;
    [SerializeField] float period = 10f;

    void Start()
    {
        startingPosition = transform.position;
        // Debug.Log(startingPosition);
    }
    void Update()
    {
        Oscillation();
    }

    void Oscillation()
    {
        if (period <= Mathf.Epsilon) {return;} // it was 0 at first but now it's epsilon because we need more of a specific number rather than just 0

        float cycles = Time.time / period; // time is garentueeing the continuous and period is period ......... bigger the period the smaller the cycle
        const float tau = Mathf.PI * 2; //radiant the wave itself without any change (6.28)
        float rawSinWave = Mathf.Sin(cycles * tau); //going from 1 to -1
        // Debug.Log(rawSinWave);
        movementFactor = (rawSinWave + 1f) / 2f; //because we dont want it to be beneath zero and divide by 2 because the maximum is 1
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition  + offset;
        // Debug.Log(offset);
    }
}
