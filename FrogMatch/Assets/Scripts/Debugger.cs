using UnityEngine;
[CreateAssetMenu]
public class Debugger : ScriptableObject
{
    public void onDebug(string obj)
    {
        Debug.Log(obj);
    }
    
    public void onDebug(float obj)
    {
        Debug.Log(obj);
    }
    
    public void onDebug(int obj)
    {
        Debug.Log(obj);
    }
    
    public void onDebug(object obj)
    {
        Debug.Log(obj);
    }
}
