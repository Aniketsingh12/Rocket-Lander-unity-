using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 startpos;
    [SerializeField] Vector3 movevec;
    float movefac;
    [SerializeField] float period = 2f;
    void Start()
    {
        startpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) { return; }
        float cycles = Time.time / period;//continue grow 
        const float tau = Mathf.PI * 2;//const value 6.288
        float rawsin = Mathf.Sin(cycles * tau);//from -1 to 1

        movefac = (rawsin + 1f) / 2f;
        Vector3 offset = movevec * movefac;
        transform.position = startpos + offset;
    }
}
