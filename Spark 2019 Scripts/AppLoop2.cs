using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppLoop2 : MonoBehaviour
{
    public Text AtHomeTemp;
    public Text AwayHomeTemp;
    public Slider AtHomeSlider;
    public Slider AwayHomeSlider;

    // Update is called once per frame
    void Update()
    {
        AtHomeTemp.text = AtHomeSlider.value.ToString();
        AwayHomeTemp.text = AwayHomeSlider.value.ToString();
    }
}
