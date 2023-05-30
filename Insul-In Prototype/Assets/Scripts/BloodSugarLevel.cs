using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSugarLevel : MonoBehaviour
{
    //PlaceHolderValues
    public int minBSL = 0;
    public int maxBSL = 300;
    public int minGoodBSL = 90;
    public int maxGoodBSL = 130;
    public int initBSL = 100;
    public int GLUKIBSLVal = 5;

    private int prevNumGLUKI;
    public int BSL;
    

    // Start is called before the first frame update
    void Start()
    {
        BSL = initBSL;
        prevNumGLUKI = GameObject.FindGameObjectsWithTag("GLUKI").Length;
    }

    // Update is called once per frame
    void Update()
    {
        int numGLUKI = GameObject.FindGameObjectsWithTag("GLUKI").Length;
        int GLUKIDif = numGLUKI - prevNumGLUKI;

        prevNumGLUKI = numGLUKI; //update prevNumGLUKI
        BSL += GLUKIDif * GLUKIBSLVal;

        /*
        if (GLUKIDif > 0)
        {
            //if positive -> more GLUKIs have spawned -> increase BSL
            BSL += GLUKIDif * GLUKIBSLVal;
        }
        else if (GLUKIDif < 0)
        {
            // if negative -> GLUKIs have been absorbed by the cell -> decrease BSL
            BSL -= -GLUKIDif * GLUKIBSLVal; //GLUKIDif is negative to make the math work right
        }*/
    }
}
