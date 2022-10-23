using UnityEngine;

//code borrowed from Stephen Barr from "Make a Simple Card Game in Unity | Book Club Tutorials" https://www.youtube.com/watch?v=E1nO1PbQFXw//
public class ButtonUI : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;
    [SerializeField] private string targetMessage;
    public Color highlightColor = Color.cyan;

    public void OnMouseOver()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if (sprite != null)
        {
            sprite.color = highlightColor;
        }
    }

    public void OnMouseExit()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if(sprite != null)
        {
            sprite.color = Color.white;
        }
    }

    public void OnMouseDown()
    {
        transform.localScale = new Vector3(0.4f, 0.4f, 1.0f);
    }

    public void OnMouseUp()
    {
        transform.localScale = new Vector3(0.3f, 0.3f, 1.0f);
        if(targetObject != null)
        {
            targetObject.SendMessage(targetMessage);
        }
    }
}