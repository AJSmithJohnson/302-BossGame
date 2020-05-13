using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour
{
    public Transform punchTarget;
    public Vector3 startingPosition;
    public float percent = 0;
    public float punchSpeed = 1;
    public bool isPunching = false;
    public int alternatePunches = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            
            isPunching = true;
            if(percent < 1)
            percent += Time.deltaTime * punchSpeed;
            if (alternatePunches % 2 == 0)
            {
                transform.position = Vector3.Lerp(startingPosition, punchTarget.position, percent);
            }
            
        }
        else
        {
            alternatePunches += 1;
            isPunching = false;
            if(percent > 0)
            {
                percent -= Time.deltaTime;
            }

        }
       
        
    }
}
