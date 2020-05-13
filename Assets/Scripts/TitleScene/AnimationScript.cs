using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    public Transform newPos;
    Vector3 holdPosition = new Vector3(0, 0, 0);
    Vector3 startPosition = new Vector3(0,0,0);
    public bool moveButtons;
    public float animationCount;
    public float currentAnimTime;
    public float animationTotalTime;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.localPosition;
        holdPosition = startPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(moveButtons)
        {
            currentAnimTime += animationCount * Time.deltaTime;
            startPosition.x = Mathf.Lerp(holdPosition.x, newPos.position.x, currentAnimTime);
            transform.localPosition = startPosition;
            if(currentAnimTime >= animationTotalTime)
            {
                moveButtons = false;
            }
        }
    }
}
