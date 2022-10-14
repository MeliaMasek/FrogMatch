using System.Collections.Generic;
using UnityEngine;
 [CreateAssetMenu]
public class ColorIdDataList : ScriptableObject
{
    public List<ColorId> colorIdList;
    public ColorId currentColor;
    private int num;

    public void SetCurrentColorRandomly()
    {
        num = Random.Range(0, colorIdList.Count);
        currentColor = colorIdList[num];
    }
}
