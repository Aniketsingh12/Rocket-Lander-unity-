using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    [SerializeField] float mainThrust = 100;
    [SerializeField] float rotateThrust = 100;
    [SerializeField] AudioClip boost;
    AudioSource audio;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        processFly();
        processRotate();
    }
    void processFly()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            if (!audio.isPlaying)
            {
               audio.PlayOneShot(boost);
            }
            
        }
        else
        {
            audio.Stop();
        }
      
        
    }
    void processRotate()
    {
        if (Input.GetKey(KeyCode.LeftArrow ))
        {
            rotations(rotateThrust);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rotations(-rotateThrust);
        }
        
    }

    private void rotations(float rotates)
   {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotates * Time.deltaTime);
    }

    
    


}

