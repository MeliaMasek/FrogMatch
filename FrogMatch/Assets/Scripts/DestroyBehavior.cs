using System;
using System.Collections;
using UnityEngine;

public class DestroyBehavior : MonoBehaviour
{
    public float seconds = 3;
    private WaitForSeconds wfsObj;

    private IEnumerator Start()
    {
        wfsObj = new WaitForSeconds(seconds);
        yield return wfsObj;
        Destroy(gameObject);
    }
}
