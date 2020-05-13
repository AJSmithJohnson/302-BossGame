using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenManager : MonoBehaviour
{
    public NewBezierCurve UICurve;
    public NewBezierCurve camCurve;
    public PointAt camPointAt;
    public AnimationScript animScript1;
    public AnimationScript animScript2;
    public AnimationScript animScript3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(camCurve.currentCurve != 0)
        {
            animScript1.moveButtons = true;
            animScript2.moveButtons = true;
            animScript3.moveButtons = true;
            UICurve.shouldAnimate = true;
            UICurve.shouldLoop = true;
            camPointAt.wantToLookAt = true;
        }
    }
}
