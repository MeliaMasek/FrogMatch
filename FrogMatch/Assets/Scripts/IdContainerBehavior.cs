using UnityEngine;
using UnityEngine.Events;

public class IdContainerBehavior : MonoBehaviour

{
    public Id idObj;
    public UnityEvent startEvent;
    public void Start()
    {
        startEvent.Invoke();
    }
}
