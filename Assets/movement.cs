using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    [SerializeField] float mainThrust = 100;
    [SerializeField] float rotateThrust = 100;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
