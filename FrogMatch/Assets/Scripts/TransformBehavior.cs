using UnityEngine;

public class TransformBehavior : MonoBehaviour
{
    public Vector3Data v3data;
    public void ResetToZero()
    {
        transform.position = Vector3.zero;
    }
    public void SetV3Value()
    {
        v3data.value = transform.position;
    }
    public void Update()
    {
        SetV3Value();
    }
}
