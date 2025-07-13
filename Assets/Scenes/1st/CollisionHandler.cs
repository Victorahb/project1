using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("You collided with : ");

        switch (other.gameObject.tag)
        {
            case "Wall":
                loadLevel(0);
                Debug.Log("WAll");
                break;

            case "Start":
                Debug.Log("START");
                break;

            case "Finish":
                loadLevel(1);
                Debug.Log("FINISH");
                break;

            default:
                loadLevel(1);
                break;
        }
    }

    void loadLevel(int level)
    {
        // if level is considered 0 then the scene reloads
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex + level;

        // if maxsceneCountInBuildSettings equals the currentindex + 1 then the scene goes to zero (First scene)
        if (currentSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            currentSceneIndex = 0;
        }

        SceneManager.LoadScene(currentSceneIndex);

        Debug.Log("SOMETHING");
    }

}
