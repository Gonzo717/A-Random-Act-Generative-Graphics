using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class speed : MonoBehaviour
{
    private ParticleSystem ps;
    public float hSliderValue = 1.0F;
    public Slider particle_speed;


    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        var main = ps.main;
        main.startSpeed = particle_speed.value;
    }

    void OnGUI()
    {
        //hSliderValue = GUI.HorizontalSlider(new Rect(25, 45, 100, 30), hSliderValue, 0.0F, 10.0F);
    }
}
