using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Slider = UnityEngine.UI.Slider;

// this class is for operating the Julia Fractal
public class JuliaFractal : MonoBehaviour
{
    // variables and GameObjects needed from the Unity Scene
    [SerializeField] Material mat;
    [SerializeField] Vector2 pos;
    [SerializeField] float scale, angle;

    // slider info for updating values
    private Slider depthSlider;
    private Slider speedSlider;

    // called once upon start, finding sliders in the scene
    private void Start()
    {
        depthSlider = GameObject.Find("Depth Slider").GetComponent<Slider>();
        speedSlider = GameObject.Find("Speed Slider").GetComponent<Slider>();
    }

    // called to update fractal in a fixed rate
    void FixedUpdate()
    {
        mat.SetFloat("_MaxIter", depthSlider.value);
        mat.SetFloat("_Speed", speedSlider.value);
    }
}
