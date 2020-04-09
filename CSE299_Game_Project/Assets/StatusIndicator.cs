using UnityEngine;
using UnityEngine.UI;

public class StatusIndicator : MonoBehaviour
{
    [SerializeField] // an attribute to show the private variable in editor.
    private RectTransform HealthBarRect;

    void Start()
    {
        // checking if we have this component.
        if (HealthBarRect == null)
        {
            Debug.LogError("Status Indicator : No health bar object referenced");
        }

    }

    // setting the current health and max health.
    // _cur private variable only acceasble within the function.
    public void SetHealth(int _cur,int _max)
    {
        // calculating the health.
        float _value = (float)_cur / _max;
        HealthBarRect.localScale = new Vector3(_value, HealthBarRect.localScale.y, HealthBarRect.localScale.z) ;
    }
}
