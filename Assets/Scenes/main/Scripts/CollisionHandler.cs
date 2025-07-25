using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float winTiming = 2f;
    [SerializeField] float deathTiming = 2f;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip death;
    [SerializeField] ParticleSystem successParticle;
    [SerializeField] ParticleSystem deathParticle;
    [SerializeField] ParticleSystem fallDown;
    [SerializeField] bool isCollisionDisabled = false;
    bool isTransitioning = false;
    AudioSource audioSource;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        cheat_keys();
    }

    void cheat_keys()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            loadNextLevel();
        }

        else if (Input.GetKeyDown(KeyCode.C))
        {
            isCollisionDisabled = !isCollisionDisabled;
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        // if (isTransitioning == false)
        Debug.Log("You collided with : ");
        
        if (isTransitioning || isCollisionDisabled) { return; }

        switch (other.gameObject.tag)
        {
            case "Start":
                Debug.Log("START");
                break;

            case "Finish":
                successScene();
                Debug.Log("FINISH");
                break;

            case "Wall":
                crashScene();
                Debug.Log("WALL");
                break;

            default:
                successScene();
                break;
        }
    }

    void successScene()
    {
        isTransitioning = true;
        successParticle.Play();
        audioSource.Stop();
        audioSource.PlayOneShot(success);
        GetComponent<mover_1stL>().enabled = false;
        Invoke("loadNextLevel", winTiming);
    }
    void crashScene()
    {
        isTransitioning = true;
        deathParticle.Play();
        fallDown.Play();
        audioSource.Stop();
        audioSource.PlayOneShot(death);
        GetComponent<mover_1stL>().enabled = false;
        Invoke("reloadLevel", deathTiming);
    }

    // this method writing is wrong they should be more seperate to be more flexible .
    //  now i cant put the scene num in there because of the invoke str thing

    void loadNextLevel()
    {
        // if level is considered 0 then the scene reloads
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        // if maxsceneCountInBuildSettings equals the currentindex + 1 then the scene goes to zero (First scene)
        if (currentSceneIndex == SceneManager.sceneCountInBuildSettings) { currentSceneIndex = 0; }

        Debug.Log("Loading next level ...");
        SceneManager.LoadScene(currentSceneIndex);

    }

    void reloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Reloading");
        SceneManager.LoadScene(currentSceneIndex);
    }

}
