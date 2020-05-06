using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    public float yaw;

    public float pitch;

    public float lookSensitivityX = 1;
    public float lookSensitivityY = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        yaw += mouseX * lookSensitivityX;
        pitch += mouseY * lookSensitivityY;

        pitch = Mathf.Clamp(pitch, 0, 89);

        Quaternion targetRotation = Quaternion.Euler(pitch, yaw, 0);

        transform.rotation = AnimMath.Dampen(transform.rotation, targetRotation, .001f);
    }
}
