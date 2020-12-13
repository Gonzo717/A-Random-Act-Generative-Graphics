using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gravity: MonoBehaviour
{
    private ParticleSystem ps;
    public float hSliderValue = 1.0F;
    public Slider partivle_gravity;


    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        var main = ps.main;
        main.gravityModifier = partivle_gravity.value;
    }

    void OnGUI()
    {
        //hSliderValue = GUI.HorizontalSlider(new Rect(25, 45, 100, 30), hSliderValue, 0.0F, 10.0F);
    }
}
