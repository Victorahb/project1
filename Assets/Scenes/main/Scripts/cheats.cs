using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cheats : MonoBehaviour
{
    // bool collisionDisabled = false;
    [SerializeField] CollisionHandler collisionHandler;
    // void Start()
    // {
    //     collisionHandler = GetComponent<mover_1stL>().enabled = false;
    // }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            nextLevel();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            collisionDisable();
        }
    }

    void nextLevel()
    {
        // if level is considered 0 then the scene reloads
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        // if maxsceneCountInBuildSettings equals the currentindex + 1 then the scene goes to zero (First scene)
        if (currentSceneIndex == SceneManager.sceneCountInBuildSettings) { currentSceneIndex = 0; }

        Debug.Log("Loading next level ...");
        SceneManager.LoadScene(currentSceneIndex);
    }

    void collisionDisable()
    {
        collisionHandler.enabled = false;
    }
}
