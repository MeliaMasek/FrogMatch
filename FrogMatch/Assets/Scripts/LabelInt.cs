using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Text))]

public class LabelInt : MonoBehaviour
{
    public Text label;
    public IntData dataObj;

    private void Start()
    {
        label = GetComponent<Text>();
        label.text = dataObj.value.ToString();
    }

    public void UpdateLabel()
    {
        label.text = dataObj.value.ToString(CultureInfo.InvariantCulture);
    }
}
