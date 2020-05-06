using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorScript : MonoBehaviour
{
    public float xRotation = 0;
    public float yRotation = 0;
    public float zRotation = 0;
    public float rotationSpeedX = 0;
    public float rotationSpeedY = 0;
    public float rotationSpeedZ = 0;
    public bool startStop = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(startStop)
        {
            transform.Rotate((Time.deltaTime * xRotation) * rotationSpeedX, Mathf.Sin(Time.deltaTime * yRotation) * rotationSpeedY, (Time.deltaTime * zRotation) * rotationSpeedZ);
        }
        else
        {
            transform.Rotate((Time.deltaTime * xRotation) * rotationSpeedX, (Time.deltaTime * yRotation) * rotationSpeedY, (Time.deltaTime * zRotation) * rotationSpeedZ);
        }
        
    }
}
