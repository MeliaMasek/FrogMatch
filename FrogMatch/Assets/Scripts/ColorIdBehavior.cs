using UnityEngine;

public class ColorIdBehavior : IdContainerBehavior
{
    public ColorIdDataList colorIdDataListObj;

    private void Awake()
    {
        idObj = colorIdDataListObj.currentColor;
    }
}
