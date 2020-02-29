using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Slider = UnityEngine.UI.Slider;

// this class is for handling the modified Mandelbrot Fractal
public class MandelbrotFractal : MonoBehaviour
{
    // variables and GameObjects needed from the Unity Scene
    [SerializeField] Material mat;
    [SerializeField] Vector2 pos;
    [SerializeField] float scale, angle;

    // variables needed for updating values
    private Slider depthSlider;
    private Slider symmetrySlider;
    private Vector2 smoothPos;
    private float smoothScale, smoothAngle;

    // called once upon start, initialising sliders
    private void Start()
    {
        depthSlider = GameObject.Find("Depth Slider").GetComponent<Slider>();
        symmetrySlider = GameObject.Find("Symmetry Slider").GetComponent<Slider>();
    }

    // updating the scale and angle of the fractal
    private void UpdateShader()
    {
        smoothPos = Vector2.Lerp(smoothPos, pos, 0.03f);
        smoothScale = Mathf.Lerp(smoothScale, scale, 0.03f);
        smoothAngle = Mathf.Lerp(smoothAngle, angle, 0.03f);

        float aspectRatio = (float)Screen.width / Screen.height;
        float scaleX = smoothScale;
        float scaleY = smoothScale;

        if (aspectRatio > 1f)
        {
            scaleY /= aspectRatio;
        }

        else if (aspectRatio < 1f)
        {
            scaleX *= aspectRatio;
        }

        mat.SetVector("_Area", new Vector4(smoothPos.x, smoothPos.y, scaleX, scaleY));
        mat.SetFloat("_Angle", smoothAngle);
    }

    // updates the fractal based on user inputs
    private void HandleInputs()
    {
        // rotating and zooming
        if (Input.GetKey(KeyCode.UpArrow))
        {
            scale *= 0.99f;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            scale *= 1.01f;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            angle -= 0.01f;
        }
        if (Input.GetKey(KeyCode.E))
        {
            angle += 0.01f;
        }

        // obtaining new position
        float factor = 0.01f * scale;
        Vector2 dir = new Vector2(factor, 0);
        float s = Mathf.Sin(angle);
        float c = Mathf.Cos(angle);
        dir = new Vector2(dir.x * c, dir.x * s);

        if (Input.GetKey(KeyCode.A))
        {
            pos -= dir;
        }
        if (Input.GetKey(KeyCode.D))
        {
            pos += dir;
        }

        dir = new Vector2(-dir.y, dir.x);

        if (Input.GetKey(KeyCode.S))
        {
            pos -= dir;
        }
        if (Input.GetKey(KeyCode.W))
        {
            pos += dir;
        }
    }

    // updates variables based on sliders
    public void UpdateSliders()
    {
        mat.SetFloat("_MaxIter", depthSlider.value);
        mat.SetFloat("_Symmetry", symmetrySlider.value);
    }

    // called to update fractal in a fixed framerate
    void FixedUpdate()
    {
        HandleInputs();
        UpdateShader();
        UpdateSliders();
    }
}
