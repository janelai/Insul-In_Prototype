using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BloodSugarLevel : MonoBehaviour
{
    //PlaceHolderValues
    [SerializeField] private int minBSL = 40;
    [SerializeField] private int maxBSL = 350;
    [SerializeField] private int minGoodBSL = 80;
    [SerializeField] private int maxGoodBSL = 130;
    [SerializeField] private int initBSL = 100;
    [SerializeField] private int GLUKIBSLVal = 10;

    [SerializeField] private TMP_Text BSLVal;
    [SerializeField] private Slider slider;

    private int prevNumGLUKI;

    // Allow scripts to grab but not set BSL:
    public int BSL { get; private set;}

    // Start is called before the first frame update
    void Start()
    {
        BSL = initBSL;
        prevNumGLUKI = GameObject.FindGameObjectsWithTag("GLUKI").Length;
        BSLVal.text = BSL.ToString();
        //slider.value = BSL;
    }

    // Update is called once per frame
    void Update()
    {
        int numGLUKI = GameObject.FindGameObjectsWithTag("GLUKI").Length;
        int GLUKIDif = numGLUKI - prevNumGLUKI;

        prevNumGLUKI = numGLUKI; //update prevNumGLUKI
        BSL += GLUKIDif * GLUKIBSLVal;

        if (GLUKIDif != 0)
        {
            BSLVal.text = BSL.ToString();
            //slider.value = BSL;
        }

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
