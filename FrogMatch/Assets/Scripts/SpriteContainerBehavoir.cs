using UnityEngine;
using UnityEngine.Events;

public class SpriteContainerBehavoir : MonoBehaviour
{
    public Sprite SpriteObj;
    public UnityEvent startEvent;
    public void Start()
    {
        startEvent.Invoke();
    }
}
