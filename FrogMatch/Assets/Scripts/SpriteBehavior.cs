using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteBehavior : MonoBehaviour

{
    private SpriteRenderer rendererObj;
    public SpriteDataList SpriteDataListObj;

    private void Awake()
    {
        rendererObj = GetComponent<SpriteRenderer>();
    }

    public void ChangeRenderSprite(Sprite obj)
    {
        rendererObj.sprite = obj;
    }

    public void ChangeRenderSprite(SpriteDataList obj)
    {
        rendererObj.sprite = obj.currentSprite;
    }
}
