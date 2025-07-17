using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objHit : MonoBehaviour
{
    int scorePlayer = 0;
    void OnCollisionEnter(Collision s)
    {

        if (s.gameObject.tag != "Hit")
        {
            scorePlayer++;
        }

        if (s.gameObject.tag == "Dropper")
        {
            s.gameObject.GetComponent<MeshRenderer>().material.color = Color.black;
        }

        Debug.Log("obj : " + s.gameObject.tag);
        Debug.Log("Score : " + scorePlayer);
        s.gameObject.tag = "Hit";
    }
}
