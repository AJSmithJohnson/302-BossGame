using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPointAt : MonoBehaviour
{
    public OrbitCamera cam;
    public bool isAnimating = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isAnimating && cam != null)
        {
            Quaternion targetRot = Quaternion.Euler(0, cam.yaw, 0);
            transform.rotation = AnimMath.Dampen(transform.rotation, targetRot, .01f);
        }
    }
}
