using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCurve : MonoBehaviour
{

    public BezierCurve curve;




    [Range(0, 1)] public float percent = 0;

    public bool shouldAnimate = true;

    public AnimationCurve speed; //Animation curve to ease through camera
    public float animationLength = 5;//How long the animation should last

    float timeCurrent = 0;

    public bool shouldLoop = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(shouldAnimate)
        {
            timeCurrent += Time.deltaTime;
            percent = timeCurrent / animationLength;
            percent = Mathf.Clamp(percent, 0, 1);
            if(shouldLoop)
            {
                if (percent == 1)
                {
                    percent = 0;
                    timeCurrent = 0;
                }
            }
        }

        SetPositionToCurve();
    }

    private void SetPositionToCurve()
    {
        if (curve)
        {
            float p = speed.Evaluate(percent);//taking our percent value passing it in to get new percent values
            transform.position = curve.FindPositionAt(p);
        }
    }

    void OnValidate()
    {
        SetPositionToCurve();
    }
}
