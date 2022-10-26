using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class SpriteDataList : ScriptableObject
{
    public List<Sprite> SpriteList;
    public Sprite currentSprite;
    private int num;

    public void SetCurrentSpriteRandomly()
    {
        num = Random.Range(0, SpriteList.Count);
        currentSprite = SpriteList[num];
    }
}
