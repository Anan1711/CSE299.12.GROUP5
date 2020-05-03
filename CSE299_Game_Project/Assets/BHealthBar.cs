using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BHealthBar : MonoBehaviour
{
    public NBossHealth bossHealth;
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = bossHealth.health;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = bossHealth.health;
    }
}
