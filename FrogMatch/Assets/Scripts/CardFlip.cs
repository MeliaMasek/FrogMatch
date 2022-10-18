using System;
using UnityEngine;

//Code borrowed from https://github.com/kurtkaiser/MemoryVideoTutorial
public class CardFlip : MonoBehaviour
{ 
    SpriteRenderer card;
    public Sprite front;
    public Sprite back;

    public void OnMouseDown()
    {
        if(card.sprite == back)
        {
            card.sprite = front;
        }
        else
        {
            card.sprite = back;
        }
    }

    private void Awake()
    {
        card = GetComponent<SpriteRenderer>();
    }
}
