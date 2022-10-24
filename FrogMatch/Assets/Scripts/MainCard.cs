using UnityEngine;

//code borrowed from Stephen Barr from "Make a Simple Card Game in Unity | Book Club Tutorials" https://www.youtube.com/watch?v=E1nO1PbQFXw//
public class MainCard : MonoBehaviour
{
public SceneController controller;
public GameObject cardBack;

public void OnMouseDown()
    {
        if(cardBack.activeSelf && controller.canReveal)
        {
            cardBack.SetActive(false);
            controller.CardRevealed(this);
        }
    }

private int _id;
public int id
    {
        get { return _id; }
    }

public void ChangeSprite(int id, Sprite image)
    {
        _id = id;
        GetComponent<SpriteRenderer>().sprite = image; //This gets the sprite renderer component and changes the property of it's sprite!
    }

public void Unreveal()
    {
        cardBack.SetActive(true);
    }
}