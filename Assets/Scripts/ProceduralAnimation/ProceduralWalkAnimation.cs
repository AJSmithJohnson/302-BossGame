using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralWalkAnimation : MonoBehaviour
{
    PlayerController player;
    Vector3 startingPosition;
    public float sinWaveOffset = 0;//used for alternating foot movement
    public float sinWaveSpeed = 1; //used for changing how fast the feet move

    //how far apart the feet should be side to side
    public float scaleX = 1;

    /// <summary>
    /// how high the foot comes up off the ground
    /// </summary>
    public float distanceY = 1;

    /// <summary>
    /// How far forward/backward to move the foot
    /// </summary>
    public float distanceZ = 1;

    
    // Start is called before the first frame update
    void Start()
    {
        //store default starting position
        startingPosition = transform.localPosition;

        player = GetComponentInParent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        float time = (Time.time + sinWaveOffset * Mathf.PI) * sinWaveSpeed;


        float offsetZ = Mathf.Sin(time);

        float offsetY = Mathf.Cos(time);//we adjust offsetY by a sin wave
        if (offsetY < 0) offsetY = 0;//if offset Y is less than zero then our characters feet
        //would be moving through the ground and we don't want that 

        //set our final position vector we instantiate here to our starting position
        Vector3 finalPosition = startingPosition;

        finalPosition.x *= scaleX;
        //finalPosition.z += offsetZ * distanceZ;//moveFinal position forward/backward
        finalPosition.y += offsetY * distanceY;//move finalPosition up/down //treats offsetY as a percentage multiplied by distanceY

        //get direction player is trying to move;
        //convert to localCoordinates
        Vector3 walkDir = transform.InverseTransformDirection(player.walkDir);

        //new code for moving forward/backward
        finalPosition += walkDir * offsetZ * distanceZ;

        float p = walkDir.magnitude;

        //transform.localPosition = finalPosition;
        transform.localPosition = Vector3.Lerp(startingPosition, finalPosition, p);
    }
}
