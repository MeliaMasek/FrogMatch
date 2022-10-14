using UnityEngine;
using UnityEngine.Events;
using System.Globalization;
using TMPro;

public class TmpBehavior : MonoBehaviour
{
    private TextMeshProUGUI label;
    //public FloatData dataObj;
    public UnityEvent startEvent;
    private void Start()
    {
        label = GetComponent<TextMeshProUGUI>();
        startEvent.Invoke();
        //label.text = dataObj.value.ToString();
    }

    public void UpdateLabel(FloatData obj)
    {
        label.text = obj.value.ToString(CultureInfo.InvariantCulture);
        //label.text = dataObj.value.ToString(CultureInfo.InvariantCulture);
    }

    public void UpdateLabel(IntData obj)
    {
        label.text = obj.value.ToString(CultureInfo.InvariantCulture);
    }

}
