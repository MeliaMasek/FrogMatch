using UnityEngine;

public class ButtonClicks : MonoBehaviour
{
    public int counter;
 
    void Update() 
    { 
        if (Input.GetMouseButtonDown(0)) 
            counter ++; 
    }
}
