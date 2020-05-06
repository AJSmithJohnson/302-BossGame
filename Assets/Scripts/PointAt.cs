using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAt : MonoBehaviour
{
    public Transform target;
    public bool wantToLookAt = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return ;
        if(wantToLookAt)
        {
            //Vector3 look = target.position - transform.position;

            //look.Normalize();
            //Quaternion targetRotation = Quaternion.LookRotation(look, Vector3.up);
            //transform.rotation = AnimMath.Lerp(transform.rotation, targetRotation, .01f);
            //didn't like the way the above code was working
            transform.LookAt(target, Vector3.up);
        }
        
    }
}
