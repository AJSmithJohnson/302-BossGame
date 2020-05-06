using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenManager : MonoBehaviour
{
    public NewBezierCurve UICurve;
    public NewBezierCurve camCurve;
    public PointAt camPointAt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(camCurve.currentCurve != 0)
        {
            UICurve.shouldAnimate = true;
            UICurve.shouldLoop = true;
            camPointAt.wantToLookAt = true;
        }
    }
}
