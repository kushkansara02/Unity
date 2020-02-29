using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppLoop : MonoBehaviour
{
    public Slider SetTempSlider;
    public Text ETAText;
    public Text setTempNum;
    public Text currentTempNum;

    // Update is called once per frame
    void Update()
    {
        int changeInTemp = Math.Abs(Convert.ToInt32(currentTempNum.text) - Convert.ToInt32(setTempNum.text));
        int timeETA = 5 * changeInTemp + 5;

        ETAText.text = "House temperature will reach " + Convert.ToInt32(setTempNum.text) + "˚C in: " + timeETA.ToString() + " minutes";
        setTempNum.text = SetTempSlider.value.ToString();
    }
}
