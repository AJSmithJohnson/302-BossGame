using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmIkController : MonoBehaviour
{
    Punch punch;
    PlayerController player;
    Vector3 startingPosition;
    
    public Vector3 startingOffset;
    public float bendArmHere = 0;
    public float sinWaveOffset = 0;
    public float sinWaveSpeed = 1;

    public float scaleX = 1;

    public float distanceY = 1;
    public float distanceZ = 1;

    public float armYThreshold = 20;
    public float maxArmY = 10;
    // Start is called before the first frame update
    void Start()
    {
        punch = GetComponent<Punch>();
        startingPosition = transform.localPosition;
        punch.startingPosition = startingPosition;
        player = GetComponentInParent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        float time = (Time.time + sinWaveOffset * Mathf.PI) * sinWaveSpeed;

        float offsetZ = Mathf.Sin(time);
        //float offsetY = Mathf.Sin( time) * -1;
        // if (offsetY > 1) offsetY = .25f;

        Vector3 finalPosition = startingPosition;

        finalPosition.x *= scaleX;
       // finalPosition.y += offsetY * distanceY;

        Vector3 armDir = transform.InverseTransformDirection(player.walkDir);
        
        

        float p = armDir.magnitude;
        if(p >= 1)
        {
            finalPosition.z +=  offsetZ * distanceZ;
            if(finalPosition.z >= bendArmHere)
            {
                finalPosition.y += distanceY;
            }
            else
            {
                finalPosition.y = startingPosition.y;
            }
        }
        transform.localPosition = finalPosition;
       /* if (punch.isPunching != true)
        {
            transform.localPosition = Vector3.Lerp(startingPosition, finalPosition, p);

        }*/
    }
}
