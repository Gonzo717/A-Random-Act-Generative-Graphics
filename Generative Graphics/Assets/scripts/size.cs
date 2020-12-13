using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class size : MonoBehaviour
{
    private ParticleSystem ps;
    public float hSliderValue = 1.0F;
    public Slider particle_size;


    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        var main = ps.main;
        main.startSize = particle_size.value;
    }

    void OnGUI()
    {
        //hSliderValue = GUI.HorizontalSlider(new Rect(25, 45, 100, 30), hSliderValue, 0.0F, 10.0F);
    }
}
