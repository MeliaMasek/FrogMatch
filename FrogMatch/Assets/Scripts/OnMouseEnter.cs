using UnityEngine;
using UnityEngine.Events;
public class OnMouseEnter : MonoBehaviour

//Code borrowed and referenced by Berenger from the UnityAnswers Board.

//Can't figure out how to get it to print to the console? On debug works at the moment
//Additionally the unity event bit isnt working, I can get it to work without the event
{
    public UnityEvent startEvent;
    public enum MouseOverType{ Action1, Action2, Action3, Action4, Action5, Action6}
    public MouseOverType  mouseHover;
    
    private void Start()
    {
        startEvent.Invoke();
            
        switch(mouseHover)
        {
            case MouseOverType.Action1 : Debug.Log("A Blue Diamond!"); break;
            case MouseOverType.Action2 : Debug.Log("A Red Sphere!"); break;
            case MouseOverType.Action3 : Debug.Log("A Green Sphere!"); break;
            case MouseOverType.Action4 : Debug.Log("A Yellow Capsule!"); break;
            case MouseOverType.Action5 : Debug.Log("A Purple Hexagon!"); break;
            case MouseOverType.Action6 : Debug.Log("A White Square!"); break;
        }
    }
}