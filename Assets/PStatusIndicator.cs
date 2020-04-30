﻿
using UnityEngine;
using UnityEngine.UI;

public class PStatusIndicator : MonoBehaviour
{
    [SerializeField]
    private RectTransform healthBarRect;
    [SerializeField]
    private Text healthText;

    void Start()
    {
        if(healthBarRect == null)
        {
            Debug.LogError ("No healthbar object");
        }
        if(healthText == null)
        {
            Debug.LogError ("no healthtext object");
        }
    }

    public void SetHealth(int _cur, int _max)
    {
        float _value = (float)_cur / _max;

        healthBarRect.localScale = new Vector3(_value, healthBarRect.localScale.y, healthBarRect.localScale.z);

        healthText.text = _cur + "/" + _max + "HP";
    }
}
