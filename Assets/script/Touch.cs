using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Touch : MonoBehaviour
{
    [SerializeField] AudioClip start;
    [SerializeField] AudioClip crash;
    AudioSource audio;
    bool isTransitioning = false;


    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (isTransitioning) { return; }
        switch (collision.gameObject.tag)
        {
            case "Start":
                Debug.Log("ON START");
                
                break;
            case "Finish":
                
                finish();
                break;
            case "fuel":
                Debug.Log("Got fuel");
                break;
            default:
                
                desstroyed();

                Invoke("restart", 1);
                break;

        }
    }
    void desstroyed()
    {
        isTransitioning = true;
        audio.Stop();
        audio.PlayOneShot(crash);
        GetComponent<movement>().enabled = false;
        Invoke("restart", 2f);
    }
    void finish()
    {
        isTransitioning = true;
        audio.Stop();
        audio.PlayOneShot(start);
        GetComponent<movement>().enabled = false;
        Invoke("next", 2f);
    }
    void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void next()
    {
        int nextscene = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextscene == SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(0);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
