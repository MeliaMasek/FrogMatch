using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class IdDataList : ScriptableObject
{
    public List<Id> IdList;
    public Id currentId;
    private int num;

    public void SetCurrentIdRandomly()
    {
        num = Random.Range(0, IdList.Count);
        currentId = IdList[num];
    }
}
