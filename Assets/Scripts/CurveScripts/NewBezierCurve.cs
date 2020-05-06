using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBezierCurve : MonoBehaviour
{
    public List <BezierCurve> curves = new List<BezierCurve>();
    public List<int> animationLengths = new List<int>();



    [Range(0, 1)] public float percent = 0;

    public bool shouldAnimate = true;

    public AnimationCurve speed; //Animation curve to ease through camera
    public float animationLength = 5;//How long the animation should last

    float timeCurrent = 0;

    public bool shouldLoop = false;
    public bool shouldSwitchThenLoop = false;
    public bool switchCurve = false;

    public int currentCurve = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (shouldAnimate)
        {
            timeCurrent += Time.deltaTime;
            percent = timeCurrent / animationLengths[currentCurve];
            percent = Mathf.Clamp(percent, 0, 1);
            if (shouldSwitchThenLoop)
            {
                if(percent == 1)
                {
                    SwitchToNewLoopingCurve();
                }
                
            }
            if (shouldLoop)
            {
                if (percent == 1)
                {
                    if(shouldSwitchThenLoop)
                    {
                        SwitchToNewLoopingCurve();
                    }
                    else
                    {
                        ResetCurve();
                    }
                    
                }
            }
        }

        SetPositionToCurve();
    }
    public void SwitchToNewLoopingCurve()
    {
        currentCurve += 1;
        ResetCurve();
        shouldLoop = true;
        shouldSwitchThenLoop = false;
    }
    public void SwitchToNewCurve()
    {
        shouldLoop = false;
        currentCurve += 1;
        ResetCurve();
    }
    public void ResetCurve()
    {
        percent = 0;
        timeCurrent = 0;
    }

    private void SetPositionToCurve()
    {
        if (curves[currentCurve])
        {
            float p = speed.Evaluate(percent);//taking our percent value passing it in to get new percent values
            transform.position = curves[currentCurve].FindPositionAt(p);
        }
    }

    void OnValidate()
    {
        SetPositionToCurve();
    }
}
