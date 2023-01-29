using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camswitch : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Camera cam1;
    [SerializeField] Camera cam2;
    void Start()
    {
        cam1.enabled = false;
        cam2.enabled = true ;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            cam1.enabled = !cam1.enabled;
            cam2.enabled = !cam2.enabled;
        }
    }
}
