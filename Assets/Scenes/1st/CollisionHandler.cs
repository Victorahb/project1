using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("You collided with : ");

        switch (other.gameObject.tag)
        {

            case "Wall":
                crashScene();
                Debug.Log("WAll");
                break;

            case "Start":
                Debug.Log("START");
                break;

            case "Finish":
                crashScene();
                Debug.Log("FINISH");
                break;

            default:
                crashScene();
                break;
                
        }
    }

    void crashScene()
    {
        GetComponent<mover_1stL>().enabled = false;
        Invoke("loadLevel", 1f);
    }

    // this method writing is wrong they should be more seperate to be more flexible .
    //  now i cant put the scene num in there because of the invoke str thing

    void loadLevel()
    {
        // if level is considered 0 then the scene reloads
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        // if maxsceneCountInBuildSettings equals the currentindex + 1 then the scene goes to zero (First scene)
        if (currentSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            currentSceneIndex = 0;
        }

        SceneManager.LoadScene(currentSceneIndex);

        Debug.Log("SOMETHING");
    }

}
