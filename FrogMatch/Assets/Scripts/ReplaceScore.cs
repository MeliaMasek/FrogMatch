using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class ReplaceScore : ScriptableObject

{
    public int value;

    public void ReplaceValue(int number)
    {
        value = number;
    }
}
